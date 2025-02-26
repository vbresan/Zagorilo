using UnityEngine;

public class SupplyCabinet : StaticEquipment {

    [SerializeField] private MovableEquipmentSO movableSO;

    public override void Interact() {
        base.Interact();

        if (movableSO == null) {
            return;
        }

        Instantiate(movableSO.prefab, holdPoint);
        Debug.Log($"Spawned movable equipment: {movableSO.name}");
    }
}