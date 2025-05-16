using UnityEngine;

public class SpawningState : IWaveState
{
    private WaveManager waveManager;
    private EnemyPool enemyPool;

    private int enemiesToSpawn;
    private float spawnCooldown = 1f;
    private float timer;

    public SpawningState(WaveManager manager, EnemyPool pool, int waveNumber)
    {
        waveManager = manager;
        enemyPool = pool;

        // Calculate the number of enemies to spawn based on the wave number
        enemiesToSpawn = 3 + waveNumber * 2;
    }

    public void Enter()
    {
        timer = spawnCooldown; // Initialize the spawn timer
    }

    public void Update()
    {
        timer -= Time.deltaTime;

        // Spawn an enemy if the timer reaches zero and there are enemies left to spawn
        if (timer <= 0f && enemiesToSpawn > 0)
        {
            enemyPool.SpawnEnemy(Vector3.zero);
            enemiesToSpawn--;
            timer = spawnCooldown; // Reset the timer
        }

        // Transition to the WaitingState when all enemies are spawned
        if (enemiesToSpawn <= 0)
        {
            waveManager.SetState(new WaitingState(waveManager));
        }
    }

    public void Exit() { }
}
