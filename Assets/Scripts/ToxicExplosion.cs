using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicExplosion : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(AutoDestroy());
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(this.gameObject);
    }
}
