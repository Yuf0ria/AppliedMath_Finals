using UnityEngine;

public class PauseCtrl : MonoBehaviour
{
    public static bool isGamePaused { get; private set; } = false;
    
    public static void SetPause(bool pause)
    {
        isGamePaused = pause;
    }


}
