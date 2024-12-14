using UnityEngine;

public class Spawn : MonoBehaviour
{
    #region Variables
    [SerializeField] protected Vector3 _addToVector;
    [SerializeField] protected GameObject[] _spawn;
    [SerializeField] private Transform _transform;
    private bool _isSpawned;
    #endregion

    #region Public Functions
    public void SpawnMultipleRandomly(int _amount)
    {
        for (int i = 0; i < _amount; i++)
        {
            Instantiate(_spawn[Random.Range(0, _spawn.Length)], transform.position + _addToVector, Quaternion.identity);
        }
    }

    public void SpawnFirstMultiple(int _amount)
    {
        for (int i = 0; i < _amount; i++)
        {
            Instantiate(_spawn[0], transform.position + _addToVector, Quaternion.identity);
        }
    }

    public void SpawnAllInArray()
    {
        foreach (GameObject _spawn in _spawn)
        {
            Instantiate(_spawn, transform.position + _addToVector, Quaternion.identity);
        }
    }

    public void SpawnIndex(int _index)
    {
        Instantiate(_spawn[_index], transform.position + _addToVector, Quaternion.identity);
    }

    public void SpawnIndexOnTransform(int _index)
    {
        Instantiate(_spawn[_index], _transform.position, _transform.rotation);
    }

    public void SpawnIndexOnTransformAndRotationPlayer(int _index)
    {
        Instantiate(_spawn[_index], _transform.position + _addToVector, GetComponentInParent<Player>().transform.rotation);
    }

    public void SpawnOneRandomly()
    {
        if (!_isSpawned) Instantiate(_spawn[Random.Range(0, _spawn.Length)], _transform.position, _transform.rotation);
        _isSpawned = true;
    }

    public void SpawnAllInArrayOnTransform()
    {
        foreach (GameObject _spawn in _spawn)
        {
            Instantiate(_spawn, _transform.position + _addToVector, Quaternion.identity);
        }
    }
    #endregion
}