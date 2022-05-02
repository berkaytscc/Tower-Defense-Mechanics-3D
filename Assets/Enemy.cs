using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    GameObject pathGO; // parent path object
    Transform targetPathNode; // our objects to find our path
    int pathNodeIndex = 0; // children of the pathGO
    public float health = 3f;
    public int moneyValue = 5;
    float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        pathGO = GameObject.Find("Path");
    }

    void GetNextPathNode()
    {
        targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
        pathNodeIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (targetPathNode == null)
        {
            GetNextPathNode();
            if (targetPathNode == null)
            {
                // We've run out of path!
                ReachedGoal();
            }
        }

        Vector3 dir = targetPathNode.position - this.transform.position;

        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            // We reached the node.
            targetPathNode = null;
        }
        else
        {
            //TODO: Find a way to smooth this motion!
            // We move towards node
            this.transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime);
        }


    }
    void ReachedGoal()
    {
        GameObject.FindObjectOfType<ScoreManager>().LoseLife(); // When an enemy pass through, lose life!
        Destroy(gameObject);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    { 
        GameObject.FindObjectOfType<ScoreManager>().money += moneyValue;
        Destroy(gameObject);
    }
}
