using UnityEngine;

public class ChoseItemTrigger : MonoBehaviour
{
    public ConfirmItem confirmScript;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Item")) return;
        Debug.Log("Something entered: " + other.gameObject.name);
        ItemScript objScript = other.GetComponentInParent<ItemScript>();
        Debug.Log("ItemScript found: " + objScript);
        if (objScript != null)
        {
            confirmScript.IsAnItemReady = true;
            confirmScript.transferInfo(objScript);
            Debug.Log("Transferred: " + confirmScript.currentItem);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Item")) return;
        confirmScript.IsAnItemReady = false;
        confirmScript.currentItem = null;
    }
}
