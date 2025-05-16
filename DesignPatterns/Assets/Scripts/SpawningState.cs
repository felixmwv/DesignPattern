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
        enemiesToSpawn = 3 + waveNumber * 2;
    }

    public void Enter()
    {
        timer = spawnCooldown;
    }

    public void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f && enemiesToSpawn > 0)
        {
            enemyPool.SpawnEnemy(Vector3.zero);
            enemiesToSpawn--;
            timer = spawnCooldown;
        }

        if (enemiesToSpawn <= 0)
        {
            waveManager.SetState(new WaitingState(waveManager));
        }
    }

    public void Exit() { }
}
