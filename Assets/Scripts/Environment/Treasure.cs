using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : I_Interactable
{
    [SerializeField]
    GameObject openedTreasure;
    [SerializeField]
    GameObject closedTreasure;


    public override void Interact()
    {
        openedTreasure.SetActive(true);
        closedTreasure.SetActive(false);

    }

}
