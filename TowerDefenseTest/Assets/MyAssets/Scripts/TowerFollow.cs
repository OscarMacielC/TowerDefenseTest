using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFollow : MonoBehaviour
{
    private Transform _ObjectToFollow;
    private Transform _TowerHead;
    private SphereCollider _DetectionCollider;
    [SerializeField]
    private List<EnemyStats> _EnemyStatsList = new List<EnemyStats>(0);
    [SerializeField]
    private int _Range = 5;
    private TowerTarget _TargetSelector;

    private void Start()
    {
        _TowerHead = transform.GetChild(0).GetChild(0); // Check later with a tag, script or something

        #region Obtener Colisionador de esfera
        try
        {
            _DetectionCollider = GetComponent<SphereCollider>();
            _DetectionCollider.radius = CalculateDetectionAreaSphere(_Range);
        }
        catch
        {
            Debug.LogWarning("No se encontró un colisionador de esfera");
        }
        #endregion
        #region Obtener selector de objetivos
        try
        {
            _TargetSelector = GetComponent<TowerTarget>();
        }
        catch
        {
            Debug.LogWarning("No se encontró un selector de objetivos");
        }
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.CompareTag("Enemy")) // No tiene tag de enemigo;
            return;
        
        if (other.GetComponent<EnemyStats>() == null) // Debug.LogWarning("No se encontraron los detalles del enemigo");
            return;

        _EnemyStatsList.Add(other.GetComponent<EnemyStats>());
        _ObjectToFollow = _TargetSelector.SelectLastEnemy(_EnemyStatsList);
    }

    private void OnTriggerExit(Collider other)
    {
        _EnemyStatsList.Remove(other.GetComponent<EnemyStats>());
    }

    void Update()
    {
        if(_ObjectToFollow!=null)
        {
            _TowerHead.LookAt(_ObjectToFollow.transform);
        }
    }
        
    private float CalculateDetectionAreaSphere(int Range)
    {
        if (Range <= 0)
            return 0f;
        else
            return Range - 0.5f; // Change height Y if needed
    }

}
