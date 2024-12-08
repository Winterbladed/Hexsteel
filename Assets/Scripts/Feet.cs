using UnityEngine;

public class Feet : MonoBehaviour
{
    #region Variables
    [SerializeField] private PlayerMovement _movement;

    [Header("Movement Sound Library")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    private float _movementStep = 0.0f;
    #endregion

    #region Private Functions
    private void Update()
    {
        if (_movement.GetIsWalking() && !_movement.GetIsRunning() && !_movement.GetIsAttacking() && !_movement.GetIsShooting() && !_movement.GetIsDodging() && !_movement.GetIsThrowing() && _movement.GetIsGrounded())
        {
            _movementStep += Time.deltaTime;
            if (_movementStep > 0.5f)
            {
                _audioSource.PlayOneShot(_audioClip);
                _movementStep = 0.0f;
            }
        }
        else if (_movement.GetIsRunning() && !_movement.GetIsAttacking() && !_movement.GetIsShooting() && !_movement.GetIsDodging() && !_movement.GetIsThrowing() && _movement.GetIsGrounded())
        {
            _movementStep += Time.deltaTime;
            if (_movementStep > 0.25f)
            {
                _audioSource.PlayOneShot(_audioClip);
                _movementStep = 0.0f;
            }
        }
        else _movementStep = 1.0f;
    }
    #endregion
}