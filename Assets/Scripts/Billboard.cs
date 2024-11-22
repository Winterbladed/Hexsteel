using UnityEngine;

public class Billboard : MonoBehaviour
{
    #region Variables
    private CameraMove _camera;
    #endregion

    #region Private Functions
    private void Start()
    {
        _camera = FindAnyObjectByType<CameraMove>();
    }

    private void Update()
    {
        transform.LookAt(_camera.gameObject.transform.position);
    }
    #endregion
}