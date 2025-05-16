using UnityEngine;

public class ZombieDebugControls : MonoBehaviour
{
    public EnemyPool enemyPool; // Reference to the pool of zombie enemies

    public void KillFirstAliveZombie()
    {
        foreach (GameObject obj in enemyPool.GetPool())
        {
            if (obj.activeInHierarchy) // Check if the zombie is active
            {
                Zombie zombie = obj.GetComponent<Zombie>();
                if (zombie != null)
                {
                    zombie.Die(); // Kill the first active zombie
                    return;
                }
            }
        }

        Debug.LogWarning("No alive zombie found."); // Warn if no active zombies are found
    }
}
