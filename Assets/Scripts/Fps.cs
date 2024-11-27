using TMPro;
using UnityEngine;

public class Fps : MonoBehaviour
{
    #region Variables
    private float _fps;
    private TMP_Text _text;
    #endregion

    #region Private Functions
    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        InvokeRepeating(nameof(GetFPS), 1f, 1f);
    }

    private void GetFPS()
    {
        _fps = (int)(1f / Time.unscaledDeltaTime);
        _text.text = "FPS: " + _fps.ToString();
        if (_fps >= 60.0f) _text.color = Color.green;
        else if (_fps < 60.0f) _text.color = Color.red;
    }
    #endregion
}