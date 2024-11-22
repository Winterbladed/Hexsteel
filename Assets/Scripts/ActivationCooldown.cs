using UnityEngine;

public class ActivationCooldown : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private float _activationTime;
    private float _activeTime = 0.0f;
    private bool _isActive;
    #endregion

    #region Private Functions
    private void Start()
    {
        _gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!_isActive) return;
        _activeTime += Time.deltaTime;
        _gameObject.SetActive(true);
        if (_activeTime > _activationTime)
        {
            _gameObject.SetActive(false);
            _activeTime = 0.0f;
            _isActive = false;
        }
    }
    #endregion

    #region Public Function
    public void IsActivated()
    {
        _isActive = true;
    }
    #endregion
}