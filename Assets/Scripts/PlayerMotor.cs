using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    private Rigidbody rb;

    public void Move(Vector3 velocity) {
        this.velocity = velocity;
    }

    public void Rotate(Vector3 rotation) {
        this.rotation = rotation;
    }

    public void RotateCamera(Vector3 cameraRotation) {
        this.cameraRotation = cameraRotation;
    }

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Runs every physics iteration
    private void FixedUpdate() {
        PerformMovement();
        PerformRotation();
    }

    private void PerformMovement() {
        if (this.velocity != Vector3.zero) {
            rb.MovePosition(rb.position + this.velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation() {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(this.rotation));
        if (cam != null) {
            cam.transform.Rotate(-cameraRotation);
        }
    }

}
