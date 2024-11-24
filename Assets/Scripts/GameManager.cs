using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables
    private enum ManagerType
    {
        Menu, Game
    }
    [SerializeField] private ManagerType _type;

    [Header("Scene Manager")]
    [SerializeField] private string _previousSceneName;
    [SerializeField] private string _sceneName;
    [SerializeField] private string _nextSceneName;

    [Header("Pause Manager")]
    [SerializeField] private UnityEvent _gamePause;
    [SerializeField] private UnityEvent _gameResume;
    private bool _isPaused;

    [Header("Panels Manager")]
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject[] _backgrounds;
    #endregion

    #region Private Functions
    private void Start()
    {
        if (_type == ManagerType.Menu) Pausing(true, 1.0f, CursorLockMode.None);
        else if (_type == ManagerType.Game) Pausing(false, 1.0f, CursorLockMode.Locked);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Pause();
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_isPaused && _type == ManagerType.Game) Pausing(false, 1.0f, CursorLockMode.Locked);
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
            }
            else if (_isPaused)
            {
                _gameResume.Invoke();
                Pausing(false, 1.0f, CursorLockMode.Locked);
            }
        }
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
            if (_type == ManagerType.Menu)
            {
                _backgrounds[0].SetActive(false);
                _backgrounds[1].SetActive(true);
            }
            _mainPanel.SetActive(false); 
            _settingsPanel.SetActive(true); 
        }
        else if (_settingsPanel.activeSelf) 
        {
            if (_type == ManagerType.Menu)
            {
                _backgrounds[0].SetActive(true);
                _backgrounds[1].SetActive(false);
            }
            _mainPanel.SetActive(true); 
            _settingsPanel.SetActive(false); 
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}