using UnityEngine;

public class Sound : MonoBehaviour
{
    #region Variables
    [Header("Sound Library")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClip;
    #endregion

    #region Public Functions
    public void PlaySound(int _index)
    {
        _audioSource.PlayOneShot(_audioClip[_index]);
    }
    #endregion
}