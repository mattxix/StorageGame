using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoCardManager : MonoBehaviour
{
    [Header("UI")]
    //public GameObject InfoCardCanvasUI;
    public Image itemImageUI;
    public TextMeshProUGUI itemNameTextUI;
    public TextMeshProUGUI estValueTextUI;
    public TextMeshProUGUI currentConditionTextUI;
    public TextMeshProUGUI restoreCostTextUI;
    public TextMeshProUGUI potentalGrowthTextUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectInfoAndShow(ItemScript infoScript)
    {
        if (infoScript == null)
            return;

        itemNameTextUI.text          = infoScript.itemNameText;
        estValueTextUI.text           = infoScript.estValueText;
        currentConditionTextUI.text   = infoScript.currentConditionText;
        restoreCostTextUI.text       = infoScript.restoreCostText;
        potentalGrowthTextUI.text   = infoScript.potentalGrowthText;

        gameObject.SetActive(true);
    }    

    public void HideInfoCard()
    {
        gameObject.SetActive(false);
    }
}
