using UnityEngine;

public class Dead : MonoBehaviour
{
    #region Variables
    private Animator _animator;
    private Health _health;
    #endregion

    #region Private Functions
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _health = GetComponent<Health>();
    }

    private void LateUpdate()
    {
        _animator.SetBool("_isDead", _health.GetIsDead());
    }
    #endregion
}