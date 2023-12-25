using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] UIManager ui;
    [SerializeField] int gold;
    [SerializeField] int lives;
    [SerializeField] int maxLives;
    public int Gold { 
        get { return gold; } 
        set { gold = value; ui.SetGold(Gold); } 
    }

    public int Lives
    {
        get { return lives; }
        set { lives = value; ui.SetLives(lives); if (lives <= 0) GameOver(); }
    }

    public int MaxLives { get { return maxLives; } set { maxLives = value; } }

    private void Start()
    {
        ui.SetGold(Gold);
        ui.SetLives(Lives);
    }

    void GameOver()
    {

    }
}
