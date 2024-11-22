using UnityEngine;

public class Activate : Interactable
{
    #region Variable
    [SerializeField] private GameObject[] _gameObject;
    [SerializeField] private bool _isActive;
    #endregion

    #region Public Functions
    public void Activation()
    {
        if (!_isActive)
        {
            foreach (GameObject _go in _gameObject) { _go.SetActive(true); _isActive = true; }
        }
        else if (_isActive)
        {
            foreach (GameObject _go in _gameObject) { _go.SetActive(false); _isActive = false; }
        }
    }
    #endregion
}