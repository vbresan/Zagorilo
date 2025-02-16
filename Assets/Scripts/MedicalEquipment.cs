using UnityEngine;

public class MedicalEquipment : MonoBehaviour {

    private Outline outline;

    void Awake() {
        
        outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode  = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 10f;
        outline.enabled      = false;
    }

    public void Select() {
        Debug.Log($"Selecting medical equipment: {gameObject.name}");
        outline.enabled = true;
    }

    public void Unselect() {
        Debug.Log($"Unselecting medical equipment: {gameObject.name}");
        outline.enabled = false;
    }        

    public void Interact() {
        Debug.Log($"Interacting with medical equipment: {gameObject.name}");
    }
}
