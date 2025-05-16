using System;

public static class EventManager
{
    public static Action OnEnemyDeath;

    public static void EnemyDied()
    {
        OnEnemyDeath?.Invoke();
    }

    public static Action<int> OnWaveChanged;

    public static void WaveChanged(int newWave)
    {
        OnWaveChanged?.Invoke(newWave);
    }

}
