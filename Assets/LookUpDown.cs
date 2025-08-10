using UnityEngine;

/*
 *  MouseLook.cs
 *  • Attach this to your Main Camera
 *  • Drag the Player (the object with Rigidbody/Capsule) into playerBody
 */

public class MouseLook : MonoBehaviour
{
    [Header("Settings")]
    public float sensitivity = 2f;     // tweak in Inspector
    public Transform playerBody;       // assign the root player object

    float xRotation = 0f;              // camera pitch

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible   = false;
    }

    void Update()
    {
        // ── Read mouse ───────────────────────────────────────
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // ── Pitch (up/down) ──────────────────────────────────
        xRotation -= mouseY;
        xRotation  = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // ── Yaw (left/right) ─────────────────────────────────
        playerBody.Rotate(Vector3.up * mouseX);
    }
}