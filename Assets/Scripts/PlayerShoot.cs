using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShoot : MonoBehaviour
{
    //Shoot using Mouse
    public GameObject bulletprefab;
    public float speed = 50.0f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot() {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shootDirection = (mousePosition - transform.position).normalized;
        GameObject bullet = Instantiate(bulletprefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2 (shootDirection.x, shootDirection.y) * speed;
        //transform.position += transform.right * Time.deltaTime * speed;

        Destroy(bullet, 4f);
    }
}
