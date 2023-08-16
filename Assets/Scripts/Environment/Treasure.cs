using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : I_Interactable
{
    [SerializeField]
    GameObject openedTreasure;
    [SerializeField]
    GameObject closedTreasure;
    [SerializeField]
    GameObject topIcon;


    void Awake()
    {
        openedTreasure.SetActive(false);
        closedTreasure.SetActive(true);
        topIcon.SetActive(false);
    }
    
    public override void Interact()
    {
        openedTreasure.SetActive(true);
        closedTreasure.SetActive(false);
        GetComponent<Treasure>().enabled = false;

        
        PlayerCoins playerCoins = GameObject.FindObjectOfType<PlayerCoins>();
        playerCoins.AddCoins(30);

        //Play some animation of coins flying out of the treasure
    }

    public override void OnPlayerNear()
    {
        topIcon.SetActive(true);
    }

    public override void OnPlayerExitNear()
    {
        topIcon.SetActive(false);
    }
}
