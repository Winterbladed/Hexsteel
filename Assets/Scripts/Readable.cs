using UnityEngine;
using UnityEngine.Events;

public class Readable : MonoBehaviour
{
    #region Variables
    [Header("Readable Extras")]
    [SerializeField] private UnityEvent _onReadEvt;
    [SerializeField] private GameObject _read;
    private bool _isReading;
    private GameManager _gameManager;
    private Inventory _inventory;
    #endregion

    #region Private Functions
    private void Start()
    {
        _gameManager = GameManager._GameManager;
        _inventory = Inventory._Inventory;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_isReading && !_gameManager.GetIsPaused() && !_inventory.GetIsShopping())
        {
            _inventory.SetIsReading(true);
            Time.timeScale = 0.0f;
            _read.SetActive(true);
            _onReadEvt.Invoke();
            _isReading = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && _isReading && !_gameManager.GetIsPaused() && !_inventory.GetIsShopping() ||
            Input.GetKeyDown(KeyCode.Escape) && _isReading && !_gameManager.GetIsPaused() && !_inventory.GetIsShopping())
        {
            _inventory.SetIsReading(false);
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