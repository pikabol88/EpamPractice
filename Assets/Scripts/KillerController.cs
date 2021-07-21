using System.Collections;
using UnityEngine;

public class KillerController : BaseCharacter
{
    [SerializeField] private bool isPressed = false;
    [SerializeField] private float distance = 10f;
    [SerializeField] private Rigidbody _killerRigid;
    [SerializeField] private Rigidbody _slingshotRigid;
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private Animator _animator;

    private Camera _camera;  

    private void Start()
    {

        id = GetInstanceID();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (isPressed)
        {
            Vector3 mousePosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -_camera.transform.position.z));

            if (Vector3.Distance(mousePosition, _slingshotRigid.position) > distance)
            {
                _killerRigid.position = _slingshotRigid.position + (mousePosition - _slingshotRigid.position).normalized * distance;
            }
            else
            {
                transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
            }           
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
