using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    #region Variables
    public float _Speed = 2.0f;
    protected float _currentSpeed = 2.0f;
    protected float _slowSpeed = 1.0f;
    protected float _runSpeed = 8.0f;

    [Header("For AI with Targets")]
    [SerializeField] protected float _stopRange;
    [SerializeField] protected float _detectRange;
    [SerializeField] protected float _followBuffer;
    protected float _distanceFromTarget;
    protected Transform _target;
    public Vector3 _InitialRotation;
    public Vector3 _OriginalPosition;

    protected Player _player;
    #endregion

    #region Protected Functions
    protected virtual void Start()
    {
        _player = Player._Player;
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
    #endregion

    #region Public Functions
    public void Slow() { _currentSpeed = _slowSpeed; }
    public void UnSlow() { _currentSpeed = _Speed; }
    public Player GetPlayer() { return _player; }
    public Transform GetTarget() { return _target; }
    public float GetStopRange() { return _stopRange; }
    public float GetDetectRange() { return _detectRange; }
    public float GetFollowBuffer() { return _followBuffer; }
    public float GetDistanceFromTarget() { return _distanceFromTarget; }
    public void SetDistanceFromTarget(float _distance) { _distanceFromTarget = _distance; }
    public float GetCurrentSpeed() { return _currentSpeed; }
    #endregion
}