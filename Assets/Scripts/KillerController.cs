using System.Collections;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class KillerController : BaseCharacter
{
    [SerializeField] private bool isPressed = false;
    [SerializeField] private float distance = 10f;
    [SerializeField] private Rigidbody _killerRigid;
    [SerializeField] private SpringJoint _springJoint;

    private Camera _camera;
    
    private Animator _animator;


    private void Start()
    {

        id = GetInstanceID();
        _animator = GetComponent<Animator>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if(isPressed)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); 
            Vector3 objPosition = _camera.ScreenToWorldPoint(mousePosition); 
            _killerRigid.position = objPosition; 
        }
    }
    private void OnMouseUp()
    {
        isPressed = false;
        _killerRigid.isKinematic = false;
        StartCoroutine(LetsGo());
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        isPressed = true;
        _killerRigid.isKinematic = true;
    }

    IEnumerator LetsGo()
    {
        yield return new WaitForSeconds(0.1f); 
        Destroy(_springJoint);
        enabled = false;

        _animator.SetBool("Move", true);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Character"))
        {
            _animator.SetBool("Die", true);
            StartCoroutine(DestroyKiller());
        }
        _animator.SetBool("Attack", true);

    }

    private IEnumerator DestroyKiller()
    {
        yield return new WaitForSeconds(1f);        
        Destroy(gameObject);
        GameController.Instanse.OnKillerDestroyed();
    }
}
