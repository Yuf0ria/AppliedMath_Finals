using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MenuCtrl : MonoBehaviour
{
    //GameObjects
    public GameObject StartMenu, Game, Pause, Countdown;
    public static bool gameIsPaused;
    public static bool load;
    //void Start()
    //{
    //    if (Istart == true) {
    //        StartMenu.SetActive(true);
    //        Game.SetActive(false);
    //        Pause.SetActive(false);
    //        Countdown.SetActive(false);
    //        Istart = false;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
        //Keyboard Ctrls
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
        if (load == false)
        {
            StartMenu.SetActive(false);
            Game.SetActive(true);
            Countdown.SetActive(true);
            Pause.SetActive(true);
            load = false;
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

    public void StartClick()
    {
        Game.SetActive(true);
        Countdown.SetActive(true);
        StartMenu.SetActive(false);
    }

    public void ExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }


    public void ResetGame()
    {
        load = true;
        if(load == true)
        {
            load = false;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
