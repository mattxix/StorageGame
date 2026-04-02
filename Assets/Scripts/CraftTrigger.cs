using UnityEngine;

public class CraftTrigger : MonoBehaviour
{
    public int slotIndex; // 1 or 2
    public CraftingTableScript table;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Item")) return;

        ItemScript item = other.GetComponent<ItemScript>();
        if (item != null)
        {
            table.SetItem(slotIndex, other.gameObject, item);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Item")) return;

        table.ClearItem(slotIndex, other.gameObject);
    }
}