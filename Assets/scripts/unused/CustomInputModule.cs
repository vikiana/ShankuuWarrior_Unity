using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//EXPERIMENT TO ADD CUSTOM COMPONENT 
[AddComponentMenu("Custom Input Module")]
public class CustomInputModule : PointerInputModule {

    public override void Process()
    {
        //throw new NotImplementedException();
        //WHAT TO PUT HERE?
    }

    protected void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released)
    {
        processClickTouch(pointerEvent, pressed, released);
    }

    protected void ProcessClickPress(PointerEventData pointerEvent, bool pressed, bool released)
    {
        processClickTouch(pointerEvent, pressed, released);
    }


    void processClickTouch(PointerEventData pointerEvent, bool pressed, bool released)
    {
        Debug.Log("Clicked" + pointerEvent.delta.x + ", " + pointerEvent.delta.y);
    }

}
