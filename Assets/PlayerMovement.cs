using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputSystem inputSystem;
    private bool isWalking = false;

    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float rotationSpeed = 15f;

    void Start() {
        inputSystem = new InputSystem();
        inputSystem.Player.Enable();
        
    }

    void Update() {
        
        Vector2 inputVector = GetInputVector();
        Vector3 movement    = new Vector3(inputVector.x, 0, inputVector.y);

        transform.position += movement * movementSpeed * Time.deltaTime;

        if (movement != Vector3.zero) {
            transform.forward = Vector3.Slerp(transform.forward, movement, rotationSpeed * Time.deltaTime);
        }

        isWalking = movement != Vector3.zero;
    }    

    public Vector2 GetInputVector() {
        return inputSystem.Player.Movement.ReadValue<Vector2>().normalized;
    }

    public bool IsWalking() {
        return isWalking;
    }
}
