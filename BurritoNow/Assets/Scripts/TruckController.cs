using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour {
    private TruckScript _script;

	// Use this for initialization
	void Start () {
        _script = GetComponent<TruckScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _script.ShootBurrito();
        }        
	}
}
