using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab for the enemy
    public int poolSize = 10; // Number of enemies in the pool

    private List<GameObject> pool = new List<GameObject>(); // List to hold pooled enemies

    private void Awake()
    {
        // Create and deactivate enemies to populate the pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject SpawnEnemy(Vector3 position)
    {
        // Find and activate an inactive enemy
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.transform.position = position;
                obj.SetActive(true);
                return obj;
            }
        }

        Debug.LogWarning("Pool exhausted!"); // Warn if no enemies are available
        return null;
    }

    public List<GameObject> GetPool()
    {
        return pool; // Return the list of pooled enemies
    }
}
