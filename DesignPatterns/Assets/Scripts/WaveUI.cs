using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveText;
    private WaveManager waveManager;

    private void Start()
    {
        waveManager = FindObjectOfType<WaveManager>();
        UpdateWaveText(waveManager.CurrentWave);

        EventManager.OnWaveChanged += UpdateWaveText;
    }

    private void OnDestroy()
    {
        EventManager.OnWaveChanged -= UpdateWaveText;
    }

    private void UpdateWaveText(int waveNumber)
    {
        waveText.text = $"Wave: {waveNumber}";
    }
}
