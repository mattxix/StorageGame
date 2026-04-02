using System.Collections;
using TMPro;
using UnityEngine;

public class CraftingTableScript : MonoBehaviour
{
    [Header("Debug")]
    public bool isPlaced1 = false;
    public bool isPlaced2 = false;

    private float item1Value;
    private float item2Value;
    private string itemName1;
    private string itemName2;
    private GameObject item1;
    private GameObject item2;
    private bool isCombining = false;
    [Header("TableUI")]
    public TextMeshProUGUI soldText;
    public TextMeshProUGUI item1ValueText;
    public TextMeshProUGUI item1TitleText;
    public TextMeshProUGUI item2ValueText;
    public TextMeshProUGUI item2TitleText;
    public TextMeshProUGUI finalValueText;
    public TextMeshProUGUI finalTitleName;

    [Header("TableSlots")]
    public GameObject CraftSlot1;
    public GameObject CraftSlot2;
    [Header("Waypoint")]
    public Transform waypoint;
    [Header("Money")]
    public TextMeshProUGUI moneyCount;
    public float money = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyCount.text = "$0.00";
        moneyCount.text = $"${money:F2}";
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaced1 && isPlaced2 && !isCombining)
        {
            isCombining = true;
            RunCombine();
        }
    }

    public void SetItem(int slot, GameObject obj, ItemScript item)
    {
        if (slot == 1)
        {
            item1 = obj;
            
            item1Value = item.value;
            itemName1 = item.itemName;

            item1ValueText.text = $"${item1Value}";
            item1TitleText.text = itemName1;
            isPlaced1 = true;
        }
        else if (slot == 2)
        {
            item2 = obj;
            item2Value = item.value;
            itemName2 = item.itemName;

            item2ValueText.text = $"${item2Value}";
            item2TitleText.text = itemName2;
            isPlaced2 = true;
        }
    }
    public void ClearItem(int slot, GameObject obj)
    {
        if (slot == 1 && obj == item1)
        {
            item1 = null;
            item1Value = 0f;
            itemName1 = "";

            item1ValueText.text = "";
            item1TitleText.text = "Item 1";

            isPlaced1 = false;
        }
        else if (slot == 2 && obj == item2)
        {
            item2 = null;
            item2Value = 0f;
            itemName2 = "";

            item2ValueText.text = "";
            item2TitleText.text = "Item 2";

            isPlaced2 = false;
        }
    }
    public void RunCombine()
    {
        StartCoroutine(CombineSequence());
    }

    IEnumerator CombineSequence()
    {
        yield return new WaitForSeconds(1f);
        item1.GetComponent<Collider>().enabled = false;
        item2.GetComponent<Collider>().enabled = false;
        CraftSlot1.GetComponent<CraftTrigger>().enabled = false;
        CraftSlot2.GetComponent<CraftTrigger>().enabled = false;

        item1ValueText.text = "";
        item2ValueText.text = "";
        item1TitleText.text = "Item 1";
        item2TitleText.text = "Item 2";
        item1TitleText.gameObject.SetActive(false);
        item2TitleText.gameObject.SetActive(false);

        finalValueText.text = "$" + (item1Value * item2Value).ToString();
        finalTitleName.text = itemName1 + " " + itemName2;

        StartCoroutine(LerpItems());
        
        yield return new WaitForSeconds(2.5f);
        soldText.text = "SOLD";
        yield return new WaitForSeconds(.5f);
        money += (item1Value * item2Value);
        moneyCount.text = $"${money:F2}";
        Destroy(item1);
        Destroy(item2);
        yield return new WaitForSeconds(.75f);
        soldText.text = "";
        item1TitleText.gameObject.SetActive(true);
        item2TitleText.gameObject.SetActive(true);
        finalValueText.text = "";
        finalTitleName.text = "";
        CraftSlot1.GetComponent<CraftTrigger>().enabled = true;
        CraftSlot2.GetComponent<CraftTrigger>().enabled = true;
        isPlaced1 = false;
        isPlaced2 = false;
        isCombining = false;

    }

    IEnumerator LerpItems()
    {
        float duration = 2f;
        float time = 0f;

        Vector3 startPos1 = item1.transform.position;
        Vector3 startPos2 = item2.transform.position;

        Vector3 targetPos = waypoint.position;

        while (time < duration)
        {
            float t = time / duration;

            item1.transform.position = Vector3.Lerp(startPos1, targetPos, t);
            item2.transform.position = Vector3.Lerp(startPos2, targetPos, t);

            time += Time.deltaTime;
            yield return null;
        }

        item1.transform.position = targetPos;
        item2.transform.position = targetPos;
    }

    
}
