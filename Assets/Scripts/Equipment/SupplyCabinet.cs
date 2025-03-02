using UnityEngine;

public class SupplyCabinet : StaticEquipment {

    [SerializeField] private MovableEquipmentSO movableSO;

    public override void Interact(PlayerInteraction player) {
        base.Interact(player);

        if (movableSO == null) {
            return;
        }

        if (player.HasMovableEquipment()) {
            return;
        }

        Transform  holdPoint = player.GetHoldPoint();
        GameObject equipment = Instantiate(movableSO.prefab, holdPoint);
        player.SetMovableEquipment(equipment);

        Debug.Log($"Spawned movable equipment: {movableSO.name}");
    }
}