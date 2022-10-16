using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("ID")]
    [SerializeField]
    private int _UniqueID;
    private static int s_IDGen = 0;
    private Renderer _cubeRenderer;

    #region Declare Stats
    [Header("Stats")]
    [SerializeField]
    private float _atackSpeed;
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private int _maxHP;
    [SerializeField]
    private int _currentHP;
    #endregion

    private void Awake()
    {
        s_IDGen++;
        _UniqueID = s_IDGen;
    }
    void Start()
    {
        #region initialize Stats
        _atackSpeed = Random.Range(0f,1f);
        _moveSpeed = Random.Range(0f,1f);
        _maxHP = Random.Range(1, 10)*10;
        _currentHP = Mathf.RoundToInt(_maxHP / Random.Range(1, 10));
        #endregion
        _cubeRenderer = transform.GetChild(0).GetComponent<Renderer>();
        Color randColor = new Color(_atackSpeed, _moveSpeed, _currentHP/_maxHP, 1.0f);
        _cubeRenderer.material.SetColor("_Color", randColor);
    }

}
