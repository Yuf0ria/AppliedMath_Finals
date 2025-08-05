using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MenuCtrl : MonoBehaviour
{
    //GameObjects
    public GameObject StartMenu, Game, Pause, Countdown;
    public static bool gameIsPaused;

    // Update is called once per frame
    void Update()
    {
        
        //Keyboard Ctrls
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            SoundEffectManager.Play("Pause");
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            Pause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            Pause.SetActive(false);
        }
    }

    public void PauseOnClick()//Clicking ContinueBTN
    {
        Time.timeScale = 1;
        SoundEffectManager.Play("Pause");
        Pause.SetActive(false);
    }

    public void StartClick()
    {
        SoundEffectManager.Play("Start");
        Game.SetActive(true);
        Countdown.SetActive(true);
        StartMenu.SetActive(false);
    }

    public void ExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        SoundEffectManager.Play("Exit");
        Application.Quit();
    }


    public void ResetGame()
    {
        SoundEffectManager.Play("Restart");
        MusicManager.PlayBackgroundMusic(true);
        SceneManager.LoadScene("SampleScene");
    }
}
