using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [Header("Set in Inspector")]
    public float speed = 1f;
    // Use this for initialization
    private int directionCode = 1; //1 is +x, 2 is -x, 3 is +z, 4 is -z.
    private GameObject lastTriggerGo = null;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
         
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
        changeDirection();
        this.transform.Rotate(0, -90, 0, Space.Self);
        print("Should have triggered");
    }

    void Move()
    {
        Vector3 pos = transform.position;
        if (directionCode == 1)
        {
            pos.x += speed * Time.deltaTime;
        }
        else if (directionCode == 2)
        {
            pos.z += speed * Time.deltaTime;
        }
         transform.position = pos;
    }

    void changeDirection()
    {
        if(directionCode == 1)
        {
            directionCode = 2;
        }
    }
}
