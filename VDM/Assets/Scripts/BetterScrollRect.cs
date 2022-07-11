using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BetterScrollRect : ScrollRect
{
    public bool disableDragging;

    public override void OnBeginDrag(PointerEventData eventData) { 
        if (!disableDragging)
            base.OnBeginDrag(eventData);
    }
    public override void OnDrag(PointerEventData eventData) { 
        if (!disableDragging)
            base.OnDrag(eventData);
    }
    public override void OnEndDrag(PointerEventData eventData) { 
        if (!disableDragging)
            base.OnEndDrag(eventData);
    }
    
}
