using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Basic Movment Properties")]
    public float movementSpeed;
    public float runSpeed;

    [Header("Material Properties")]
    public Material runMat;

    [Header("Jump Properties")]
    public float jumpForce;
    bool _isGrounded;

    [Header("Cinemachine")]
    public Transform followTarget;

    Rigidbody _rb;
    Vector3 _vectorMovement;
    Material _originalMat;
    Renderer _renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        
        _originalMat = _renderer.material;
        _rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jumping();
    }

    void FixedUpdate() 
    {
        MovementSetup();
    }

    void MovementSetup() 
    {
        _vectorMovement.x = Input.GetAxisRaw("Horizontal");
        _vectorMovement.z = Input.GetAxisRaw("Vertical");

        _rb.MovePosition(_rb.position + _vectorMovement * movementSpeed * Time.fixedDeltaTime);
    }

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _renderer.material = runMat;
            movementSpeed *= runSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _renderer.material = _originalMat;
            movementSpeed /= runSpeed;
        }
    }

    void Jumping()
    {
        if(Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    // Ground Layer is 3
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            _isGrounded = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(followTarget.position, .5f);
    }
}
