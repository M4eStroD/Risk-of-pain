using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    private const int VolumeOff = -80;

    private const string MasterVolume = "MasterVolume";
    private const string MusicVolume = "MusicVolume";
    private const string EffectVolume = "EffectVolume";

    [SerializeField] private Slider _masterValue;
    [SerializeField] private Slider _musicValue;
    [SerializeField] private Slider _effectValue;

    [SerializeField] private AudioMixerGroup _mixer;

    private float _lastMasterVolume = 0;
    private float _lastMusicVolume = 0;
    private float _lastEffectVolume = 0;

    public void ToggleMasterVolume()
    {
        _mixer.audioMixer.GetFloat(MasterVolume, out float value);

        if (value == VolumeOff)
        {
            _mixer.audioMixer.SetFloat(MasterVolume, Mathf.Lerp(VolumeOff, 0, _lastMasterVolume));
            _masterValue.value = _lastMasterVolume;
        }
        else
        {
            _mixer.audioMixer.SetFloat(MasterVolume, VolumeOff);
            _lastMasterVolume = _masterValue.value;
            _masterValue.value = 0;
        }
    }

    public void ToggleMusicVolume()
    {
        _mixer.audioMixer.GetFloat(MusicVolume, out float value);

        if (value == VolumeOff)
        {
            _mixer.audioMixer.SetFloat(MusicVolume, Mathf.Lerp(VolumeOff, 0, _lastMusicVolume));
            _musicValue.value = _lastMusicVolume;
        }
        else
        {
            _mixer.audioMixer.SetFloat(MusicVolume, VolumeOff);
            _lastMusicVolume = _musicValue.value;
            _musicValue.value = 0;
        }
    }

    public void ToggleEffectVolume()
    {
        _mixer.audioMixer.GetFloat(EffectVolume, out float value);

        if (value == VolumeOff)
        {
            _mixer.audioMixer.SetFloat(EffectVolume, Mathf.Lerp(VolumeOff, 0, _lastEffectVolume));
            _effectValue.value = _lastEffectVolume;
        }
        else
        {
            _mixer.audioMixer.SetFloat(EffectVolume, VolumeOff);
            _lastEffectVolume = _effectValue.value;
            _effectValue.value = 0;
        }
    }

    public void ChangeMasterVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(MasterVolume, Mathf.Lerp(VolumeOff, 0, volume));
    }

    public void ChangeMusicVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(MusicVolume, Mathf.Lerp(VolumeOff, 0, volume));
    }

    public void ChangeEffectVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(EffectVolume, Mathf.Lerp(VolumeOff, 0, volume));
    }

}
