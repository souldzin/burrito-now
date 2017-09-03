using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurritoScript : MonoBehaviour {
    public Vector3 velocity = new Vector2(0.0f, 0.0f);

    private Vector3 _initialVelocity;
	// Use this for initialization
	void Start () {
        Initialize(velocity);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(this.velocity * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("burrito-wall"))
        {
            Die();            
        }
    }

    public void Initialize(Vector2 velocity)
    {
        this.velocity = velocity;
        _initialVelocity = velocity;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
