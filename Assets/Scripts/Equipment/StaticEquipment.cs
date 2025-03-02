using UnityEngine;

public class StaticEquipment : MonoBehaviour {

    private Outline outline;

    void Awake() {
        
        outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode  = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 10f;
        outline.enabled      = false;
    }

    public void Select() {
        Debug.Log($"Selecting static equipment: {gameObject.name}");
        outline.enabled = true;
    }

    public void Unselect() {
        Debug.Log($"Unselecting static equipment: {gameObject.name}");
        outline.enabled = false;
    }        

    public virtual void Interact(PlayerInteraction player) {
        Debug.Log($"Interacting with static equipment: {gameObject.name}");
    }
}
