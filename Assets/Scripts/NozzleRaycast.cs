using UnityEngine;

public class NozzleRaycast : MonoBehaviour
{
    #region Variables
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject _camera;
    #endregion

    #region Private Functions
    private void Start()
    {
        _camera = GetComponentInParent<CameraMove>().gameObject;
    }

    private void Update()
    {
        RaycastHit _hit;
        Ray _ray = new Ray(_camera.transform.position, _camera.transform.forward);
        if (Physics.Raycast(_ray, out _hit, 10000.0f, _layerMask)) transform.LookAt(_hit.point);
        else transform.localRotation = Quaternion.identity;
    }
    #endregion
}