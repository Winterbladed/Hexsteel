using UnityEngine;

public class Feet : MonoBehaviour
{
    #region Variables
    [SerializeField] private Movement _movement;

    [Header("Movement Sound Library")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _audioSourcer;
    [SerializeField] private AudioClip[] _audioClip;
    private float _movementStep = 0.0f;
    private bool _isSoft, _isWater, _isHard;
    #endregion

    #region Private Functions
    private void Update()
    {
        if (_movement.GetIsWalking() && !_movement.GetIsRunning() && !_movement.GetIsAttacking() && !_movement.GetIsShooting() && !_movement.GetIsDodging())
        {
            _movementStep += Time.deltaTime;
            if (_movementStep > 0.6f)
            {
                if (_isWater) _audioSourcer.PlayOneShot(_audioClip[0]);
                else if (_isHard && !_isWater) _audioSource.PlayOneShot(_audioClip[2]);
                else if (_isSoft && !_isWater && !_isHard) _audioSource.PlayOneShot(_audioClip[1]);
                _movementStep = 0.0f;
            }
        }
        else if (_movement.GetIsRunning() && !_movement.GetIsAttacking() && !_movement.GetIsShooting() && !_movement.GetIsDodging())
        {
            _movementStep += Time.deltaTime;
            if (_movementStep > 0.2f)
            {
                if (_isWater) _audioSourcer.PlayOneShot(_audioClip[0]);
                else if (_isHard && !_isWater) _audioSource.PlayOneShot(_audioClip[2]);
                else if (_isSoft && !_isWater && !_isHard) _audioSource.PlayOneShot(_audioClip[1]);
                _movementStep = 0.0f;
            }
        }
        else
            _movementStep = 1.0f;
    }
    #endregion

    #region Unity Messages
    private void OnTriggerStay(Collider _ground)
    {
        if (_ground.gameObject.CompareTag("Water"))
            _isWater = true;
        else if (_ground.gameObject.CompareTag("Soft"))
            _isSoft = true;
        else if (_ground.gameObject.CompareTag("Hard"))
            _isHard = true;
    }

    private void OnTriggerExit(Collider _ground)
    {
        if (_ground.gameObject.CompareTag("Water"))
            _isWater = false;
        else if (_ground.gameObject.CompareTag("Soft"))
            _isSoft = false;
        else if (_ground.gameObject.CompareTag("Hard"))
            _isHard = false;
    }
    #endregion
}