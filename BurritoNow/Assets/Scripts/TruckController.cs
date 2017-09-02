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
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _script.TurnLeft();
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            _script.TurnRight();
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("wall"))
        {
            _script.Die();
        }
    }
}