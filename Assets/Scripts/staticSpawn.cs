using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticSpawn : MonoBehaviour
{
   [SerializeField]
   private GameObject slimePrefab;

  [SerializeField]
   public float slimeInterval = 6f;



 
 // Start is called before the first frame update
    void Start()
    {
     // slimeInterval -=   GameObject.Find("player1").GetComponent<collectObjects>().gasCollected;
       StartCoroutine(spawnEnemy(slimeInterval, slimePrefab));
    


    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy){
     // debug.Log( "NUMBER OF GAAAAAAAAAAAAAAAAASSSSSS:  " + GameObject.Find("player1").GetComponent<collectObjects>().gasCollected); 
//interval -= gasFromPlayer; 
yield return new WaitForSeconds(interval);
//endless spawn
GameObject newEnemy = Instantiate(enemy, transform.position ,Quaternion.identity);

StartCoroutine( spawnEnemy (interval, enemy));

    }
 
}

