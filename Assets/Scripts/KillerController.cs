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
    [SerializeField] private SkinnedMeshRenderer _mesh;

    // [SerializeField] private AudioSource _onMouseUp;
    //[SerializeField] private AudioSource _onCollision;
    //[SerializeField] private AudioSource _destroy;

    private Camera _camera;

    public SkinnedMeshRenderer Mesh
    {
        get
        {
            return _mesh;
        }
    }

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
        else
        {
            Vector3 point = _camera.WorldToViewportPoint(transform.position);
            if (point.y < 0f || point.y > 1f || point.x > 1f || point.x < 0f)
            {
                StartCoroutine(DestroyKiller());
            }
        }

    }
    private void OnMouseUp()
    {
        isPressed = false;
        _killerRigid.isKinematic = false;
        PlaySound.Instanse.PlayBatGoSound();
        StartCoroutine(LetsGo());
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        isPressed = true;
        _killerRigid.isKinematic = true;
        GameController.Instanse.KillerOnPress(false);
    }

    IEnumerator LetsGo()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(_springJoint);
        enabled = false;
        _animator.SetBool("Move", true);
        yield return new WaitForSeconds(0.1f);
        GameController.Instanse.KillerOnPress(true);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Character"))
        {
            _animator.SetBool("Attack", true);
            PlaySound.Instanse.PlayBatCollisionSound();
            StartCoroutine(DestroyKiller());
        }
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Killer"))
        {
            if (!isPressed)
            {
                _animator.SetBool("Die", true);
                StartCoroutine(DestroyKiller());
            }
        }      

    }

    private IEnumerator DestroyKiller()
    {       
        yield return new WaitForSeconds(0.2f);
        PlaySound.Instanse.PlayBatDestroySound();
        _mesh.gameObject.SetActive(false);
        Boom();
        yield return new WaitForSeconds(0.4f);        
        Destroy(gameObject);
        GameController.Instanse.OnKillerDestroyed();
        StopAllCoroutines();
    }

    private void Boom()
    {
        var _particleSystem = GetComponentsInChildren<ParticleSystem>();
        Debug.Log(_particleSystem);
        foreach (var ps in _particleSystem)
        {
            Debug.Log(ps);
            ps.Play();
        }
    }
}
