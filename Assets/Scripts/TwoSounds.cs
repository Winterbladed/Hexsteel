using UnityEngine;

public class TwoSounds : MonoBehaviour
{
    #region Variables
    [Header("Sound Library")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClip;
    private int _soundIndex = 0;
    #endregion

    #region Public Functions
    public void Sound()
    {
        if (_soundIndex == 0) _soundIndex = 1;
        else _soundIndex = 0;
        _audioSource.PlayOneShot(_audioClip[_soundIndex]);
    }
    #endregion
}