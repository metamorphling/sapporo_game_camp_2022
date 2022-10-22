using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]GameObject enemy;
    [SerializeField]List<GameObject> spawnPoints;
    [SerializeField]float spawnInterval;
    [SerializeField]GameObject parentObj;
    float countTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if(spawnInterval < countTime)
        {
            Spawn();
            countTime = 0;
        }
    }

    void Spawn()
    {
        foreach(var a in spawnPoints)
        {
            var obj = Instantiate(enemy, a.transform.position, enemy.transform.rotation);
            parentObj.transform.parent = a.transform;
        }
        
    }
}
