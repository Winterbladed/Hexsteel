using UnityEngine;

public class Lootable : Door
{
    #region Variables
    [SerializeField] private GameObject[] _gameObject;
    [SerializeField] private Transform _transform;
    [SerializeField] private int _amount;
    private bool _isLooted;
    #endregion

    #region Public Functions
    public void Loot()
    {
        for (int _i = 0; _i < _amount; _i++) if (!_isLooted) Instantiate(_gameObject[Random.Range(0, _gameObject.Length)], _transform.position, _transform.rotation);
        _isLooted = true;
    }
    #endregion
}