using UnityEngine;

public interface IMovableEquipmentHolder {

    public Transform GetHoldPoint();
    public void SetMovableEquipment(GameObject equipment);
    public GameObject GetMovableEquipment();
    public bool HasMovableEquipment();
}