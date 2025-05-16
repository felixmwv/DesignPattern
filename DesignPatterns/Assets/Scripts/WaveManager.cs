using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private IWaveState currentState;

    public EnemyPool enemyPool;

    public int CurrentWave { get; private set; } = 1;

    private void Start()
    {
        // Notify listeners of the initial wave and start spawning enemies
        EventManager.WaveChanged(CurrentWave);
        SetState(new SpawningState(this, enemyPool, CurrentWave));
    }

    private void Update()
    {
        currentState?.Update(); // Update the current state
    }

    public void SetState(IWaveState newState)
    {
        currentState?.Exit(); // Exit the current state
        currentState = newState;
        currentState.Enter(); // Enter the new state
    }

    public void NextWave()
    {
        CurrentWave++; // Increment the wave number
        EventManager.WaveChanged(CurrentWave); // Notify listeners of the new wave
        SetState(new SpawningState(this, enemyPool, CurrentWave)); // Start spawning for the new wave
    }
}
