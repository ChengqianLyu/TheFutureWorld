﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    static public Hero S;
    public float gameRestartDelay = 2f;
    // Use this for initialization
    void Start () {
        if(S == null)
        {
            S = this;
        }
	}



    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Main.S.DelayedRestart(gameRestartDelay);
        }
    }

}
