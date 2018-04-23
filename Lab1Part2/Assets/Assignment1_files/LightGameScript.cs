using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGameScript : MonoBehaviour {
    public List<GameObject> boxColliders;
    public List<GameObject> lights;
    public GameObject textScore;
    public static float DEFAULT_COUNTDOWN = 5.0f;
    public float countdown = DEFAULT_COUNTDOWN;
    public int curLight = 0;
    public int score = 0;
    public System.Random rnd = new System.Random();

    public void setUpNextLight()
    {
        lights[curLight].GetComponent<Light>().enabled = false;
        incrementCurLight();
        lights[curLight].GetComponent<Light>().enabled = true;
        countdown = DEFAULT_COUNTDOWN;
    }

    public void incrementCurLight()
    {
        int newLight = rnd.Next(0, lights.Count - 1);
        while(newLight == curLight)
        {
            newLight = rnd.Next(0, lights.Count - 1);
        }
        curLight = newLight;
    }

    // Use this for initialization
    void Start () {
		for(int i = 0; i < lights.Count; i++)
        {
            lights[i].GetComponent<Light>().enabled = false; 
        }
	}

    void lightLogic()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0.0f)
        {
            setUpNextLight();
        }
    }
    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        OVRInput.FixedUpdate();
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            if (!Application.isEditor)
            {
                Application.Quit();
            }
        }
        if (OVRInput.GetDown(OVRInput.Touch.One)){
            if (boxColliders[curLight].GetComponent<LightColliderChecker>().getIsColliding())
            {
                setUpNextLight();
                score++;
                textScore.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
            }
        }
        
    }
}
