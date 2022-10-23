using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]GameObject enemy;
    [SerializeField]List<GameObject> spawnPoints;
    [SerializeField]float spawnInterval;
    [SerializeField]GameObject parentObj;
    [SerializeField]bool IsSpawning;
    float countTime;
    public AudioClip spawn;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        countTime = spawnInterval;
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
        if (IsSpawning == false)
        {
            return;
        }
        foreach(var a in spawnPoints)
        {
            audioSource.PlayOneShot(spawn);
            var obj = Instantiate(enemy, a.transform.position, enemy.transform.rotation);
            var param = obj.GetComponent<CharacterParameters>();
            if (param)
            {
                param.Init(false, Game.Level);
            }
            parentObj.transform.parent = a.transform;
        }
        
    }
}
