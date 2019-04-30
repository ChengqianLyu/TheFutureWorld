using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.Rotate(0, 90, 0, Space.Self);
    }
}
