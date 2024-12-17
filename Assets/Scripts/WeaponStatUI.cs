using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel;
using UnityEditor;

public class WeaponStatUI : MonoBehaviour
{
    #region Variables
    [Header("UI Parent")]
    [SerializeField] private GameObject _gameObject;

    [Header("UI Library")]
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _damageTypeText;
    [SerializeField] private TMP_Text _damageText;
    [SerializeField] private TMP_Text _criticalChanceText;
    [SerializeField] private TMP_Text _criticalDamageText;
    [SerializeField] private TMP_Text _statusChanceText;
    [SerializeField] private TMP_Text _statusDamageText;
    [SerializeField] private TMP_Text _statusTimerText;
    [SerializeField] private TMP_Text _statusTickerText;

    private Weapon _weapon;
    #endregion

    #region Private Functions
    private void Start()
    {
        _weapon = GetComponentInParent<Weapon>();
        _gameObject.SetActive(false);
        if (_weapon)
        {
            _nameText.text = gameObject.GetComponentInParent<Weapon>().name;

            if (_weapon._DamageType == DamageType._None) { _image.sprite = null; _damageTypeText.text = "Damage Type: None"; _damageTypeText.color = Color.white; }

            //Base Physical Status Effects / Damage Types
            else if (_weapon._DamageType == DamageType._Blunt) { _image.sprite = _sprites[0]; _damageTypeText.text = "Damage Type: Blunt"; _damageTypeText.color = Color.white; }
            else if (_weapon._DamageType == DamageType._Pierce) { _image.sprite = _sprites[1]; _damageTypeText.text = "Damage Type: Pierce"; _damageTypeText.color = Color.white; }
            else if (_weapon._DamageType == DamageType._Slash) { _image.sprite = _sprites[2]; _damageTypeText.text = "Damage Type: Slash"; _damageTypeText.color = Color.white; }

            //Base Elemental Status Effects / Damage Types
            else if (_weapon._DamageType == DamageType._Toxin) { _image.sprite = _sprites[3]; _damageTypeText.text = "Damage Type: Toxin"; _damageTypeText.color = Color.green; }
            else if (_weapon._DamageType == DamageType._Ice) { _image.sprite = _sprites[4]; _damageTypeText.text = "Damage Type: Ice"; _damageTypeText.color = Color.cyan; }
            else if (_weapon._DamageType == DamageType._Fire) { _image.sprite = _sprites[5]; _damageTypeText.text = "Damage Type: Fire"; _damageTypeText.color = new Color (1.0f, 0.5f, 0.0f); }
            else if (_weapon._DamageType == DamageType._Electric) { _image.sprite = _sprites[6]; _damageTypeText.text = "Damage Type: Electric"; _damageTypeText.color = new Color(0.5f, 0.0f, 1.0f); }

            //Advanced Elemental Status Effects / Damage Types
            else if (_weapon._DamageType == DamageType._Virus) { _image.sprite = _sprites[7]; _damageTypeText.text = "Damage Type: Virus"; _damageTypeText.color = Color.magenta; }
            else if (_weapon._DamageType == DamageType._Gas) { _image.sprite = _sprites[8]; _damageTypeText.text = "Damage Type: Gas"; _damageTypeText.color = Color.yellow; }
            else if (_weapon._DamageType == DamageType._Corrode) { _image.sprite = _sprites[9]; _damageTypeText.text = "Damage Type: Corrode"; _damageTypeText.color = Color.gray; }
            else if (_weapon._DamageType == DamageType._Melt) { _image.sprite = _sprites[10]; _damageTypeText.text = "Damage Type: Melt"; _damageTypeText.color = new Color(0.0f, 1.0f, 0.5f); }
            else if (_weapon._DamageType == DamageType._Magnetic) { _image.sprite = _sprites[11]; _damageTypeText.text = "Damage Type: Magnetic"; _damageTypeText.color = Color.blue; }
            else if (_weapon._DamageType == DamageType._Blast) { _image.sprite = _sprites[12]; _damageTypeText.text = "Damage Type: Blast"; _damageTypeText.color = Color.red; }

            //Weapon Stats
            _damageText.text = "Damage: " + _weapon._Damage.ToString();
            _criticalChanceText.text = "Critical Chance: " + _weapon._CriticalChance * 100 + "%";
            _criticalDamageText.text = "Critical Damage: " + _weapon._CriticalDamage.ToString() + "x";
            _statusChanceText.text = "Status Chance: " + _weapon._StatusChance * 100 + "%";
            _statusDamageText.text = "Status Damage: " + _weapon._StatusDamage.ToString();
            _statusTimerText.text = "Status Time: " + _weapon._StatusTimer.ToString() + " seconds";
            _statusTickerText.text = "Status Tick: " + _weapon._StatusTicker.ToString() + " / second";
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            _gameObject.SetActive(true);
        }
        else _gameObject.SetActive(false);
    }
    #endregion
}