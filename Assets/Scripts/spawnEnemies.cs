using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
   [SerializeField]
   private GameObject slimePrefab;
  [SerializeField]
   private GameObject bossPrefab;
  [SerializeField]
   private float slimeInterval = 5f;
  [SerializeField]
   private float bossInterval = 15f;


 
 // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(spawnEnemy(slimeInterval, slimePrefab));
       StartCoroutine(spawnEnemy(bossInterval, bossPrefab));


    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private IEnumerator spawnEnemy(float interval, GameObject enemy){

yield return new WaitForSeconds(interval);
//endless spawn
GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f,5),Random.Range(-6f,6f),0),Quaternion.identity);
StartCoroutine( spawnEnemy (interval, enemy));

    }
 
}
