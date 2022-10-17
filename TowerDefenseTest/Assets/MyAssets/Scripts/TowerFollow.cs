using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class TowerFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _towerHead = default;
    private SphereCollider _detectionCollider = default;
    [SerializeField]
    private List<GameObject> _enemyStatsList = new List<GameObject>(0);
    [SerializeField]
    private int _range = 5;
    private GameObject _objectToFollow = default;

    public UnityEvent<GameObject> OnTargetAquired { get; private set; } = new UnityEvent<GameObject>();
    //private Transform ObjectToFollow => _enemyStatsList.FirstOrDefault()?.transform; // ? revisa si es null, si lo es regresa null

    private void Start()
    {
        #region Obtener Colisionador de esfera
        _detectionCollider = GetComponent<SphereCollider>();
        _detectionCollider.radius = CalculateDetectionAreaSphere(_range);
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.CompareTag("Enemy")) return;

        _enemyStatsList.Add(other.gameObject);
        if (_enemyStatsList.Count != 1) return;

        Retarget();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.transform.CompareTag("Enemy")) return;

        _enemyStatsList.Remove(other.gameObject);
        Retarget();
    }

    void Update()
    {
        if (_enemyStatsList.Count <= 0) return;

        if (_objectToFollow != null)
        {
            _towerHead.LookAt(_objectToFollow.transform);
        }
        else
        {
            _enemyStatsList.RemoveAll(item => item == null);
            Retarget();
        }
    }

    private float CalculateDetectionAreaSphere(int range)
    {
        return range <= 0 ? 0f : range - 0.5f;
    }

    private void Retarget()
    {
        OnTargetAquired.Invoke(_objectToFollow = _enemyStatsList.FirstOrDefault());//Linq, si mayor a 0 Default.

        //TODO: I will extend this to select the enemy depending on the towertype view task
        //TowerFollow.OnTargetAquired.subscribe
    }

}
