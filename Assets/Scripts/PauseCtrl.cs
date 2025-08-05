using UnityEngine;

public class PauseCtrl : MonoBehaviour
{
    //GameObjects
    public GameObject StartMenu, Game, Pause, Countdown;
    public static bool gameIsPaused;
    void Start()
    {
        StartMenu.SetActive(true);
        Game.SetActive(false);
        Pause.SetActive(false);
        Countdown.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Keyboard Ctrls
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            Pause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
        }
    }

}
