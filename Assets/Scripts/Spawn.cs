using UnityEngine;

public class Spawn : MonoBehaviour
{
    #region Variables
    [SerializeField] protected Vector3 _addToVector;
    [SerializeField] protected GameObject[] _spawn;
    [SerializeField] private Transform _transform;
    #endregion

    #region Public Functions
    public void Spawning(int _amount)
    {
        for (int i = 0; i < _amount; i++)
        {
            Instantiate(_spawn[Random.Range(0, _spawn.Length)], transform.position + _addToVector, Quaternion.identity);
        }
    }

    public void Spawning1()
    {
        foreach (GameObject _spawn in _spawn)
        {
            Instantiate(_spawn, transform.position + _addToVector, Quaternion.identity);
        }
    }

    public void Spawning2(int _index)
    {
        Instantiate(_spawn[_index], transform.position + _addToVector, Quaternion.identity);
    }

    public void Spawning3(int _index)
    {
        Instantiate(_spawn[_index], _transform.position, _transform.rotation);
    }
    #endregion
}