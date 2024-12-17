using UnityEngine;
using UnityEngine.UI;

public class SensitivityManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private Slider _sensitivitySlider;
    [SerializeField] private CameraMove _camera;
    #endregion

    #region Private Functions
    private void Start()
    {
        CheckSensitivity();
    }
    #endregion

    #region Public Functions
    public void CheckSensitivity()
    {
        if (!PlayerPrefs.HasKey("sensitivity"))
        {
            PlayerPrefs.SetFloat("sensitivity", 360);
            LoadSensitivity();
        }
        else
            LoadSensitivity();
    }

    public void ChangeSensitivity()
    {
        _camera.SetSensitivity(_sensitivitySlider.value, _sensitivitySlider.value);
        SaveSensitivity();
    }

    public void LoadSensitivity()
    {
        _camera.SetSensitivity(_sensitivitySlider.value, _sensitivitySlider.value);
        _sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity");
    }

    public void SaveSensitivity()
    {
        PlayerPrefs.SetFloat("sensitivity", _sensitivitySlider.value);
    }
    #endregion
}