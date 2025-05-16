using UnityEngine;

public class ZombieDebugControls : MonoBehaviour
{
    public EnemyPool enemyPool;

    public void KillFirstAliveZombie()
    {
        foreach (GameObject obj in enemyPool.GetPool())
        {
            if (obj.activeInHierarchy)
            {
                Zombie zombie = obj.GetComponent<Zombie>();

                if (zombie != null)
                {
                    zombie.Die();
                    return;
                }
            }
        }

        Debug.LogWarning("No alive zombie found.");
    }
}
