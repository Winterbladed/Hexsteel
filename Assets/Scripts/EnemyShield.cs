using UnityEngine;

public class EnemyShield : Enemy
{
    #region Variables
    [Header("Enemy Shield Reference")]
    [SerializeField] private Animator _animator;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        GoToTarget();
    }

    private void Update()
    {
        Aniimator();
        GoToTargetWhenNear();
    }

    private void Aniimator()
    {
        if (_enemyMovement.GetNavMeshAgent().velocity.magnitude > 0.0f) _animator.SetBool("_isMoving", false);
        else if (_enemyMovement.GetNavMeshAgent().velocity.magnitude <= 0.0f) _animator.SetBool("_isMoving", false);
    }
    #endregion
}