using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HouseState
{
    Neutral = 0,
    Hungry = 1,
    Angry = 2,
    Dead = 3
}

public class HouseScript : MonoBehaviour {

    private SpriteRenderer _spriteRenderer;
    private HouseState _state = HouseState.Neutral;
    private float health;

	// Use this for initialization
	void Start () {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        ResetHouse();
	}
	
	// Update is called once per frame
	void Update () {
        var deltaTime = Time.deltaTime;
        health -= deltaTime;

        var newHouseState = getState();
        if (newHouseState != _state)
        {
            UpdateHouseState(newHouseState);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("burrito") 
            && _state != HouseState.Dead
            && _state > HouseState.Neutral)
        {
            GameManager.Instance.AddPoint();
            ResetHouse();
        }
    }

    private void UpdateHouseState(HouseState newState)
    {
        var color = GetColor(newState);
        _spriteRenderer.color = color;
        _state = newState;
    }

    private Color32 GetColor(HouseState state)
    {
        if (state == HouseState.Angry)
        {
            return new Color32(201, 29, 18, 255);
        }

        if (state == HouseState.Dead)
        {
            return new Color32(47, 47, 47, 255);
        }

        if (state == HouseState.Hungry)
        {
            return new Color32(0, 153, 0, 255);
        }

        // Neutral
        return new Color32(255, 255, 255, 255);
    }

    private HouseState getState()
    {
        if (health <= 0)
        {
            return HouseState.Dead;
        }

        if (health <= 50)
        {
            return HouseState.Angry;
        }

        if (health <= 130)
        {
            return HouseState.Hungry;
        }

        return HouseState.Neutral;
    }


    private void ResetHouse()
    {
        var newState = HouseState.Neutral;

        _state = newState;
        _spriteRenderer.color = GetColor(newState);

        health = Random.Range(100f, 250f);
    }
}
