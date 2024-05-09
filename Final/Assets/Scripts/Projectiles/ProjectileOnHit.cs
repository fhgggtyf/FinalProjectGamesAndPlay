using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOnHit : MonoBehaviour
{
    DamageData data;

    public int i = 1;
    private void Start()
    {
        data = new DamageData(i, gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<Core>() != null)
        {
            collision.gameObject.GetComponentInChildren<Core>().GetComponentInChildren<DamageReceiver>().Damage(data);
            Destroy(gameObject);
        }
    }
}
