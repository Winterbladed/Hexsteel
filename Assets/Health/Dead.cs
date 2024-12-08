using UnityEngine;

public class Dead : MonoBehaviour
{
    #region Variables
    [SerializeField] private Animator _animator;
    [SerializeField] private Health _health;
    #endregion

    #region Private Functions
    private void LateUpdate()
    {
        _animator.SetBool("_isDead", _health.GetIsDead());
    }
    #endregion
}