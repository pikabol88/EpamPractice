using System.Collections;
using UnityEngine;

//TODO: i suggest renaming this class
[RequireComponent(typeof(Rigidbody))]
public class EnemyController : BaseCharacter
{
    [SerializeField] private bool isPressed = false;
    [SerializeField] private float distance = 10f;

    private Camera _camera;
    private Rigidbody _enemyRigid;
    private SpringJoint _springJoint;


    private void Start()
    {

        id = GetInstanceID();
        _enemyRigid = GetComponent<Rigidbody>();
        _springJoint = GetComponent<SpringJoint>();

        _camera = Camera.main;
    }

    private void Update()
    {
        if(isPressed)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); 
            Vector3 objPosition = _camera.ScreenToWorldPoint(mousePosition); 
            _enemyRigid.position = objPosition; 
        }
    }
    private void OnMouseUp()
    {
        isPressed = false;
        _enemyRigid.isKinematic = false;
        StartCoroutine(LetsGo());
    }

    private void OnMouseDown()
    {
        isPressed = true;
        _enemyRigid.isKinematic = true;
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
            StartCoroutine(DestroyEnemy());
        }
        
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1f);        
        Destroy(gameObject);
        GameController.Instanse.OnEnemyDestroyed();
    }
}
