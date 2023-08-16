using System.Collections;
using UnityEngine;

public class PriceTag : MonoBehaviour
{
    //TExt mesh pro
    [SerializeField]
    private TMPro.TextMeshProUGUI priceText;
    [SerializeField]
    private GameObject coinSprite;
    private IEnumerator corutine;

    public void OnEnable()
    { 
        corutine = UpdatePriceCoroutine();
        StartCoroutine(corutine);
    }

    public void OnDisable()
    {
        StopCoroutine(corutine);
    }

    //Corutine to update price every second
    public IEnumerator UpdatePriceCoroutine()
    {
        while(true)
        {
            UpdatePrice();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void UpdatePrice()
    {
        int price = 0;
        bool canAfford = false;
        EquipableItem item = transform.parent.GetComponentInChildren<EquipableItem>();
        if(item != null)
        {
            price = item.price;
            canAfford = item.CanAfford();
            priceText.gameObject.SetActive(true);
            coinSprite.SetActive(true);
        }
        else
        {
            priceText.gameObject.SetActive(false);
            coinSprite.SetActive(false);
            return;
        }

        if(price == 0)
        {
            priceText.color = Color.green;
            priceText.text = "Free";
            return;
        }
        
        if(canAfford)
        {
            priceText.color = Color.yellow;
        }
        else
        {
            priceText.color = Color.red;
        }

        //priceText.text = price.ToString();
        priceText.SetText(price.ToString());
    }
}
