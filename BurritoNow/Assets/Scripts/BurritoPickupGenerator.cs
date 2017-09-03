using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurritoPickupGenerator : MonoBehaviour {
    public GameObject burritoPickupPrefab;

    private float timeout;
    private bool isEmpty;

	// Use this for initialization
	void Start () {
        timeout = 0;
        isEmpty = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(!isEmpty)
        {
            return;
        }

        timeout -= Time.deltaTime;

        if(timeout <= 0)
        {
            Generate();
        }
	}

    public void HandleBurritoPickup()
    {
        ResetGenerator();
    }

    private void Generate()
    {
        if(this.transform.childCount <= 0)
        {
            return;
        }


        isEmpty = false;
        var position = GeneratePosition();
        var burrito = GameObject.Instantiate(burritoPickupPrefab, position, Quaternion.identity, this.transform);
    }

    private Vector3 GeneratePosition()
    {
        var count = this.transform.childCount;
        var idx = Random.Range(0, count - 1);

        return this.transform.GetChild(idx).position;
    }

    private void ResetGenerator()
    {
        // flag that we're ready to make more burritos
        this.isEmpty = true;

        // set the timeout
        timeout = Random.Range(20.0f, 40.0f);        
    }
}
