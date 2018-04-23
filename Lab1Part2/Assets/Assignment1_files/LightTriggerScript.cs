using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTriggerScript : MonoBehaviour {
    public GameObject lightToTrigger;

    void OnTriggerEnter(Collider other)
    {
        Light light = lightToTrigger.GetComponent<Light>();
        light.intensity = 2;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
