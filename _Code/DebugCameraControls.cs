﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCameraControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E)) transform.rotation = transform.rotation * Quaternion.Euler(0, 10, 0);
        if (Input.GetKeyDown(KeyCode.Q)) transform.rotation = transform.rotation * Quaternion.Inverse( Quaternion.Euler(0, 10, 0));
        if (Input.GetKeyDown(KeyCode.W)) transform.position = transform.position + 5 * transform.forward;
        if (Input.GetKeyDown(KeyCode.DownArrow)) transform.rotation = transform.rotation * Quaternion.Inverse(Quaternion.Euler(-10,0, 0));
        if (Input.GetKeyDown(KeyCode.UpArrow)) transform.position = transform.position + 5 * Vector3.up;
    }
}
