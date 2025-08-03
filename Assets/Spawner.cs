using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Variables, Serializing just in case I have time to create a save or load option
    [SerializeField] GameObject Spawned; 
    [SerializeField] GameObject[] tilesprefab;
    //size of the spawnBox;
    [SerializeField] float X = 1f, Y = 1f;
    //Sereperate float for the cooldown
    [SerializeField] float Cooldown = 10f;
    private float spawnTime;
    void Start()
    {
        spawnTime = Cooldown;
    }

    void Update()
    {
        if (spawnTime > 0) spawnTime -= Time.deltaTime;

        if(spawnTime <= 0)
        {
            Spawn();
            spawnTime = Cooldown;
        }
    }

    void Spawn()
    {
        float xPos = Random.Range(-X, X) + transform.position.x;
        float yPos = Random.Range(-Y, Y) + transform.position.y;

        Vector3 spawnPosition = new Vector3(xPos, yPos, 0);
        Instantiate(Spawned, spawnPosition, Quaternion.identity);
    }
}
