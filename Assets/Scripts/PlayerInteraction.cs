using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    [SerializeField] private LayerMask layerMask;
    private int interactionDistance = 1;
    private MedicalEquipment selectedEquipment;

/*
    public event EventHandler<OnMedicalEquipmentSelectedEventArgs> onMedicalEquipmentSelected;
    public class OnMedicalEquipmentSelectedEventArgs : EventArgs { 

        public MedicalEquipment medicalEquipment;


    }
*/    

    private void OnPlayerInteraction(object sender, EventArgs e) {
        selectedEquipment?.Interact();
    }

    private void SelectEquipment(MedicalEquipment equipment) {

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

/*
        selectedEquipment = equipment;
        onMedicalEquipmentSelected?.Invoke(this, new OnMedicalEquipmentSelectedEventArgs {
            medicalEquipment = equipment
        });
*/        
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

        MedicalEquipment equipment = hit.transform.GetComponent<MedicalEquipment>();
        SelectEquipment(equipment);
    }
}
