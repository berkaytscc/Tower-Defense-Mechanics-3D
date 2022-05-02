using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float spawnCD = 0.25f;
    float spawnCDremaning = 0f;
    [System.Serializable] public class WaveComponent {
        public GameObject enemyPrefab;
        public int howManyEnemies;
        [System.NonSerialized] public int spawned = 0;
    }
    public WaveComponent[] waveComps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnCDremaning -= Time.deltaTime;
        if(spawnCDremaning < 0) {
            spawnCDremaning = spawnCD;
            bool didSpawn = false;
            // Go through the wave comps until we find something to spawn
            foreach(WaveComponent wc in waveComps) {
                if(wc.spawned < wc.howManyEnemies) {
                    // spawn it!
                    wc.spawned++;
                    Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation);
                    didSpawn = true;
                    break;
                }
            }
            if(didSpawn == false) {
                //Wave must be complete!
                //TODO: Instantiate next wave object!
                Destroy(gameObject);
            }
        }
    }
}
