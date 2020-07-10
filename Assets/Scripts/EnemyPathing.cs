using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] WaveConfig wave;
    [SerializeField] float moveSpeed;
    List<Transform> waypoints;
    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = wave.getWatPoint();
        transform.position = waypoints[waypointIndex].transform.position;
        waypointIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        if (waypointIndex < waypoints.Count)
        {
            var targetPos = waypoints[waypointIndex].transform.position;
            var moveThisFrame = moveSpeed * Time.deltaTime;
            //Debug.Log((targetPos - transform.position) * moveThisTime);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveThisFrame);
            if (transform.position == targetPos)
                waypointIndex++;
        }
        else
            waypointIndex = 0;
    }
}
