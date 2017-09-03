using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurritoPickupScript : MonoBehaviour {
    public int quantity = 10;

    private BurritoPickupGenerator _parentGenerator;

	// Use this for initialization
	void Start () {
        _parentGenerator = GetComponentInParent<BurritoPickupGenerator>();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
            GameManager.Instance.AddBurritos(10);
            Destroy(this.gameObject);
            _parentGenerator.HandleBurritoPickup();
        }
    }
}
