using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private Slider _volumeSlider;
    #endregion

    #region Private Functions
    private void Start()
    {
        CheckVolume();
    }
    #endregion

    #region Public Functions
    public void CheckVolume()
    {
        if (!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soundVolume", 1);
            LoadVolume();
        }
        else
            LoadVolume();
    }

    public void ChangeVolume()
    {
        if (_volumeSlider) AudioListener.volume = _volumeSlider.value;
        SaveVolume();
    }

    public void LoadVolume()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("soundVolume", _volumeSlider.value);
    }

    public void Mute()
    {
        AudioListener.volume = 0.0f;
    }
    #endregion
}