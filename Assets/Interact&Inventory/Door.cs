using UnityEngine;

public class Door : Interactable
{
    #region Variables
    [SerializeField] private GameObject _doorPivot;
    [SerializeField] private Vector3 _doorOpen = new Vector3(0.0f, 90.0f, 0.0f);
    [SerializeField] private Vector3 _doorClose = new Vector3(0.0f, 0.0f, 0.0f);
    private bool _isOpen;
    #endregion

    #region Public Functions
    public void DoorHandle()
    {
        if (!_isOpen)
        {
            _isOpen = true;
            _doorPivot.transform.localEulerAngles = _doorOpen;
        }
        else
        {
            _isOpen = false;
            _doorPivot.transform.localEulerAngles = _doorClose;
        }
    }
    #endregion
}