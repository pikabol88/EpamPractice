using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KillerController : BaseCharacter
{
    [SerializeField] private bool isPressed = false;
    [SerializeField] private float distance = 10f;

    private Camera _camera;
    private Rigidbody _killerRigid;
    private SpringJoint _springJoint;


    private void Start()
    {

        id = GetInstanceID();
        _killerRigid = GetComponent<Rigidbody>();
        _springJoint = GetComponent<SpringJoint>();

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
        isPressed = true;
        _killerRigid.isKinematic = true;
    }

    IEnumerator LetsGo()
    {
        yield return new WaitForSeconds(0.1f); 
        Destroy(_springJoint);
        enabled = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground")
        {
            StartCoroutine(DestroyKiller());
        }
        
    }

    private IEnumerator DestroyKiller()
    {
        yield return new WaitForSeconds(1f);        
        Destroy(gameObject);
        GameController.Instanse.OnKillerDestroyed();
    }
}
