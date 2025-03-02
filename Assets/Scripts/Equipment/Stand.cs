using UnityEngine;

public class Stand : StaticEquipment, IMovableEquipmentHolder {
    
    [SerializeField] protected Transform holdPoint;
    private GameObject movableEquipment;

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