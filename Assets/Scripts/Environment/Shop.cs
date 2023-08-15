using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : I_Interactable
{
    [SerializeField]
    GameObject ShopUI;
    [SerializeField]
    GameObject SlotPrefab;
    [SerializeField]
    GameObject ShopGrid;
    public override void Interact()
    {
        ToggleShopUI();
    }

    void Awake()
    {
        // GameObject instance = Instantiate(SlotPrefab, transform.position, Quaternion.identity);
        // instance.transform.SetParent(ShopGrid.transform);
        // instance.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        // //If theres a need to rezise, resize the shopgrid rect vertically
        // AddRowShopGrid();

    }

    private void AddRowShopGrid()
    {
        ShopGrid.GetComponent<RectTransform>().sizeDelta = new Vector2(ShopGrid.GetComponent<RectTransform>().sizeDelta.x,ShopGrid.GetComponent<RectTransform>().sizeDelta.y+ 60);
    }

    private void ToggleShopUI()
    {
        ShopUI.SetActive(!ShopUI.activeSelf);
    }

    public override void OnPlayerNear()
    {
        
    }

    public override void OnPlayerNotNear()
    {

    }
}
