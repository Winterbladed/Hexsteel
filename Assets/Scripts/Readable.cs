using UnityEngine;
using UnityEngine.Events;

public class Readable : MonoBehaviour
{
    #region Variables
    [Header("Readable Extras")]
    [SerializeField] private UnityEvent _onReadEvt;
    [SerializeField] private GameObject _read;
    private bool _isReading;
    #endregion

    #region Private Functions
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_isReading)
        {
            Time.timeScale = 0.0f;
            _read.SetActive(true);
            _onReadEvt.Invoke();
            _isReading = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && _isReading ||
            Input.GetKeyDown(KeyCode.Escape) && _isReading)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1.0f;
            _read.SetActive(false);
            _onReadEvt.Invoke();
            _isReading = false;
        }
    }
    #endregion
}