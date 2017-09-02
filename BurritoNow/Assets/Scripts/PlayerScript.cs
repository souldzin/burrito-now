using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public int speed = 1;
    public Vector2 direction = Vector2.up;

    private Vector3 _initialPosition;

	// Use this for initialization
	void Start ()
    {
        _initialPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 translate = direction * speed * Time.deltaTime;

        this.transform.Translate(translate);
	}

    void Die ()
    {
        Debug.Log("You died!");
        this.transform.SetPositionAndRotation(_initialPosition, Quaternion.identity);
    }
}
