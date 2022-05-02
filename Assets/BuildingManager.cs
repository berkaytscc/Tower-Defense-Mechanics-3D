using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    //TODO: Make an interface in order to select desired tower!
    public GameObject selectedTower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectTowerType(GameObject prefab) {
        selectedTower = prefab;
    }
}
