﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandGripSelectall : MonoBehaviour {



    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId touchpad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
    private Valve.VR.EVRButtonId MenuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;
    private Valve.VR.EVRButtonId Abutton = Valve.VR.EVRButtonId.k_EButton_A;
    private LineRenderer lineren;
    [HideInInspector]
    public List<GameObject> selectedships = new List<GameObject>();                                                  // Initialization
    private GameObject MenuObj;
    public Material linemat;
    private GameObject ConeBig;
    private GameObject ConeSmall;
    public bool touchpadDown;
    private int selectioncount;
    public bool triggerdown;
    public bool touchpaddownonce;

    private TestCaseController testcontrol;
    private Resizescript resizing;


    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();                                                          // establish tracking
        lineren = gameObject.AddComponent<LineRenderer>();
        resizing = transform.parent.parent.GetComponent<Resizescript>();
        testcontrol = transform.parent.parent.GetComponent<TestCaseController>();
        lineren.startWidth = 0.01f;
        lineren.endWidth = 0.01f;
        lineren.enabled = false;
        lineren.material = linemat;
        MenuObj = transform.Find("ControllerMenuMinimap").gameObject;
        MenuObj.SetActive(false);
        ConeBig = transform.Find("ConeBig").gameObject;
        ConeBig.SetActive(false);
        ConeSmall = transform.Find("ConeSmall").gameObject;
        ConeSmall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (lineren.enabled == true)
        {
            lineren.SetPosition(0, transform.position);
            lineren.SetPosition(1, transform.position + transform.forward * 1000);      // linemanipulation
        }

        if (controller.GetPressDown(touchpad)) Touchpaddown();

        if (controller.GetPressUp(touchpad)) Touchpadup();

        if (controller.GetPressDown(MenuButton)) Menu();                         //inputcalls

        if (controller.GetPressDown(triggerButton) && touchpadDown == false) Trigger();

        if (controller.GetPressUp(triggerButton)) TriggerUp();

        if (controller.GetPressDown(gripButton)) grip();

        if (touchpadDown == true && controller.GetPressDown(triggerButton)) triggerwhiletouchpad();
        touchpaddownonce = controller.GetPressDown(touchpad);
    }
    void Touchpaddown()
    {



    }
    void Touchpadup()
    {

    }

    void triggerwhiletouchpad()
    {

    }



    void Trigger()
    {
        Debug.Log("move");
        triggerdown = true;
    }
    void TriggerUp()
    {
        triggerdown = false;
    }

    void grip()
    {
        GameObject root = GameObject.Find("World").transform.Find("Objects").Find("Working").gameObject;
        foreach (Transform i in root.transform)
        { 
            addtolist(i.gameObject);
        }
    }

    void Menu()
    {

    }
    void addtolist(GameObject col)
    {
        if (col.transform.parent != null && selectedships.Contains(col) == false && col.transform.parent.name == "Working")
        {
            selectedships.Add(col);
            Debug.Log(col);
            col.GetComponent<Selection_Controller>().enable();

        }
    }
}