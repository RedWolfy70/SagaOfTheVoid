﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSettingsScript : MonoBehaviour {

    private GameObject galaxy;
    private bool isup;
    private Vector3 startpos;
    private Vector3 startposme;
    private GameObject parent;
    // Use this for initialization
    void Start()
    {


        galaxy = GameObject.Find("Controllers");
        startpos = transform.parent.localPosition;
        startposme = transform.position;
        parent = transform.parent.gameObject;
        // transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (parent)
        {
            if (isup = false)
            {
                //  transform.position = parent.transform.position;
            }
            if (isup == false) parent.transform.localPosition = startpos;
            else parent.transform.localPosition = startpos + new Vector3(0, 0.01f, 0);
            isup = false;
            //transform.position = startposme;


        }

    }
    void Load()
    {
        galaxy.GetComponent<GalaxyController>().settingsscaleup();  // Yes yes this is kinda in-efficiant
        Debug.Log("scaleup");
    }

    void up()
    {
        isup = true;
        Debug.Log(isup);
    }

}