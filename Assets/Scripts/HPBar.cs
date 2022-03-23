using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBar : MonoBehaviour
{
    [SerializeField] private float _healthCount;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private TMP_Text _healthIndicator;

    private float _currentHealth;
    private float _changedHealth;
    private float _heal = 10;
    private float _damage = 10;
    private float _healthChangeSpeed = 15;

    private void Start()
    {
        _currentHealth = _healthCount;
        _changedHealth = _currentHealth;
    }

    private void Update()
    {
        _healthIndicator.text = ((int)_currentHealth) + " HP";
        _currentHealth = Mathf.MoveTowards(_currentHealth, _changedHealth, _healthChangeSpeed * Time.deltaTime);
        _healthBar.value = (1 / _healthCount) * _currentHealth; 
    }

    public void AddHealth()
    {
        if (_currentHealth < _healthCount)
            _changedHealth += _heal;

        if (_changedHealth > _healthCount)
            _changedHealth = _healthCount;
    }

    public void MakeDamage()
    {
        if (_currentHealth > 0)
            _changedHealth -= _damage;

        if (_changedHealth < 0)
            _changedHealth = 0;
    }
}
