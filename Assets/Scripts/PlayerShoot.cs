using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //Shoot using Mouse
    public GameObject breadprefab;
    //public Transform shootingPoint; //enemy
    public float bulletSpeed = 50f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))//Left Click;
        {
            Shoot();
        }
    }
    void Shoot()
    {
        
        //MousePos
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 ShootDirection = (mousePosition - transform.position).normalized; // gets direction from player to mouse

        GameObject bullet = Instantiate(breadprefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(ShootDirection.x, ShootDirection.y) * bulletSpeed;
        Destroy(bullet, 2f);
    }
}
