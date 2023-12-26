using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] UIManager ui;
    [SerializeField] int gold;
    [SerializeField] int goldToWin;
    [SerializeField] int lives;
    [SerializeField] int maxLives;
    public int Gold { 
        get { return gold; } 
        set { gold = value; ui.SetGold(Gold); if (gold >= goldToWin) Victory(); } 
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
        Time.timeScale = 0;
        SetMenu();
        ui.SetDefeatUI();
    }

    void Victory()
    {
        Time.timeScale = 0;
        SetMenu();
        ui.SetVictoryUI();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetMenu()
    {
        ui.SetMenu();
    }

    public void SetUIHelp()
    {
        ui.SetHelp();
    }

    public UIManager GetUI() => ui;
}
