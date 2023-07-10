using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private string _volumeParameter = "MasterVolume";

    private const float _multiplier = 20f;

    private void Start()
    {
        _masterVolumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);        
        float masterVolume = PlayerPrefs.GetFloat(_volumeParameter, 1f);       
        _masterVolumeSlider.SetValueWithoutNotify(masterVolume);
        
        ChangeVolume(masterVolume);        
    }


    public void ChangeVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(_volumeParameter, Mathf.Log10(volume) * _multiplier);
        AudioManager.MasterVolume = volume;
    }
    
    private void OnVolumeSliderChanged(float value)
    {
        ChangeVolume(value);
        PlayerPrefs.SetFloat(_volumeParameter, value);
    }    
}
