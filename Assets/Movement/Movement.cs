using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variables
    [SerializeField] protected float _speed = 2.0f;
    protected float _currentSpeed = 2.0f;
    protected float _slowSpeed = 1.0f;
    protected float _runSpeed = 8.0f;
    #endregion

    #region Protected Functions
    protected virtual void Start()
    {
        _currentSpeed = _speed;
        _slowSpeed = _speed / 2.0f;
        _runSpeed = _speed * 2.5f;
    }
    #endregion

    #region Public Functions
    public void Slow()
    {
        _currentSpeed = _slowSpeed;
    }

    public void UnSlow()
    {
        _currentSpeed = _speed;
    }
    #endregion
}