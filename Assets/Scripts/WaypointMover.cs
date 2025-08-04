using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    public Transform waypointParent;
    public float moveSpeed = 2f;
    public float waitTime = 2f;
    public bool loopWayPoints = true;

    private Transform[] waypoints;
    private int currentWayPointIndex;
    private bool isWaiting;

    void Start()
    {
        waypoints = new Transform[waypointParent.childCount];
        for (int i = 0; i < waypointParent.childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }
    }

    void Update()
    {
        // if (PauseController.IsGamePause || isWaiting)
        // {
        //     return; //stops when paused
        // } 
        MoveToWayPoint();
    }

    void MoveToWayPoint()
    {
        Transform target = waypoints[currentWayPointIndex];

        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        currentWayPointIndex = loopWayPoints ? (currentWayPointIndex + 1) % waypoints.Length : Mathf.Min(currentWayPointIndex + 1, waypoints.Length - 1);

        isWaiting = false;
    }
}
