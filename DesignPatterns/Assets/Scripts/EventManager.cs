using System;

public static class EventManager
{
    public static Action OnEnemyDeath; // Triggered when an enemy dies

    public static void EnemyDied()
    {
        OnEnemyDeath?.Invoke(); // Notify listeners of enemy death
    }

    public static Action<int> OnWaveChanged; // Triggered when the wave changes

    public static void WaveChanged(int newWave)
    {
        OnWaveChanged?.Invoke(newWave); // Notify listeners of the new wave
    }
}
