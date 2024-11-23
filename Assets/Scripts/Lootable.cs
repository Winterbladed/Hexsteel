using UnityEngine;

public class Lootable : Door
{
    #region Variables
    [SerializeField] private GameObject[] _gameObject;
    [SerializeField] private Transform _transform;
    private bool _isLooted;
    #endregion

    #region Public Functions
    public void Loot()
    {
        if (!_isLooted) Instantiate(_gameObject[Random.Range(0, _gameObject.Length)], _transform.position, _transform.rotation);
        _isLooted = true;
    }
    #endregion
}