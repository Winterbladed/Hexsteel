using UnityEngine;

public class Drop : MonoBehaviour
{
    #region Variables
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    #endregion

    #region Private Functions
    private void OnCollisionEnter(Collision _drop)
    {
        _audioSource.PlayOneShot(_audioClip);
    }
    #endregion
}