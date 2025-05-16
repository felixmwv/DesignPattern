using UnityEngine;

public class Zombie : MonoBehaviour
{
    public void Die()
    {
        Debug.Log("Zombie died."); // Log the zombie's death

        EventManager.EnemyDied(); // Notify other systems of the zombie's death

        gameObject.SetActive(false); // Deactivate the zombie
    }
}
