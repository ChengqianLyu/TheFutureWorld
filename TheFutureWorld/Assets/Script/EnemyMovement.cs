using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [Header("Set in Inspector")]
    public float speed = 1f;
    // Use this for initialization
    private GameObject lastTriggerGo = null;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

         Vector3 pos = transform.position;
         pos.x += speed * Time.deltaTime;
         transform.position = pos;
        //Check page 573.
        //transform.Translate(Vector3.forward * Time.deltaTime);
        //transform.Rotate(0, 1f, 0, Space.Self);
	}

    void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        if(go == lastTriggerGo)
        {
            return;
        }
        lastTriggerGo = go;
        this.transform.Rotate(0, 90, 0, Space.Self);
        print("Should have triggered");
    }
}
