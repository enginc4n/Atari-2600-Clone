using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Player player;
    WaveSO currentWave;
    [SerializeField] List<WaveSO> listOfWaves;
    [SerializeField] float timeBetweenWaves;
    void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }
    IEnumerator SpawnEnemyWaves()
    {
        int currentIndex = 0, temporaryIndex;
        do
        {
            for (int i = 0; i < listOfWaves.Count; i++)
            {
                currentWave = listOfWaves[currentIndex];
                temporaryIndex = currentIndex;
                currentIndex = Random.Range(0, listOfWaves.Count);

                if (currentIndex == temporaryIndex)
                {
                    currentIndex = Random.Range(0, listOfWaves.Count);
                }

                else
                {
                    for (int j = 0; j < currentWave.GetEnemyCount(); j++)
                    {
                        Instantiate(currentWave.GetEnemyPrefab(j), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
                        yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                    }
                    yield return new WaitForSeconds(timeBetweenWaves);
                }

            }
        } while (!player.GetIsDead());

    }
    public WaveSO GetCurrentWave()
    {
        return currentWave;
    }
}
