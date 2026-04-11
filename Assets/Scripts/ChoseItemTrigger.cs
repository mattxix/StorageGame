using UnityEngine;

public class ChoseItemTrigger : MonoBehaviour
{
    public ConfirmItem confirmScript;
    private void OnTriggerEnter(Collider other)
    {
        
        ItemScript objScript = other.GetComponentInParent<ItemScript>();
        if (objScript != null)
        {
            confirmScript.IsAnItemReady = true;
            confirmScript.transferInfo(objScript);
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        confirmScript.IsAnItemReady = false;
        confirmScript.currentItem = null; 
    }
}
