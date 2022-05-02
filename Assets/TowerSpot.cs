using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    // OnMouseDown runs when you click the object that script is attached to!
    private void OnMouseDown() { 
        ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
        BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
        
        if(bm.selectedTower != null) {
            if(sm.money < bm.selectedTower.GetComponent<Tower>().cost) {
                Debug.Log("Not enough money!");
                return;
            } 
            sm.money -= bm.selectedTower.GetComponent<Tower>().cost;   
            Instantiate(bm.selectedTower, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
