using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    float timer;
    float cooldown;
    public Vector3 lookAtPoint;

    private EnemyInvoker invoker;

    public int lowRange = -20, highRange = 40;

    public GameObject projectile;

    public GameObject _parent;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        cooldown = Random.Range(0.3f, 4);
        lookAtPoint = new Vector3(_parent.transform.position.x, _parent.transform.position.y + Random.Range(lowRange, highRange), _parent.transform.position.z);
        invoker = gameObject.GetComponent<EnemyInvoker>();
    }

    // Update is called once per frame
    void Update()
    {


        transform.LookAt(lookAtPoint);

        lookAtPoint = new Vector3(_parent.transform.position.x, _parent.transform.position.y + Random.Range(lowRange, highRange), _parent.transform.position.z);

        Vector3 point = lookAtPoint;
        float size = 0.1f;
        float duration = 0;
        Color color = Color.green;

        Debug.DrawLine(point + Vector3.up * size, point - Vector3.up * size, color, duration);
        Debug.DrawLine(point + Vector3.right * size, point - Vector3.right * size, color, duration);
        Debug.DrawLine(point + Vector3.forward * size, point - Vector3.forward * size, color, duration);

        if (timer >= cooldown)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            PhysicsProjectile projectileScript = newProjectile.GetComponent<PhysicsProjectile>();
            if (projectileScript != null)
            {
                projectileScript.SetLookAtPoint(lookAtPoint);
            }

            StraightProjectile straightProjectileScript = newProjectile.GetComponent<StraightProjectile>();
            if (straightProjectileScript != null)
            {
                straightProjectileScript.SetLookAtPoint(lookAtPoint);
            }

            if (invoker != null)
            {
                invoker.Ctx.StateMachine.SwitchState(invoker.Ctx.StateMachine.CurrentState, invoker.Ctx.StateMachine.Factory.Attack());
                if (_parent.transform.position.x > invoker.Ctx.transform.position.x)
                {
                    invoker.Ctx.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    invoker.Ctx.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }

            timer = 0;
            cooldown = Random.Range(0.3f, 4);
         
        }
        else
        {
            timer += Time.deltaTime;
        }

        Debug.DrawLine(transform.position, transform.position + transform.forward * 100, Color.red);

    }
}
