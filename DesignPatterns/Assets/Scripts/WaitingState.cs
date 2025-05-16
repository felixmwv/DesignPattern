public class WaitingState : IWaveState
{
    private WaveManager waveManager;
    private int remainingEnemies;

    public WaitingState(WaveManager manager)
    {
        waveManager = manager;
        remainingEnemies = 3 + waveManager.CurrentWave * 2;

        EventManager.OnEnemyDeath += OnEnemyDeath;
    }

    public void Enter() { }

    public void Update()
    {
        if (remainingEnemies <= 0)
            waveManager.NextWave();
    }

    public void Exit()
    {
        EventManager.OnEnemyDeath -= OnEnemyDeath;
    }

    private void OnEnemyDeath()
    {
        remainingEnemies--;
    }
}
