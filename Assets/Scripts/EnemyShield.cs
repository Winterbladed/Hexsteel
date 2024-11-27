using UnityEngine;

public class EnemyShield : Enemy
{
    #region Variables
    [Header("Enemy Shield Reference")]
    [SerializeField] private Animator _animator;
    #endregion

    #region Private Functions
    private void Start()
    {
        SetStats();
        GoToTarget();
    }

    private void Update()
    {
        Aniimator();
        GoToTargetWhenNear();
    }

    private void Aniimator()
    {
        if (_agent.velocity.magnitude > 0.0f) _animator.SetBool("_isMoving", false);
        else if (_agent.velocity.magnitude <= 0.0f) _animator.SetBool("_isMoving", false);
    }
    #endregion
}