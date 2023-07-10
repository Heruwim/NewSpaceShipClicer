using TMPro;
using UnityEngine;

public class WaveCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _wave;
    [SerializeField] private Spawner _spawner;
    
    private void OnEnable()
    {
        _wave.text = _spawner.CurrentWaveNumber.ToString();
        _spawner.WaveCountChanged += OnWaveChanged;
    }

    private void OnDisable()
    {
        _spawner.WaveCountChanged -= OnWaveChanged;
    }

    private void OnWaveChanged(int wave)
    {
        _wave.text = wave.ToString();
    }
}
