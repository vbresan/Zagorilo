using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : Singleton<GameInput> {

    private InputSystem inputSystem;
    public event EventHandler onPlayerInteraction;

    private void Interactions_performed(InputAction.CallbackContext context) {
        onPlayerInteraction?.Invoke(this, EventArgs.Empty);
    }

    private void Awake() {
        inputSystem = new InputSystem();
        inputSystem.Player.Enable();

        inputSystem.Player.Interactions.performed += Interactions_performed;
    }

    public Vector2 GetInputVectorNormalized() {
        Vector2 inputVector = inputSystem.Player.Movement.ReadValue<Vector2>();
        return inputVector.normalized;
    }
}