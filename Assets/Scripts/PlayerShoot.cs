using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //Shoot using Mouse
    public GameObject breadprefab;
    public float bulletSpeed = 50f;
    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        //MousePos
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 ShootDirection = (mousePos - transform.position).normalized; // gets direction from player to mouse

        GameObject bullet = Instantiate(breadprefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(ShootDirection.x, ShootDirection.y) * bulletSpeed;


    }
}
