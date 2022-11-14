using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private float bulletLifespan=3f;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject bullet = PooledObject.sharedInstance.GetPooledObject();
            if (bullet != null) 
            { 
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
                StartCoroutine(DeactivateAfterSeconds(bullet, bulletLifespan));
            }
        }
    }

    IEnumerator DeactivateAfterSeconds(GameObject anyGO, float time)
    {
        yield return new WaitForSeconds(time);
        anyGO.SetActive(false);
    }

}
