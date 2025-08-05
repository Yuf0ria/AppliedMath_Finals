using UnityEngine;
using TMPro;

public class HitCount : MonoBehaviour
{
    public TMP_Text text, gameover;
    private TagHandle gameOverScreen;
    
    
    private int Hitcounter = 0;
    private int hitCount = 0;


    public void OnEnable()
    {
        gameOverScreen = TagHandle.GetExistingTag("GameOver");
        gameover.text = "Total Neighbors Hit " + hitCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Hitcounter += 1;
            text.text = " " + Hitcounter;
            //Debug.Log("It works, delete this");
            hitCount = Hitcounter;
        }
    }


}
