using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DK_ScoreScript : MonoBehaviour
{
    public int score=0;
    public TMP_Text currentScore;
    public int lives=3;
    public TMP_Text currentLives;
    public int round=1;
    public TMP_Text currentRound;
    public AudioSource scoreNoise;
    public AudioSource swordScoreNoise;
    public TMP_Text currentHighScore;
    public int highScore = 0;
    public float throwSpeed;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        TMP_Text[] textBoxes = FindObjectsOfType<TMP_Text>();
        for(int i = 0; i < textBoxes.Length; i++)
        {
            if(textBoxes[i].name == "Score")
            {
                currentScore = textBoxes[i];
            }
            if(textBoxes[i].name == "Round")
            {
                currentRound = textBoxes[i];
            }
            if(textBoxes[i].name == "Lives")
            {
                currentLives = textBoxes[i];
            }
            if (textBoxes[i].name == "HighScore")
            {
                currentHighScore = textBoxes[i];
            }
        }
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        for(int j=0; j < audioSources.Length; j++)
        {
            if(audioSources[j].name == "BarrelJump")
            {
                scoreNoise = audioSources[j];
            }
            if(audioSources[j].name == "BarrelBroken")
            {
                swordScoreNoise = audioSources[j];
            }
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        //Updates TMP text with updated score and lives counter
        currentScore.text = string.Format("Score: " + score);
        currentLives.text = string.Format("Lives: " + lives);
        currentRound.text = string.Format("Round: " + round);
        if(currentHighScore != null)
        {
            currentHighScore.text = string.Format("High Score: " + PlayerPrefs.GetInt("HighScore"));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void ScoreJump()
    {
        score += 100;
        scoreNoise.Play();

    }

    public void ScoreSword()
    {
        score += 200;
        swordScoreNoise.Play();
    }

    public void LoseLife()
    {
        lives--;
    }

    public void NextRound()
    {
        round++;
        throwSpeed = throwSpeed *0.9f;
    }

    public void SetHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
