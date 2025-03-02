using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour, IMovableEquipmentHolder {

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform holdPoint;
    private int interactionDistance = 1;
    private StaticEquipment selectedEquipment;
    private GameObject movableEquipment;


    private void OnPlayerInteraction(object sender, EventArgs e) {
        selectedEquipment?.Interact(this);
    }

    private void SelectEquipment(StaticEquipment equipment) {

        if (selectedEquipment == null && equipment != null) {

            selectedEquipment = equipment;
            selectedEquipment.Select();

        } else if (selectedEquipment != equipment) {
                
            selectedEquipment.Unselect();
            selectedEquipment = equipment;

            if (selectedEquipment != null) {
                selectedEquipment.Select();
            }
        }
    }

    void Start() {
        GameInput.Instance.onPlayerInteraction += OnPlayerInteraction;
    }

    void Update() {

        bool isSelecting = Physics.Raycast(
            transform.position, 
            transform.forward,
            out RaycastHit hit,
            interactionDistance,
            layerMask
        );
        if (!isSelecting) {
            SelectEquipment(null);
            return;
        }

        StaticEquipment equipment = hit.transform.GetComponent<StaticEquipment>();
        SelectEquipment(equipment);
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
