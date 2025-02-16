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

    private Vector3 GetCorrectedDirection(Vector3 direction) {

        if (IsNotCollision(direction)) {
            return direction;
        }

        Vector3 directionX = new Vector3(direction.x, 0, 0).normalized;
        if (IsNotCollision(directionX)) {
            return directionX;
        }

        Vector3 directionZ = new Vector3(0, 0, direction.z).normalized;
        if (IsNotCollision(directionZ)) {
            return directionZ;
        }        

        return Vector3.zero;
    }

    private void RotatePlayer(Vector3 direction) {
        
        transform.forward = Vector3.Slerp(
            transform.forward, 
            direction, 
            rotationSpeed * Time.deltaTime
        );
    }

    void Update() {
        
        Vector2 input = GameInput.Instance.GetInputVectorNormalized();

        Vector3 originalDirection  = new Vector3(input.x, 0, input.y);
        Vector3 correctedDirection = GetCorrectedDirection(originalDirection);

        isWalking = correctedDirection != Vector3.zero;
        if (isWalking) {

            RotatePlayer(correctedDirection);
            transform.position += 
                correctedDirection * movementSpeed * Time.deltaTime;

        } else if (originalDirection != Vector3.zero) {
            RotatePlayer(originalDirection);
        }
    }    

    public bool IsWalking() {
        return isWalking;
    }
}
