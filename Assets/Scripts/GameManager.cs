using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager _GameManager;
    private void Awake()
    {
        if (_GameManager != null) return;
        _GameManager = this;
    }
    #endregion

    #region Variables
    private enum ManagerType { Menu, Game }
    [SerializeField] private ManagerType _type;

    [Header("Scene Manager")]
    [SerializeField] private string _previousSceneName;
    [SerializeField] private string _sceneName;
    [SerializeField] private string _nextSceneName;

    [Header("Pause Manager")]
    [SerializeField] private UnityEvent _gamePause;
    [SerializeField] private UnityEvent _gameResume;
    private bool _isPaused;
    private bool _isFullscreen = true;
    private bool _isShadow = true;

    [Header("Panels Manager")]
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _settingsPanel;

    private Inventory _inventory;
    #endregion

    #region Private Functions
    private void Start()
    {
        if (_type == ManagerType.Menu) Pausing(true, 1.0f, CursorLockMode.None);
        else if (_type == ManagerType.Game) { Pausing(false, 1.0f, CursorLockMode.Locked); _inventory = Inventory._Inventory; }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_inventory.GetIsShopping() && !_inventory.GetIsReading()) Pause();
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_isPaused && _type == ManagerType.Game && !_inventory.GetIsShopping() && !_inventory.GetIsReading()) Pausing(false, 1.0f, CursorLockMode.Locked);
    }

    private void Pausing(bool _boolean, float _timeScale, CursorLockMode _lock)
    {
        Cursor.visible = _boolean;
        Cursor.lockState = _lock;
        _isPaused = _boolean;
        Time.timeScale = _timeScale;
    }
    #endregion

    #region Public Functions
    public void Pause()
    {
        if (_type == ManagerType.Game)
        {
            if (!_isPaused)
            {
                _gamePause.Invoke();
                Pausing(true, 0.0f, CursorLockMode.None);
                _pausePanel.SetActive(true);
                _settingsPanel.SetActive(false);
            }
            else if (_isPaused)
            {
                _gameResume.Invoke();
                Pausing(false, 1.0f, CursorLockMode.Locked);
                _pausePanel.SetActive(false);
                _settingsPanel.SetActive(false);
            }
        }
    }

    public void FullScreen()
    {
        if (!_isFullscreen) { Screen.SetResolution(1920, 1080, true); Screen.fullScreenMode = FullScreenMode.FullScreenWindow; _isFullscreen = true; }
        else if (_isFullscreen) { Screen.SetResolution(1280, 720, false); Screen.fullScreenMode = FullScreenMode.Windowed; _isFullscreen = false; }
    }

    public void Shadows()
    {
        if (_isShadow) { gameObject.GetComponent<Light>().shadows = LightShadows.None; _isShadow = false; }
        else if (!_isShadow) { gameObject.GetComponent<Light>().shadows = LightShadows.Hard; _isShadow = true; }
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(_previousSceneName);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_nextSceneName);
    }

    public void Settings()
    {
        if (!_settingsPanel.activeSelf) 
        {
            _pausePanel.SetActive(false); 
            _settingsPanel.SetActive(true);
        }
        else if (_settingsPanel.activeSelf) 
        {
            _pausePanel.SetActive(true); 
            _settingsPanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public bool GetIsPaused() { return _isPaused; }
    #endregion
}