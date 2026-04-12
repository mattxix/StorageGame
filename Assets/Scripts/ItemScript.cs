using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    //public GameObject InfoCardCanvas;
    [HideInInspector] public string itemNameText;
    [HideInInspector] public string estValueText;
    [HideInInspector] public string currentConditionText;
    [HideInInspector] public string restoreCostText;
    [HideInInspector] public string potentalGrowthText;

    [Header("Info")]
    public string itemName;
    public Image itemImage;
    public float value;
    float estValue;
    [HideInInspector] public float restorationCost;
    string potentialGrowthSymbols;
    [HideInInspector] public float finalValue;

    public void Start()
    {
        estValue = Mathf.Max(1, Random.Range(value*.75f, value*1.25f));
        itemNameText = itemName;
        estValueText = "Value? - ~$" + estValue.ToString("F2");

        DamageCheck();
    }

    public void DamageCheck()
    {
        bool isDamaged = Random.Range(0, 3) == 0;

        if (!isDamaged)
        {
            currentConditionText = "Condition - New";
            restoreCostText = "";
            potentalGrowthText = "";
            return;
        }

        
        PotentialValueCheck();
        currentConditionText = "Condition - Damaged";
        restorationCost = value * 2;
        restoreCostText = "Restore Cost - $" + restorationCost.ToString("F2");
        

    }
    public void PotentialValueCheck()
    {
        //Chooses ($-$$$$$) has a chance to show 1 less or one more than the true value
        potentialGrowthSymbols = "Potential Growth - "; 
        int dSigns = Random.Range(1, 6);
        int displaySigns = dSigns;
        int roll = Random.Range(0, 10);
        if (roll < 2)
            displaySigns = Mathf.Clamp(dSigns - 1, 1, 4);
        else if (roll < 4)
            displaySigns = Mathf.Clamp(dSigns + 1, 1, 4);
        for (int i = 0; i < displaySigns; i++)
        {
            potentialGrowthSymbols += "$";
        }
        potentalGrowthText = potentialGrowthSymbols;
        //Calculates new value based on the $ (1-5)
        switch (dSigns)
        {
            case 1:
                finalValue = value * 1.1f;
                break;
            case 2:
                finalValue = value * 1.4f;
                break;
            case 3:
                finalValue = value * 2.5f;
                break;
            case 4:
                finalValue = value * 3.2f;
                break;
            case 5:
                finalValue = value * 4.5f;
                break;
        }

    }
    //public void Restore()
    //{

    //}
    



}
