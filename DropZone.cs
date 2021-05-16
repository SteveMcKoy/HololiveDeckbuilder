using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler 
{
    public Draggable.ZoneType zoneType = Draggable.ZoneType.ATTACK;
    public Draggable.ZoneType secondaryZoneType = Draggable.ZoneType.STATUS;// Declares Zone Type

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Pointer enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Pointer exit");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped to " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if (((zoneType == d.cardType) || (secondaryZoneType == d.cardType)) || zoneType == Draggable.ZoneType.HAND) // Sees if card type and zone type match
            {
                d.returnParent = this.transform;
            }     
        }
    }
}
