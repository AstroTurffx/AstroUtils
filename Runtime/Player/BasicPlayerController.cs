using UnityEngine;
using AstroTurffx.AstroUtils;
using AstroTurffx.AstroUtils.Utils;

namespace AstroTurffx.AstroUtils.Runtime
{
    [RequireComponent(typeof(Rigidbody))]
    public class BasicPlayerController : Singleton<BasicPlayerController>
    {
        [Header("Movement")]

        public float walkSpeed = 1;
        public float sprintSpeed = 2;
        public float slipperyness = 0.1f;

        [Header("Jump")]
        public PlayerGroundCheck groundCheck;
        public float jumpForce = 1;

        [Header("Camera")]
        public Transform cameraHolder;
        public float sensitivity = 1;

        // Movement
        Vector3 smoothMoveVelocity;
        Vector3 moveAmount;
        
        [HideInInspector] public bool paused;
        [HideInInspector] public bool jumped;

        // Camera
        float verticalLookRotation;

        // Other
        Rigidbody rb;

        public void Start()
        {
            rb = GetComponent<Rigidbody>();
            Cursor.lockState = CursorLockMode.Locked;

            if(groundCheck == null)
                Debug.LogWarning("No ground check set!");

            if (cameraHolder == null)
                Debug.LogWarning("No camera holder set!");
        }

        void Update()
        {
            if(cameraHolder != null && !paused) Look();

            Move();
            Jump();
        }

        public void OnValidate()
        {
            if (groundCheck != null) groundCheck.player = this;
        }

        void Look()
        {
            transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * sensitivity);

            verticalLookRotation += Input.GetAxisRaw("Mouse Y") * sensitivity;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

            cameraHolder.localEulerAngles = Vector3.left * verticalLookRotation;
        }

        void Move()
        {
            Vector3 moveDir = paused ? Vector3.zero : new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed) * 5f, ref smoothMoveVelocity, slipperyness);
        }

        void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !jumped && !paused)
            {
                jumped = true;
                rb.AddForce(transform.up * jumpForce * 250f);
            }
        }

        void FixedUpdate()
        {
            rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
        }
    }
}