using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ToggleVolumeControl : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _toggleVolumeSlider;
    [SerializeField] private string _volumeParameter = "MusicVolume";

    private void Start()
    {
        _toggleVolumeSlider.onValueChanged.AddListener(OnSoundToggleSliderChanged);
        float soundVolume = PlayerPrefs.GetFloat(_volumeParameter, 1f);
        _toggleVolumeSlider.SetValueWithoutNotify(soundVolume);

        ToggleSound(soundVolume);
    }

    public void ToggleSound(float volume)
    {
        _mixer.audioMixer.SetFloat(_volumeParameter, Mathf.Lerp(-80, 0, volume));
        AudioManager.MusicVolume = volume;
    }

    private void OnSoundToggleSliderChanged(float value)
    {
        ToggleSound(value);
        PlayerPrefs.SetFloat(_volumeParameter, value);
    }
}