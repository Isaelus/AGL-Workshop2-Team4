using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticSpawn : MonoBehaviour
{
   [SerializeField]
   private GameObject slimePrefab;

  [SerializeField]
  //max enemy interval when spawning
   public float slimeInterval;



 
 // Start is called before the first frame update
    void Start()
    {

        slimeInterval = 6f;
        //calls to start coroutine which spawns enemy

        StartCoroutine(spawnEnemy(slimeInterval, slimePrefab));
   


    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy){
   
yield return new WaitForSeconds(interval);
        //I set the interval to lower if a gas tank is collected
        // we reset back to the max interval to repeat process
        //CHANGE MAX INTERVAL CHANGE THIS INTERVAL VALUE
        interval = 6;
//endless spawn at spawner position
GameObject newEnemy = Instantiate(enemy, transform.position ,Quaternion.identity);
        //gets and compares gas collected from object player1 (our player current name) to reduce enemy spawn rate up to -5
        if (GameObject.Find("player1").GetComponent<collectObjects>().gasCollected == 1) {
            interval -= 1;
            StartCoroutine(spawnEnemy(interval, enemy));
           
        } else if (GameObject.Find("player1").GetComponent<collectObjects>().gasCollected == 2) {
            interval -= 2;
            StartCoroutine(spawnEnemy(interval, enemy));
           

        }
        else if (GameObject.Find("player1").GetComponent<collectObjects>().gasCollected == 3) {
            interval -= 3;
            StartCoroutine(spawnEnemy(interval, enemy));
           


        }
        else if (GameObject.Find("player1").GetComponent<collectObjects>().gasCollected == 4)
        {
            interval -= 4;
            StartCoroutine(spawnEnemy(interval, enemy));



        }
        else if (GameObject.Find("player1").GetComponent<collectObjects>().gasCollected ==5)
        {
            interval -= 5;
            StartCoroutine(spawnEnemy(interval, enemy));



        }
        else
        //normal start spawn rate when no gas is collected
        {
            StartCoroutine(spawnEnemy(interval, enemy));
        }
    }
 
}
