using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {
    static public Main S;
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

    public void DelayedRestart(float delay)
    {
        Invoke("Restart", delay);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Demo");
    }

}
