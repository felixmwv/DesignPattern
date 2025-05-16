using UnityEngine;

public class Zombie : MonoBehaviour
{
    public void Die()
    {
        Debug.Log("Zombie died.");
        EventManager.EnemyDied();
        gameObject.SetActive(false);
    }
}
