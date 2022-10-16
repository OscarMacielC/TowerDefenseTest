using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTarget : MonoBehaviour
{
    
    public Transform TypeSelector(int TowerType,List<EnemyStats> EnemyStatsList)
    {
        switch(TowerType)
        {
            case 1:
                return SelectFirstEnemy(EnemyStatsList);
            case 2:
                return SelectLastEnemy(EnemyStatsList);
            default:
                return null;
        }    
    }

    public Transform SelectFirstEnemy(List<EnemyStats> EnemyStatsList)
    {
        Debug.Log("Seleccionando");
        if (EnemyStatsList.Count <= 0)
            return null;
        else
            return EnemyStatsList[0].transform;
    }

    public Transform SelectLastEnemy(List<EnemyStats> EnemyStatsList)
    {
        Debug.Log("Seleccionando");
        if (EnemyStatsList.Count <= 0)
            return null;
        else
            return EnemyStatsList[EnemyStatsList.Count-1].transform;
    }

}
