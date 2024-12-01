using UnityEngine;

public class CameraMove : MonoBehaviour
{
    #region Variables
    [Header("Camera Reference")]
    [SerializeField] private Transform _player;
    [SerializeField] private Movement _movement;
    [SerializeField] private Vector3 _vector;
    private Vector3 _vectorNear;
    private Vector3 _vectorFar = new Vector3(0.5f, 1.8f, 2.0f);

    [Header("Camera Stats")]
    [SerializeField] private float _xSpeed = 360.0f;
    [SerializeField] private float _ySpeed = 360.0f;
    private float _distance = 2.0f;
    private float _yMinLimit = -20.0f;
    private float _yMaxLimit = 80.0f;
    private float _currentFov = 60.0f;
    private float _targetFov = 60.0f;
    [SerializeField] private float _normalFov = 90.0f;
    [SerializeField] private float _runFov = 100.0f;
    [SerializeField] private float _slowFov = 50.0f;
    private float _rotationSmoothTime = 0.1f;
    private float _positionSmoothTime = 0.1f;
    private float _x = 0.0f;
    private float _y = 0.0f;
    #endregion

    #region Private Functions
    private void Start()
    {
        Vector3 _angles = transform.eulerAngles;
        _x = _angles.y; _y = _angles.x;
        _vectorNear = _vector;
        _vectorFar = _vectorNear + new Vector3(0.0f, 0.0f, -2.0f);
        _targetFov = _normalFov;
    }

    private void Update()
    {
        Camera.main.fieldOfView = _currentFov;
        _currentFov = Mathf.MoveTowards(_currentFov, _targetFov, Time.deltaTime * 200.0f);
        if (_movement.GetIsWalking() && !_movement.GetIsRunning()) _targetFov = _normalFov;
        else if (_movement.GetIsWalking() && _movement.GetIsRunning()) _targetFov = _runFov;
        else if (_movement.GetIsSlowed()) _currentFov = _targetFov = _slowFov;
        else _targetFov = _normalFov;
        _x += Input.GetAxis("Mouse X") * _xSpeed * Time.deltaTime;
        _y -= Input.GetAxis("Mouse Y") * _ySpeed * Time.deltaTime;
        _y = Mathf.Clamp(_y, _yMinLimit, _yMaxLimit);
        SharpCamera();
    }

    private void SharpCamera()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) _vector = _vectorNear;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0) _vector = _vectorFar;
        Quaternion _rotation = Quaternion.Euler(_y, _x, 0.0f);
        Vector3 _position = _rotation * new Vector3(_vector.x, _vector.y, -_distance + _vector.z) + _player.position;
        transform.rotation = _rotation; transform.position = _position;
    }

    private void SmoothCamera()
    {
        Quaternion _targetRotation = Quaternion.Euler(_y, _x, 0.0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSmoothTime);
        Vector3 _targetPosition = _targetRotation * new Vector3(_vector.x, _vector.y, -_distance + _vector.z) + _player.position;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _positionSmoothTime);
    }
    #endregion
}