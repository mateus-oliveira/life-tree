using UnityEngine;

public class PlayerController : MonoBehaviour {
    private bool delayed;
    private float moveSpeed;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private Animator animator;

    [SerializeField] private float walkSpeed, delayedSpeed, jumpForce;
    [SerializeField] private Transform cameraTransform;

    
    void Start() {
        moveSpeed = walkSpeed;
        delayed = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }


    void Update() {
        moveDirection = this.CalculateMoveDirection();

        moveSpeed = delayed ? walkSpeed - delayedSpeed : walkSpeed;
        if (moveDirection != Vector3.zero) {
            animator.SetBool("Walking", true);
            transform.forward = moveDirection;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        } else {
            animator.SetBool("Walking", false);
        }
    }


    private Vector3 CalculateMoveDirection() {
        // Calculates the direction by camera rotation
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        return (forward * vertical + right * horizontal).normalized;
    }


    public void SetJumpAnimation(bool jump) {
        // Jump
        if (jump) {
            rb.velocity = Vector3.up * jumpForce;
        }
        animator.SetBool("Jump", jump);
    }

    public void SetDelayed(bool delayed) {
        this.delayed = delayed;
    }
}
