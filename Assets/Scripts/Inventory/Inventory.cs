using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform slotContainer;
    [Header("Inventory Settings")]
    public Transform hotbarContainer;
    private List<Slot> slots = new List<Slot>();
    void Start()
    {
        slots.AddRange(slotContainer.GetComponentsInChildren<Slot>());
        if (hotbarContainer != null)
        {
            slots.AddRange(hotbarContainer.GetComponentsInChildren<Slot>());
        }
    }
}
