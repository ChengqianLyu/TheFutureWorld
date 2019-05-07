using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    static public Hero S;
	// Use this for initialization
	void Start () {
        if(S == null)
        {
            S = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            print("Should Destroy!");
            Destroy(S);
        }
    }
}
