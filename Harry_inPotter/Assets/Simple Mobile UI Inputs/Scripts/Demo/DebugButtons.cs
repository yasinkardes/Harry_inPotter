using UI_InputSystem.Base;
using UnityEngine;

public class DebugButtons : MonoBehaviour
{
    public Stick myStick;

    private void OnEnable()
    {
        UIInputSystem.ME.AddOnClickEvent(ButtonAction.OnClickEventTrigger, OnClickProcessor);
        UIInputSystem.ME.AddOnTouchEvent(ButtonAction.OnTouchEventTrigger, OnTouchProcessor);
    }

    private void OnDisable()
    {
        UIInputSystem.ME.RemoveOnClickEvent(ButtonAction.OnClickEventTrigger, OnClickProcessor);
        UIInputSystem.ME.RemoveOnTouchEvent(ButtonAction.OnTouchEventTrigger, OnTouchProcessor);
    }

    private void FixedUpdate()
    {
        if (UIInputSystem.ME.GetButton(ButtonAction.ClickTrigger))
        {
            
        }
            //DebugText("Click Input: TRIGGERED!");

        //hold
        if (UIInputSystem.ME.GetButton(ButtonAction.HoldTrigger))
        {
            myStick.Naber();
        }
            //DebugText("Holding Input: TRIGGERED!");

        //touch button
        if (UIInputSystem.ME.GetButton(ButtonAction.TouchTrigger))
        {
            
        }
                //DebugText("Touch Input: TRIGGERED!");
    }
    
    private void OnClickProcessor()
    {
        DebugText("Triggered OnClickEvent!");
    }

    private void OnTouchProcessor()
    {
        DebugText("Triggered OnTouchEvent!");
    }
    
    private void DebugText(string textToDebug)
    {
        Debug.Log(textToDebug);
    }
}