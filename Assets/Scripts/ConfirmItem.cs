using TMPro;
using UnityEngine;

public class ConfirmItem : MonoBehaviour
{
    [Header("ReportUI")]
    public TextMeshProUGUI SpentOnUnitText;
    //public TextMeshProUGUI EstCostItemText;
    public TextMeshProUGUI CostOfRestorationText;
    //public TextMeshProUGUI NotRestoredText;
    public TextMeshProUGUI FinalSoldValueText;
    public TextMeshProUGUI ProfitText;
    public GameObject ReportCanvas;
    float profit;
    float storageCost;

    [Header("Button")]
    //public GameObject ConfirmButton;

    [Header("Collider")]
    public BoxCollider boxCollider;
    [HideInInspector] public bool IsAnItemReady;

    [Header("Scripts")]
    public TimerScript timerScript;
    public CharacterController characterController;
    public FPMovement movementScript;
    public MouseLook lookScript1;
    public MouseLook lookScript2;
    [HideInInspector] public ItemScript currentItem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ReportCanvas.SetActive(false);

        //Temp
        storageCost = -25f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void transferInfo(ItemScript script)
    {
        currentItem = script; 
    }

    public void Confirm(bool IsGoingToRestore)
    {
        //Pause Game
        timerScript.PauseTimeToggle(true);
        lookScript1.enabled = false;
        lookScript2.enabled = false;
        characterController.enabled = false;
        movementScript.enabled = false;

        ReportCanvas.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //Display the reciept

        if(IsGoingToRestore)
        {

            FinalSoldValueText.text = "Item Sold Value: +" + currentItem.finalValue.ToString();
            CostOfRestorationText.text = "Restore Cost: -" + currentItem.restorationCost.ToString();

            profit = storageCost - currentItem.restorationCost + currentItem.finalValue;
        }
        else
        {
            Debug.Log("currentItem: " + currentItem);
            Debug.Log("FinalSoldValueText: " + FinalSoldValueText);
            FinalSoldValueText.text = "Item Sold Value: +" + currentItem.value.ToString();
            CostOfRestorationText.text = "Restore Cost: Not Restored";
            profit = storageCost + currentItem.value;
        }

        //temp
        SpentOnUnitText.text = "Unit Cost: -$25";

        ProfitText.text = "Profit: "+ profit;

        ReportCanvas.SetActive(true);

    }

    
    
}
