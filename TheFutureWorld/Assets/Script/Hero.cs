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



    /*void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            print("Should Destroy!");
            Destroy(S.gameObject);
        }
    }*/

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

}
