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
        if (_text.fontSize < 1.0f && !_hasPopped && _type == DynamicWorldUIType.DamageNumber)
            _text.fontSize += Time.deltaTime * 4.0f;
        else if (_text.fontSize > 1.0f && !_hasPopped && _type == DynamicWorldUIType.DamageNumber)
            _hasPopped = true;
        else if (_hasPopped && _type == DynamicWorldUIType.DamageNumber)
        {
            _text.fontSize -= Time.deltaTime * 12.0f;
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

    public void SetImageSprite(Sprite _picture, Color _color, Material _material)
    {
        _image.sprite = _picture;
        _text.color = _color;
        _image.material = _material;
    }
    #endregion
}