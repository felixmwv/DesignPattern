using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveText; // UI element to display the wave number
    private WaveManager waveManager; // Tracks the current wave

    private void Start()
    {
        waveManager = FindObjectOfType<WaveManager>(); // Locate the WaveManager in the scene
        UpdateWaveText(waveManager.CurrentWave); // Initialize the wave text display
        EventManager.OnWaveChanged += UpdateWaveText; // Subscribe to wave change events
    }

    private void OnDestroy()
    {
        EventManager.OnWaveChanged -= UpdateWaveText; // Unsubscribe to prevent memory leaks
    }

    private void UpdateWaveText(int waveNumber)
    {
        waveText.text = $"Wave: {waveNumber}"; // Update the wave number in the UI
    }
}
