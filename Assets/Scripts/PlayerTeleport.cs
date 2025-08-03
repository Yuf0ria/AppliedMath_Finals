using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    //Detects current Teleport Tile.
    private GameObject currentTeleporter;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(currentTeleporter != null)
            {
                //Gets Script and position
                transform.position = currentTeleporter.GetComponent<Teleportation>().GetDestination().position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks Compare Tag
        if (collision.CompareTag("Teleporter")){
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
