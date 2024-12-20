using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Cutscene : MonoBehaviour
{
    #region Variables
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string[] _string;
    [SerializeField] private GameObject[] _sound;
    [SerializeField] private GameObject[] _scenes;
    [SerializeField] private UnityEvent _onEnd;
    private int _index;
    private int _currentIndex;
    #endregion

    #region Private Functions
    private void Start()
    {
        if (_sound != null) { _index = _sound.Length; for (int _i = 0; _i < _index; _i++) if (_i != _currentIndex) _sound[_i].SetActive(false); }
        if (_scenes != null) { _index = _scenes.Length; for (int _i = 0; _i < _index; _i++) if (_i != _currentIndex) _scenes[_i].SetActive(false); }
        if (_text != null) { _index = _string.Length; _text.text = _string[_currentIndex]; }
        _currentIndex = 0;
    }

    private void Update()
    {
        if (_sound != null) { _sound[_currentIndex].SetActive(true); for (int _i = 0; _i < _index; _i++) if (_i != _currentIndex) _sound[_i].SetActive(false); }
        if (_scenes != null) { _index = _scenes.Length; for (int _i = 0; _i < _index; _i++) if (_i != _currentIndex) _scenes[_i].SetActive(false); }
        if (_text != null) _text.text = _string[_currentIndex];
        if (Input.GetKeyDown(KeyCode.Mouse0) && _currentIndex < _index)
        {
            _currentIndex++;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && _currentIndex >= _index)
        {
            _onEnd.Invoke();
        }
    }
    #endregion
}