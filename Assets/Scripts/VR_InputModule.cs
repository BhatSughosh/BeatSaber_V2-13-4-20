using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class VR_InputModule : BaseInputModule
{
    public Camera cam;
    public SteamVR_Input_Sources targetSource;
    public SteamVR_Action_Boolean ClickAction;

    private GameObject CurrentObject = null;
    private PointerEventData data = null;

    protected override void Awake()
    {
        base.Awake();
        data = new PointerEventData(eventSystem);
    }

    public override void Process()
    {
        //Reset data, set camera
        data.Reset();
        data.position = new Vector2(cam.pixelWidth / 2, cam.pixelHeight / 2);
        //Raycast
        eventSystem.RaycastAll(data, m_RaycastResultCache);
        data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        CurrentObject = data.pointerCurrentRaycast.gameObject;
        //Clear raycast
        m_RaycastResultCache.Clear();
        //Mover
        HandlePointerExitAndEnter(data, CurrentObject);
        //press
        if (ClickAction.GetStateDown(targetSource))
            ProcessPress(data);
        //Release
        if (ClickAction.GetStateUp(targetSource))
            Processrelease(data);
    }

    public PointerEventData GetData()
    {
        return data;
    }

    private void ProcessPress(PointerEventData datas)
    {
        //Set Raycast
        datas.pointerCurrentRaycast = datas.pointerCurrentRaycast;

        // Check for object ht, get the down handler
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(CurrentObject, datas, ExecuteEvents.pointerDownHandler);

        // If no down handler, try and get the click handler
        if (newPointerPress == null)
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(CurrentObject);

        //Set data
        datas.pressPosition = datas.position;
        datas.pointerPress = newPointerPress;
        datas.rawPointerPress = CurrentObject;
    }

    private void Processrelease(PointerEventData datas)
    {
        //Execute pointerr up
        ExecuteEvents.Execute(datas.pointerPress, datas, ExecuteEvents.pointerUpHandler);

        //Check for click handler
        GameObject pointerUpHandler= ExecuteEvents.GetEventHandler<IPointerClickHandler>(CurrentObject);

        //check if actual
        if(datas.pointerPress==pointerUpHandler)
        {
            ExecuteEvents.Execute(datas.pointerPress, datas, ExecuteEvents.pointerClickHandler);
        }

        //Clear selected gameobject
        eventSystem.SetSelectedGameObject(null);

        //Reset data
        datas.pressPosition = Vector2.zero;
        datas.pointerPress = null;
        datas.rawPointerPress = null;
    }
}
