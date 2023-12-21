using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] UIManager ui;
    int gold = 15;
    public int Gold { 
        get { return gold; } 
        set { gold = value; ui.SetGold(Gold); } 
    }

    private void Start()
    {
        ui.SetGold(Gold);
    }
}
