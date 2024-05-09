using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AttackInitializer : CoreComponent
{
    public Collider2D coll;
    public DamageData data;
    public Player player;

    [Inject] InGameData _data;

    void Start()
    {
        data = new DamageData(10.0f, player.gameObject);
    }

    public void OnAttack()
    {
        coll.enabled = true;
    }

    public void OnAttackEnd()
    {
        coll.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.CompareTag("DestructableProjectile"));
        if (collision.gameObject.CompareTag("DestructableProjectile"))
        {
            Destroy(collision.gameObject);
            _data.points += 10;
            _data.cutBookCounter++;

        }
        else
        {
            collision.gameObject.GetComponentInChildren<Core>().GetComponentInChildren<DamageReceiver>().Damage(data);
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DestructableProjectile"))
        {
            Destroy(collision.gameObject);
            _data.points += 10;
            _data.cutBookCounter++;
        }
    }
}
