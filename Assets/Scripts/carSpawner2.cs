using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner2 : MonoBehaviour {
    public GameObject [] cars;
    int carNo;
    public float maxPos= 1.6f;
    public float delayTimer = .5f;
    float timer;
	// Use this for initialization
	void Start () {
        timer = delayTimer;
        
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 carPos = new Vector3(Random.Range(-1.6f, 1.6f), transform.position.y, transform.position.z);
            carNo = Random.Range(0, 6);
            Instantiate(cars[carNo], carPos, transform.rotation);

            timer = delayTimer;
        }

        


    }
}
