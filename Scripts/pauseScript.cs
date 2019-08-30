using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour {

    public void triggerPause(bool isPause)
    {
        if (isPause == false)
        {
            isPause = true;
        }
        else
        {
            isPause = false;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
