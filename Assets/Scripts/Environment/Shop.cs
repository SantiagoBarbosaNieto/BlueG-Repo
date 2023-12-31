using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop : I_Interactable
{
    [SerializeField] 
    float  maxSlots = 30;
    [SerializeField]
    GameObject ShopUI;
    [SerializeField]
    GameObject SlotPrefab;
    [SerializeField]
    GameObject ShopGrid;
    [SerializeField]
    Scrollbar sb; //Ugly but works for now

    [SerializeField]
    GameObject topIcon;

    public override void Interact()
    {
        ToggleShopUI();
    }

    void Awake()
    {
        //Initialize and instantiate all shop stock + a few empty slots, based on a SO
        
        //while # of slots < slotsNum
        while(ShopGrid.transform.childCount < maxSlots) {
            GameObject instance = Instantiate(SlotPrefab, transform.position, Quaternion.identity);
            instance.transform.SetParent(ShopGrid.transform);
            instance.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            
            int mod = ShopGrid.transform.childCount % 5;

            if(ShopGrid.transform.childCount > 25 && mod == 0)
            {
                AddRowToShopGrid();
            }
        }
        ShopUI.SetActive(false);



    }

    private void AddRowToShopGrid()
    {
        ShopGrid.GetComponent<RectTransform>().sizeDelta = new Vector2(ShopGrid.GetComponent<RectTransform>().sizeDelta.x,ShopGrid.GetComponent<RectTransform>().sizeDelta.y+ 60);
    }

    private void ToggleShopUI()
    {
        ShopUI.SetActive(!ShopUI.activeSelf);
        sb.value = 1;
    }

    public override void OnPlayerNear()
    {
        topIcon.SetActive(true);
    }

    public override void OnPlayerExitNear()
    {
        ShopUI.SetActive(false);
        topIcon.SetActive(false);
    }

}
