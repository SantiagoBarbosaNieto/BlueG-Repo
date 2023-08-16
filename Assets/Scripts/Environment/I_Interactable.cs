using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class I_Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().SubscribeInteractable(Interact);
            OnPlayerNear();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().UnsubscribeInteractable(Interact);
            OnPlayerExitNear();
        }
    }

    public abstract void OnPlayerNear();
    public abstract void OnPlayerExitNear();

    public abstract void Interact();
}
