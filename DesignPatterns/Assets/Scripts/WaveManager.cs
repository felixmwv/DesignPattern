using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private IWaveState currentState;

    public EnemyPool enemyPool;

    public int CurrentWave { get; private set; } = 1;

    private void Start()
    {
        EventManager.WaveChanged(CurrentWave);
        SetState(new SpawningState(this, enemyPool, CurrentWave));
    }


    private void Update()
    {
        currentState?.Update();
    }

    public void SetState(IWaveState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void NextWave()
    {
        CurrentWave++;
        EventManager.WaveChanged(CurrentWave);
        SetState(new SpawningState(this, enemyPool, CurrentWave));
    }

}
