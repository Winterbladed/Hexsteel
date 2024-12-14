using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagerr : MonoBehaviour
{
    #region Variales
    [Header("Scene Manager")]
    [SerializeField] private string _previousSceneName;
    [SerializeField] private string _sceneName;
    [SerializeField] private string _nextSceneName;
    #endregion

    #region Public Functions
    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(_previousSceneName);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_nextSceneName);
    }
    #endregion
}