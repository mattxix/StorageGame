using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class RaycastFromPlayer : MonoBehaviour
{
    public float raycastDistance = 5.0f;
    bool holdingItem = false;
    GameObject heldOBJ;

    public bool redBox = false;
    public bool blueBox = false;

    //public GameObject doorButton;

    //public Animator leftDoor;
    //public Animator rightDoor;
    bool doorUnlocked = false;

    //public Animator movingPlat;
    public Animator ladder;

    public AudioSource buttonSource;
    public AudioClip activateSFX;

    MeshRenderer hitObj;
    public GameObject messageBox;

    public Camera cutSecneCamera;
    public Camera playerCamera;
    public FPMovement playerInput;
    bool isActive = true;
    bool cutscenePlayed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green);

        if (redBox && blueBox)
        {
            if (cutscenePlayed == false)
            {
                playerCamera.enabled = false;
                cutSecneCamera.enabled = true;
                playerInput.enabled = false;
                StartCoroutine(CutsceneTime(2));
                isActive = false;
                
            }
            
            //doorButton.GetComponent<Renderer>().material.color = Color.green;
            doorUnlocked = true;
        }
        else
        {
            //doorButton.GetComponent<Renderer>().material.color = Color.red;
            doorUnlocked = false;
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3.0f))
        {
            if (hit.collider.tag == "PickupItem" && !holdingItem)
            {
                hitObj = hit.collider.GetComponent<MeshRenderer>();
                hitObj.materials[1].SetFloat("_Scale", 1.03f);
            }

            if (hit.collider.tag == "DoorButton" && doorUnlocked)
            {
                hitObj = hit.collider.GetComponent<MeshRenderer>();
                hitObj.materials[1].SetFloat("_Scale", 1.03f);
                messageBox.SetActive(true);
            }
        }
        else
        {
            if (hitObj != null)
            {
                hitObj.materials[1].SetFloat("_Scale", 0.1f);     
                hitObj = null;
                if(messageBox.activeSelf)
                {
                    messageBox.SetActive(false);
                }
            }
        }

    }

    public void PickupItem(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                Debug.Log(hit.collider.name);

                if (hit.collider.CompareTag("PickupItem"))
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

            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                Debug.Log(hit.collider.name);

                if (hit.collider.CompareTag("DoorButton") && doorUnlocked)
                {
                    //leftDoor.SetTrigger("OpenDoor");
                    //rightDoor.SetTrigger("OpenDoor");
                    //movingPlat.SetTrigger("move");
                    
                    playerCamera.enabled = false;
                    cutSecneCamera.enabled = true;
                    playerInput.enabled = false;
                    StartCoroutine(CutsceneTime(2));
                    isActive = false;
                    ladder.SetTrigger("Move");
                    
                    buttonSource.PlayOneShot(activateSFX);
                }
            }
        }
    }

    IEnumerator CutsceneTime(int seconds)
    {

        yield return new WaitForSeconds(seconds);
        cutscenePlayed = true;
        playerCamera.enabled = true;
        cutSecneCamera.enabled = false;
        playerInput.enabled = true;
        Debug.Log("cutscene end");


    }
}
