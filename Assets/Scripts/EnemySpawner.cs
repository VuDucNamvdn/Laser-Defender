using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAllWave());
    }

    private IEnumerator SpawnEnemiesInWave(WaveConfig waveConfig)
    {
        for(int i = 0; i<waveConfig.getNumberOfEnemies();i++)
        {
            yield return new WaitForSeconds(waveConfig.getDeltaTimeSpawns());
            Instantiate(waveConfig.getEnemy(), waveConfig.getWayPoint()[0].transform.position, Quaternion.identity).GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

        }
    }

    private IEnumerator SpawnAllWave()
    {
        for(int index = startingWave;index<waveConfigs.Count;index++)
        {
            WaveConfig currentWave = waveConfigs[index];
            yield return StartCoroutine(SpawnEnemiesInWave(currentWave));
        }
    }

}
