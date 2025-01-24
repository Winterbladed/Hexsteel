using UnityEngine;

public class Translation : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Vector3 _vector1;
    [SerializeField] private Vector3 _vector2;
    private bool _isTranslated;
    #endregion

    #region Public Functions
    public void Translating()
    {
        if (!_isTranslated)
        {
            _gameObject.transform.localPosition = _vector2;
            _isTranslated = true;
        }
        else if (_isTranslated)
        {
            _gameObject.transform.localPosition = _vector1;
            _isTranslated = false;
        }
    }
    #endregion
}