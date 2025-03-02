using NUnit.Framework;
using UnityEngine;

public class Stand : StaticEquipment, IMovableEquipmentHolder {
    
    [SerializeField] private Transform holdPoint;
    [SerializeField] private GameObject movableEquipment;

    public override void Interact(PlayerInteraction player) {
        base.Interact(player);

        if (!player.HasMovableEquipment() && HasMovableEquipment()) {

            movableEquipment.transform.parent = player.GetHoldPoint();
            movableEquipment.transform.localPosition = Vector3.zero;
            player.SetMovableEquipment(movableEquipment);
            movableEquipment = null;

        } else if (player.HasMovableEquipment() && !HasMovableEquipment()) {
            
            movableEquipment = player.GetMovableEquipment();
            movableEquipment.transform.parent = holdPoint;
            movableEquipment.transform.localPosition = Vector3.zero;
            player.SetMovableEquipment(null);
        }
    }

    public Transform GetHoldPoint() {
        return holdPoint;
    }
    
    public void SetMovableEquipment(GameObject movableEquipment) {
        this.movableEquipment = movableEquipment;
    }

    public GameObject GetMovableEquipment() {
        return movableEquipment;
    }

    public bool HasMovableEquipment() {
        return movableEquipment != null;
    }
}