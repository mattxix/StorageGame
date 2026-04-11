using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    [Header("UI")]
    public GameObject InfoCardCanvas;
    public Image itemImage;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI estValueText;
    public TextMeshProUGUI currentConditionText;
    public GameObject restoreNotNeededText;
    public TextMeshProUGUI restoreCostText;
    public TextMeshProUGUI potentalGrowthText;
    public TextMeshProUGUI cantRestoreText;

    [Header("Info")]
    public string itemName;
    public float estValue;
    public float value;
    float restorationCost;
    string potentialGrowthSymbols;
    float finalValue;

    public void Start()
    {
        itemNameText.text = itemName;
        estValueText.text = "~$" + estValue.ToString("F2");

        DamageCheck();
    }

    public void DamageCheck()
    {
        bool isDamaged = Random.Range(0, 3) == 0;

        if (!isDamaged)
        {
            currentConditionText.text = "New";
            restoreNotNeededText.SetActive(true);
            return;
        }

        restoreNotNeededText.SetActive(false);
        PotentialValueCheck();
        currentConditionText.text = "Damaged";
        restorationCost = value * 2;
        restoreCostText.text = "$" + restorationCost.ToString("F2");
        

    }
    public void PotentialValueCheck()
    {
        //Chooses ($-$$$$$) has a chance to show 1 less or one more than the true value
        potentialGrowthSymbols = ""; 
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
        potentalGrowthText.text = "~"+potentialGrowthSymbols+"~";
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
    public void DisplayInfoCard()
    {
        InfoCardCanvas.SetActive(true);
    }
    public void DontDisplayInfoCard()
    {
        InfoCardCanvas.SetActive(false);
    }



}
