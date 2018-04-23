using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColliderChecker : MonoBehaviour {
    private bool isColliding = false;
    public bool getIsColliding()
    {
        return isColliding;
    }
    private void OnTriggerStay(Collider other)
    {
        isColliding = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
