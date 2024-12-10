using UnityEngine;

public class Read : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject[] _reads;
    private int _readIndex = 0;
    #endregion

    #region Private Functions
    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (Input.GetKeyDown(KeyCode.D) && _readIndex < _reads.Length - 1) _readIndex++;
        else if (Input.GetKeyDown(KeyCode.A) && _readIndex > 0) _readIndex--;
        _reads[_readIndex].SetActive(true);
        for (int _i = 0; _i < _reads.Length; _i++) if (_i != _readIndex) _reads[_i].SetActive(false);
    }
    #endregion
}