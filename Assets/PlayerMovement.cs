using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputSystem inputSystem;
    private bool isWalking = false;

    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float rotationSpeed = 15f;

    private bool IsNotCollision(Vector3 direction) {

        float playerHeight = 2f;
        float playerRadius = 0.3f;
        float distance     = movementSpeed * Time.deltaTime;

        return !Physics.CapsuleCast(
            transform.position, 
            transform.position + Vector3.up * playerHeight, 
            playerRadius, 
            direction, 
            distance
        );
    }

    private bool CanMoveInDirection(ref Vector3 direction) {

        if (IsNotCollision(direction)) {
            return true;
        }

        Vector3 directionX = new Vector3(direction.x, 0, 0).normalized;
        if (IsNotCollision(directionX)) {
            direction = directionX;
            return true;
        }

        Vector3 directionZ = new Vector3(0, 0, direction.z).normalized;
        if (IsNotCollision(directionZ)) {
            direction = directionZ;
            return true;
        }        

        return false;
    }

    void Start() {
        inputSystem = new InputSystem();
        inputSystem.Player.Enable();
        
    }

    void Update() {
        
        Vector2 inputVector = GetInputVector();
        Vector3 direction   = new Vector3(inputVector.x, 0, inputVector.y);

        if (CanMoveInDirection(ref direction)) {
            transform.position += direction * movementSpeed * Time.deltaTime;
        }

        if (direction != Vector3.zero) {
            transform.forward = Vector3.Slerp(
                transform.forward, 
                direction, 
                rotationSpeed * Time.deltaTime
            );
        }

        isWalking = direction != Vector3.zero;
    }    

    public Vector2 GetInputVector() {
        return inputSystem.Player.Movement.ReadValue<Vector2>().normalized;
    }

    public bool IsWalking() {
        return isWalking;
    }
}
