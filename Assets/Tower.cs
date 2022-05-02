using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Transform turretTransform;
    public GameObject bulletPrefab;
    public float radius = 0;
    public float damage = 1;
    public int cost = 25; 
    float range = 10f;
    float fireCoolDown = 0.5f;
    float fireCoolDownLeft = 0f;

    void Start()
    {
        turretTransform = transform.Find("TowerBody"); // transform.Find returns a transform.
    }

    void Update()
    {
        //TODO: Optimize this!
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>(); // Enemies

        Enemy nearestEnemy = null;
        float dist = Mathf.Infinity;

        foreach(Enemy e in enemies)
        {
            float d = Vector3.Distance(this.transform.position, e.transform.position); // distance between tower and the enemy.
            if (nearestEnemy == null || d < dist)
            {
                nearestEnemy = e;
                dist = d;
            }
        }

        if (nearestEnemy == null)
        {
            //Debug.Log("No enemies?");
            return;
        }

        Vector3 dir = nearestEnemy.transform.position - this.transform.position; // Vector3 coordinates of the position to look at
        Quaternion lookRot = Quaternion.LookRotation(dir); // quaternion value to rotate.
        turretTransform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0); // rotates turret to the nearest enemy

        fireCoolDownLeft -= Time.deltaTime; // 0.5 seconds cool down
        if (fireCoolDownLeft <= 0 && dir.magnitude <= range)
        {
            fireCoolDownLeft = fireCoolDown;
            Shoot(nearestEnemy);
        }
    }

    void Shoot(Enemy e)
    {
        GameObject bulletGO = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        
        Bullet b = bulletGO.GetComponent<Bullet>();
        b.target = e.transform; // target of the bullet script is equal to the enemy transform.
        b.damage = damage;
        b.radius = radius;
    }
}
