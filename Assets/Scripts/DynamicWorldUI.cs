using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DynamicWorldUI : MonoBehaviour
{
    #region Variables
    private enum DynamicWorldUIType
    {
        DamageNumber,
        StatusName,
    }
    [SerializeField] private DynamicWorldUIType _type;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;
    private float _timer = 0.0f;
    private bool _hasPopped = false;
    #endregion

    #region Private Functions
    private void Start()
    {
        if (_type == DynamicWorldUIType.StatusName)
            Destroy(gameObject, 1.0f);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_text.fontSize < 0.6f && !_hasPopped && _type == DynamicWorldUIType.DamageNumber)
            _text.fontSize += Time.deltaTime * 2.0f;
        else if (_text.fontSize > 0.6f && !_hasPopped && _type == DynamicWorldUIType.DamageNumber)
            _hasPopped = true;
        else if (_hasPopped && _type == DynamicWorldUIType.DamageNumber)
        {
            _text.fontSize -= Time.deltaTime * 6.0f;
            if (_text.fontSize <= 0.0f)
                Destroy(gameObject);
        }
    }
    #endregion

    #region Public Functions
    public void SetTextString(string _words, Color _color)
    {
        _text.text = _words;
        _text.color = _color;
    }

    public void SetImageSprite(Sprite _picture, Color _color)
    {
        _image.sprite = _picture;
        _text.color = _color;
    }
    #endregion
}