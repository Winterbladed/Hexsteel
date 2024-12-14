using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    #region Variables
    [SerializeField] private float _time;
    private float _timer = 0.0f;
    private bool _isDone = false;
    [SerializeField] private UnityEvent _onTimerStart;
    [SerializeField] private UnityEvent _onTimerEnd;
    #endregion

    #region Private Functions
    private void Start()
    {
        _onTimerStart.Invoke();
    }

    private void Update()
    {
        if (!_isDone)
        {
            _timer += Time.deltaTime;
            if (_timer > _time)
            {
                _onTimerEnd.Invoke();
                _timer = 0.0f;
                _isDone = true;
            }
        }
    }
    #endregion
}