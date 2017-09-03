using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

    private static GameManager instance;

    private int _lives { get; set; }
    private int _points { get; set; }
    private int _burritos { get; set; }

    public int Lives {
        get
        {
            return _lives;
        }
    }

    public int Points {
        get
        {
            return _points;
        }
    }

    public int Burritos
    {
        get
        {
            return _burritos;
        }
    }

    private GameManager()
    {
        _lives = 3;
        _points = 0;
        _burritos = 10;
    }

    public void AddPoint()
    {
        _points += 1;
        Debug.Log("You got a point. Total points are: " + _points);
    }

    public void AddBurritos(int count)
    {
        _burritos += count;
    }

    public void SubtractBurrito()
    {
        _burritos -= 1;
    }

    public void SubtractLife()
    {
        _lives -= 1;
    }

	public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }
}
