using UnityEngine;
using TMPro;

public class HitCount : MonoBehaviour
{
    public TMP_Text text;
    private int Hitcounter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Hitcounter += 1;
            text.text = " " + Hitcounter;
            //Debug.Log("It works, delete this");
        }
    }
}
