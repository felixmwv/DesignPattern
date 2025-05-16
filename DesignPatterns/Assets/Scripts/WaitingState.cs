public class WaitingState : IWaveState
{
    private WaveManager waveManager;
    private int remainingEnemies;

    public WaitingState(WaveManager manager)
    {
        waveManager = manager;

        // Calculate the number of enemies to defeat based on the current wave
        remainingEnemies = 3 + waveManager.CurrentWave * 2;

        // Subscribe to the enemy death event
        EventManager.OnEnemyDeath += OnEnemyDeath;
    }

    public void Enter() { }

    public void Update()
    {
        // Move to the next wave if all enemies are defeated
        if (remainingEnemies <= 0)
            waveManager.NextWave();
    }

    public void Exit()
    {
        // Unsubscribe from the enemy death event to avoid memory leaks
        EventManager.OnEnemyDeath -= OnEnemyDeath;
    }

    private void OnEnemyDeath()
    {
        // Decrease the count of remaining enemies
        remainingEnemies--;
    }
}
