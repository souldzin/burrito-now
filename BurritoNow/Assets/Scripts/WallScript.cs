﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Start!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            collision.gameObject.SendMessage("Die");
        }
    }
}
