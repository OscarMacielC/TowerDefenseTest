using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    #region Declare Stats
    [Header("Configuration")]
    [SerializeField] private float _atackSpeed = default;
    [SerializeField] private float _moveSpeed = default;
    [SerializeField] private int _maxHP = default;
    [SerializeField] private int _currentHP = default;
    #endregion

    [Header("Components")]
    [SerializeField] private Renderer _enemyRenderer = null;

    private void Start()
    {
        InitializeStats();
        ChangeChildColor();
    }

    private void InitializeStats()
    {
        _atackSpeed = Random.Range(0f, 1f);
        _moveSpeed = Random.Range(0f, 1f);
        _maxHP = Random.Range(1, 10) * 10;
        _currentHP = Mathf.RoundToInt(_maxHP / Random.Range(1, 10));
    }

    private void ChangeChildColor()
    {
        Color randColor = new Color(_atackSpeed, _moveSpeed, _currentHP / _maxHP, 1.0f);
        _enemyRenderer.material.SetColor("_Color", randColor);
    }

}
