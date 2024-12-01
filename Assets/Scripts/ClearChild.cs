using UnityEngine;

public class ClearChild : MonoBehaviour
{
    #region Public Functions
    public void ClearChildren()
    {
        int _i = 0; GameObject[] _allChildren = new GameObject[transform.childCount];
        foreach (Transform _child in transform) { _allChildren[_i] = _child.gameObject; _i += 1; }
        foreach (GameObject _child in _allChildren) Destroy(_child.gameObject);
    }
    #endregion
}