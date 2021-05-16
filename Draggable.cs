using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform returnParent;

    // This section decides which types of cards can go where.
    public enum ZoneType { ATTACK, DEFENSE, STATUS, DOMAIN, HAND };
    public ZoneType cardType = ZoneType.HAND; // Declares card type

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("On begin drag");

        returnParent = this.transform.parent;
        this.transform.SetParent(this.transform.root); // Takes the card out of the hand when we start dragging

        GetComponent<CanvasGroup>().blocksRaycasts = false; // The card normally blocks the raycast of the pointer while being dragged
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("On drag");

        this.transform.position = eventData.position; // Makes the card follow the mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("On end drag");
        this.transform.SetParent(returnParent); // Returns the card to hand
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
