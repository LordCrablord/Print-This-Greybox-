using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool isPlayerNear = false;
    protected Collider playerCollider;
    protected virtual void Update()
    {
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact(playerCollider.GetComponent<PlayerManager>());
            }
        }
    }

    protected virtual void Interact(PlayerManager playerManager)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerManager>() == null) return;
        isPlayerNear = true;
        playerCollider = other;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerManager>() == null) return;
        isPlayerNear = false;
        playerCollider = null;
    }
}
