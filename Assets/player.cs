using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class SoloCameraController : MonoBehaviour
{
    /* ── Look ─────────────────────────────── */
    [Header("Look")]
    public float mouseSensitivity = 2f;
    private float yaw;     // left–right
    private float pitch;   // up–down

    /* ── Move ─────────────────────────────── */
    [Header("Move")]
    public float moveSpeed = 5f;
    private float moveH;
    private float moveV;

    /* ── Jump ─────────────────────────────── */
    [Header("Jump")]
    public float jumpForce = 10f;
    public LayerMask groundMask;
    private bool grounded;
    private const float groundCheckDist = 0.15f;

    /* ── Internals ────────────────────────── */
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;      // stop physics spin

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible   = false;
    }

    void Update()
    {
        /* ---- Mouse look ---- */
        yaw   += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch  = Mathf.Clamp(pitch, -90f, 90f);
        transform.localRotation = Quaternion.Euler(pitch, yaw, 0f);

        /* ---- Movement input ---- */
        moveH = Input.GetAxisRaw("Horizontal");
        moveV = Input.GetAxisRaw("Vertical");

        /* ---- Jump ---- */
        grounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDist, groundMask);
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    void FixedUpdate()
    {
        Vector3 dir = (transform.right * moveH + transform.forward * moveV).normalized;
        Vector3 vel = rb.velocity;
        vel.x = dir.x * moveSpeed;
        vel.z = dir.z * moveSpeed;
        rb.velocity = vel;
    }
}
