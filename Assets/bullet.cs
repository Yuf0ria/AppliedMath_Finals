using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDmg = 1;

    private void OnTriggerEnter2D(Collider2D collission)
    {
        Enemy enemy = collission.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(bulletDmg);
            Destroy(gameObject);
        }
    }

    


}
