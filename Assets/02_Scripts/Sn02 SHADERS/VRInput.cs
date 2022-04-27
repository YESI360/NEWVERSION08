using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class VRInput : BaseInput
{
    public Camera eventCamera = null;
    //VER steam vr inputs PDF
    //public SteamVR_Action_Vector2 touchAction;
    //public SteamVR_Action_Boolean boton;
    //public SteamVR_Action_Boolean_Source botoncito;
    //public SteamVR_Action_Vector3 botone;

    protected override void Awake()
    {
        base.Awake();
        GetComponent<BaseInputModule>().inputOverride = this;
    }

    //public override bool GetMouseButton(int button)
    //{
    //    return base.GetMouseButton(button);
    //}

    //public override bool GetButtonDown(string buttonName)
    //{
    //    return base.GetButtonDown(buttonName);
    //}

    //public override bool GetMouseButtonDown(int button)
    //{
    //    return base.GetMouseButtonDown(button);
    //}

    //public override bool GetMouseButtonUp(int button)
    //{
    //    return base.GetMouseButtonUp(button);
    //}

    public override Vector2 mousePosition {
        get {
            return new Vector2(eventCamera.pixelWidth / 2, eventCamera.pixelHeight / 2);
        }
    }
}
