using UnityEngine;

public class Sound : MonoBehaviour
{
    #region Variables
    [Header("Sound Library")]
    [SerializeField] private AudioClip[] _audioClip;
    private AudioSource _audioSource;
    #endregion

    #region Public Functions
    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int _index)
    {
        _audioSource.PlayOneShot(_audioClip[_index]);
    }
    #endregion
}