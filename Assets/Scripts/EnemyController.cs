using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody enemyRigid;
    [SerializeField] private bool isPressed = false;

    private void Start()
    {
        enemyRigid = GetComponent<Rigidbody>();
    }
    public float distance = 10f;

    private void Update()
    {
        if(isPressed == true)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); 
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); 
            enemyRigid.position = objPosition; 
        }
    }
    private void OnMouseUp()
    {
        isPressed = false;
        enemyRigid.isKinematic = false;
       // StartCoroutine(LetsGo());
    }


    private void OnMouseDown()
    {
        isPressed = true;
        enemyRigid.isKinematic = true;
    }

    IEnumerator LetsGo()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject.GetComponent<SpringJoint>());
        this.enabled = false;
    }
}
