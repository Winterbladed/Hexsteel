using UnityEngine;
[RequireComponent (typeof(AudioSource))]

public class Drop : MonoBehaviour
{
    #region Variables
    [SerializeField] private AudioClip _audioClip;
    private AudioSource _audioSource;
    #endregion

    #region Private Functions
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0.05f;
    }
    #endregion

    #region Unity Messages
    private void OnCollisionEnter(Collision _drop)
    {
        _audioSource.PlayOneShot(_audioClip);
    }
    #endregion
}