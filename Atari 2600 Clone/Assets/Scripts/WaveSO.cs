using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave", fileName = "New Wave")]
public class WaveSO : ScriptableObject
{
    [Header("Refrences")]
    [SerializeField] List<GameObject> enemyPrefab;
    [SerializeField] Transform pathPrefab;
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float timeBetweenEnemySpawnsMin = 1f;
    [SerializeField] float timeBetweenEnemySpawnsMax = 2f;

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0).transform;
    }
    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public int GetEnemyCount()
    {
        return enemyPrefab.Count;
    }
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefab[index];
    }
    public float GetRandomSpawnTime()
    {
        float temporary = Random.Range(timeBetweenEnemySpawnsMin, timeBetweenEnemySpawnsMax);
        return temporary;
    }

}
