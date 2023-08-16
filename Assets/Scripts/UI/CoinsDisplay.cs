using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsDisplay : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI text;
    PlayerCoins playerCoins;

    public void Start()
    {
        playerCoins = FindObjectOfType<PlayerCoins>();
    }

    public void Update()
    {
        text.SetText(playerCoins.coins.ToString());
    }
}
