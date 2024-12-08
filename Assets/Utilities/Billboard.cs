using UnityEngine;

public class Billboard : MonoBehaviour
{
    private CameraMove _camera;
    private void Start() { _camera = FindAnyObjectByType<CameraMove>(); }
    private void Update() { transform.LookAt(_camera.gameObject.transform.position); }
}