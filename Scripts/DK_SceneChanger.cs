using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DK_SceneChanger : MonoBehaviour
{
    public SceneLoader loader;
    public DK_ScoreScript game;

    private void Awake()
    {
        game = FindObjectOfType<DK_ScoreScript>();   
    }

    public void GoToMainScene()
    {
        loader.LoadSceneName("DK_MainScene");
    }

    public void MainMenu()
    {
        loader.LoadSceneName("DK_OpeningScene");
    }

    public void GameOver()
    {
        loader.LoadSceneName("DK_GameOver");
        game.lives = 3;
        game.round = 1;
        game.score = 0;
        game.throwSpeed = 4f;
    }
    public void GameWin()
    {
        loader.LoadSceneName("DK_WinScene");
        game.lives = 3;
        game.round = 1;
        game.score = 0;
        game.throwSpeed = 4f;
    }
    public void NextLevel()
    {
        loader.LoadSceneName("DK_NextLevel");
    }
}
