using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="EWave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactors = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject getEnemy()
    {
        return enemyPrefab;
    }
    public List<Transform> getWayPoint()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform t in pathPrefab.transform)
            waypoints.Add(t);
        return waypoints;
    }
    public float getDeltaTimeSpawns()
    {
        return timeBetweenSpawns;
    }
    public float getSpawnRandomFactor()
    {
        return spawnRandomFactors;
    }
    public float getMoveSpeed()
    {
        return moveSpeed;
    }
    public int getNumberOfEnemies()
    {
        return numberOfEnemies;
    }

}
