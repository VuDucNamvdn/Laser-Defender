using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig wave;
    List<Transform> waypoints;
    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = wave.getWayPoint();
        transform.position = waypoints[waypointIndex].transform.position;
        waypointIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        if (waypointIndex < waypoints.Count)
        {
            var targetPos = waypoints[waypointIndex].transform.position;
            var moveThisFrame = wave.getMoveSpeed() * Time.deltaTime;
            //Debug.Log((targetPos - transform.position) * moveThisTime);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveThisFrame);
            if (transform.position == targetPos)
                waypointIndex++;
        }
        else
            Destroy(gameObject);
    }

    public void SetWaveConfig(WaveConfig wc)
    {
        wave = wc;
    }
}
