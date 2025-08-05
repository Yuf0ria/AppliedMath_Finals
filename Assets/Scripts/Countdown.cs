using UnityEngine;
using TMPro;
using System;

public class Countdown : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] float remaingTime; //serialize so it shows up
    HitCount count;
    //variables for game over screen
    public GameObject gameOverScreen;

    void Update()
    {
        //If there's still time I'll try to add a variable that adds timer if an enemy is hit
        if(remaingTime > 0)
        {
            remaingTime -= Time.deltaTime;
        }
        else if (remaingTime < 0)
        {
            remaingTime = 0;
            GameOverScreen();
        }
        int minutes = Mathf.FloorToInt(remaingTime / 60);
        int seconds = Mathf.FloorToInt(remaingTime % 60);
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    //included GameOverScreen Here
    void GameOverScreen()
    {
        SoundEffectManager.Play("GameOver");
        MusicManager.PauseBackgroundMusic();
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
