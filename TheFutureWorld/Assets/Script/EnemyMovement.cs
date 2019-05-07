using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [Header("Set in Inspector")]
    public float speed = 1f;
    // Use this for initialization
    public int directionCode = 1; //1 is +x, 2 is -x, 3 is +z, 4 is -z.
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
        if(other.tag == "MovePosX")//X is direction code 1
        {
            if(directionCode == 1)
            {
                print("Already going +x");
            }

            else if(directionCode == 2)
            {
                this.transform.Rotate(0, 180, 0, Space.Self);
            }
            else if (directionCode == 3)
            {
                this.transform.Rotate(0, -90, 0, Space.Self);
                //-90 is +x to +z. "Positive is clockwise."
            } 
            else if (directionCode == 4)
            {
                this.transform.Rotate(0, 90, 0, Space.Self);
            }
            directionCode = 1;
        }
        else if(other.tag == "MoveNegX")//-X is direction code 2
        {
            if (directionCode == 1)
            {
                this.transform.Rotate(0, 180, 0, Space.Self);
            }

            else if (directionCode == 2)
            {
                print("Already going -x");
            }
            else if (directionCode == 3)
            {
                this.transform.Rotate(0, 90, 0, Space.Self);//
            }
            else if (directionCode == 4)
            {
                this.transform.Rotate(0, -90, 0, Space.Self);
            }
            directionCode = 2;
        }
        else if(other.tag == "MovePosZ")//Z is direction code 3
        {
            if (directionCode == 1)
            {
                this.transform.Rotate(0,-90,0,Space.Self);
                //rotateRobot(90);
            }

            else if (directionCode == 2)
            {
                this.transform.Rotate(0, 90, 0, Space.Self);
            }
            else if (directionCode == 3)
            {
                print("Already going +z");
            }
            else if (directionCode == 4)
            {
                this.transform.Rotate(0, 180, 0, Space.Self);
            }
            directionCode = 3;
        }
        else if(other.tag == "MoveNegZ")//-Z is direction code 4.
        {
            if (directionCode == 1)
            {
               this.transform.Rotate(0,-90,0,Space.Self);
            }

            else if (directionCode == 2)
            {
                this.transform.Rotate(0, 90, 0, Space.Self);
            }
            else if (directionCode == 3)
            {
                this.transform.Rotate(0, -180, 0, Space.Self);
            }
            else if (directionCode == 4)
            {
                print("Already going -z");
            }
            directionCode = 4;
        }
        lastTriggerGo = go;
        //changeDirection();
        //this.transform.Rotate(0, -90, 0, Space.Self);
        print("Should have triggered");
    }

    void Move()
    {
        Vector3 pos = transform.position;
        if (directionCode == 1)
        {
            pos.x += speed * Time.deltaTime;
        }
        else if (directionCode == 3)
        {
            pos.z += speed * Time.deltaTime;
        }
        else if (directionCode == 2)
        {
            pos.x -= speed * Time.deltaTime;
        }
        else if (directionCode == 4)
        {
            pos.z -= speed * Time.deltaTime;
        }
         transform.position = pos;
    }

    void changeDirection()
    {
        if(directionCode == 1)
        {
            directionCode = 2;
        }
        else if(directionCode == 2)
        {
            directionCode = 3;
        }
        else if(directionCode == 3)
        {
            directionCode = 4;
        }
        else if(directionCode == 4)
        {
            directionCode = 1;
        }
    }

    void rotateRobot(int x)
    {
        for(int i = 0; i< x; i++)
        {
            this.transform.Rotate(0, i, 0, Space.Self);
        }
    }
}
