using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] private Transform destination;
    //Go to destination
    public Transform GetDestination()
    {
        return destination;
    }

}
