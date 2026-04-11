using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class RaycastFromPlayer : MonoBehaviour
{
    public LayerMask layersToHit;
    public float raycastDistance = 5.0f;
    public InfoCardManager cardManager;
    bool holdingItem = false;
    GameObject heldOBJ;
    MeshRenderer hitObj;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green);


        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3.0f, layersToHit))
        {
            if (hit.collider.tag == "Item" && !holdingItem)
            {
                hitObj = hit.collider.GetComponent<MeshRenderer>();
                hitObj.materials[1].SetFloat("_Scale", 1.03f);

                ItemScript objScript = hit.collider.GetComponentInParent<ItemScript>();
                cardManager.CollectInfoAndShow(objScript);
            }

        }
        else
        {
            if (hitObj != null)
            {
                hitObj.materials[1].SetFloat("_Scale", 0.1f);     
                hitObj = null;
            }

            cardManager.HideInfoCard();
        }


    }

    public void PickupItem(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, layersToHit))
            {
                Debug.Log(hit.collider.name);

                if (hit.collider.CompareTag("Item"))
                {
                    hit.collider.GetComponent<PickupOBJ>().Pickup();
                    heldOBJ = hit.collider.gameObject;
                    holdingItem = true;
                }
            }
        }

        if (ctx.canceled) 
        { 
        
            if (holdingItem)
            {
                heldOBJ.GetComponent<PickupOBJ>().Pickup();
                holdingItem = false;
                heldOBJ = null;
            }

        }
    }

    public void InteractableObject(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, layersToHit))
            {
                //Debug.Log(hit.collider.name);
                if (hit.collider.CompareTag("Button"))
                {
                    hit.collider.GetComponent<ConfirmItem>().Confirm(false);  
                }
                if (hit.collider.CompareTag("RestoreButton"))
                {
                    hit.collider.GetComponent<ConfirmItem>().Confirm(true);
                }

            }
        }
    }

}
