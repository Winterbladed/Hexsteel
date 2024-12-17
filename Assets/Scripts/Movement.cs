using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    #region Variables
    [Header("Movement Stats")]
    public float _Speed = 2.0f;
    protected float _currentSpeed = 2.0f;
    protected float _slowSpeed = 1.0f;
    protected float _runSpeed = 8.0f;
    protected bool _isSlowed;

    [Header("For AI with Targets")]
    [SerializeField] protected LayerMask _raycastLayerMask;
    [SerializeField] protected float _raycastDistance;
    [SerializeField] protected float _stopRange = 0;
    protected float _distanceFromTarget;
    [SerializeField] protected float _wanderRange = 15.0f;
    [SerializeField] protected float _wanderCooldown = 15.0f;
    protected float _currentWanderCooldown;
    protected GameObject _target;
    public Vector3 _InitialRotation;
    public Vector3 _OriginalPosition;

    protected NavMeshAgent _navMeshAgent;
    #endregion

    #region Protected Functions
    protected virtual void Start()
    {
        _currentSpeed = _Speed;
        _slowSpeed = _Speed / 2.0f;
        _runSpeed = _Speed * 2.5f;
        _InitialRotation = transform.eulerAngles;
        _OriginalPosition = transform.position;
    }

    protected Vector3 RandomNavmeshPoint(Vector3 _center, float _range)
    {
        Vector3 _randomPoint = _center + Random.insideUnitSphere * _range;
        NavMeshHit _hit;
        if (NavMesh.SamplePosition(_randomPoint, out _hit, _range, NavMesh.AllAreas)) return _hit.position;
        return Vector3.zero;
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _stopRange);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + _raycastDistance));
    }
    #endregion

    #region Public Functions
    public void Slow() { _currentSpeed = _slowSpeed; _isSlowed = true; }
    public void UnSlow() { _currentSpeed = _Speed; _isSlowed = false; }
    public GameObject GetTarget() { return _target; }
    public void SetTarget(GameObject _newTarget) { _target = _newTarget; }
    public float GetStopRange() { return _stopRange; }
    public float GetDistanceFromTarget() { return _distanceFromTarget; }
    public void SetDistanceFromTarget(float _distance) { _distanceFromTarget = _distance; }
    public float GetCurrentSpeed() { return _currentSpeed; }
    #endregion
}