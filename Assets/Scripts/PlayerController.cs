using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float hSensitivity = 3f;
    [SerializeField]
    private float vSensitivity = 3f;
    private PlayerMotor playerMotor;

    private void Start() {
        playerMotor = GetComponent<PlayerMotor>();
    }

    private void Update() {
        // Calculate velocity as a 3D vector
        float hMovement = Input.GetAxisRaw("Horizontal");
        float vMovement = Input.GetAxisRaw("Vertical");
        float hRotation = Input.GetAxisRaw("Mouse X");
        float vRotation = Input.GetAxisRaw("Mouse Y");
        Vector3 moveHorizontal = transform.right * hMovement;
        Vector3 moveVertical = transform.forward * vMovement;
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;
        Vector3 rotation = new Vector3(0f, hRotation, 0f) * hSensitivity;
        Vector3 cameraRotation = new Vector3(vRotation, 0f, 0f) * vSensitivity;
        playerMotor.Move(velocity);
        playerMotor.Rotate(rotation);
        playerMotor.RotateCamera(cameraRotation);
    }

}
