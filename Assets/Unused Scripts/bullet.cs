using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collission)
    {
        //Enemy enemy = collission.GetComponent<Enemy>();
        if (collission.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("Dead");
        }
    }

    


}
