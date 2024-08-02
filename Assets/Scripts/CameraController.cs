using UnityEngine;

public class CameraController : MonoBehaviour {
    public float mouseSensitivity = 100f;
    public float joystickSensitivity = 100f;
    public float distanceFromPlayer = 5f;
    public float cameraHeight = 2f;
    private float pitch = 0f;
    private float yaw = 0f;
    
    [SerializeField] private Transform player;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate() {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        pitch = Mathf.Clamp(pitch, -35f, 60f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        transform.position = player.position - (rotation * Vector3.forward * distanceFromPlayer) + Vector3.up * cameraHeight;
        transform.LookAt(player.position + Vector3.up * cameraHeight);
    }
}
