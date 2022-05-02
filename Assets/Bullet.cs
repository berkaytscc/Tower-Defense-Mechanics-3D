using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Enemy enemyScript;
    public float speed = 15f;
    public Transform target; // Enemy transform component
    public float damage = 1f;

    public float radius = 0;

    public LayerMask enemyLayer; // enemy layer in order to prevent unwanted collider detection!

    void Update()
    {
        if(target == null)  // if enemy dies and the bullet is still on it's way!
        {
            Destroy(gameObject);
        }
        Vector3 dir = target.position - this.transform.position;

        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            // We reached the enemy.
            DoBulletHit();
        }
        else
        {
            //TODO: Find a way to smooth this motion!
            // Bullet moves towards enemy
            this.transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime);
        }
    }

    public void DoBulletHit()
    {
        //TODO: what if it's an explosive bullet that effects the area.
        if(radius == 0) {
            target.GetComponent<Enemy>().TakeDamage(damage); // Enemy script on the target gameObject
        }
        else{ // Now everything with in the radius will take damage!
            Collider[] cols = Physics.OverlapSphere(transform.position, radius, enemyLayer); 
            foreach(Collider e in cols) {
                if(e != null) {
                    //TODO: You could do a falloff damage based on distance, but that's rare for TD games.
                    e.GetComponent<Enemy>().TakeDamage(damage);
                    
                    //TODO: Maybe spawn a cool explosion object here?
                    Destroy(gameObject); // bullet self-destructs
                }
            }
        }
    }
}
