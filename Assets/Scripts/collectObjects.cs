using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectObjects : MonoBehaviour
{
    public float gasCollected;
   
    private bool wingCollected;
    private bool fullGas;
    private bool fullHealth;
    private float gasNeeded;
    private float health;


    // Start is called before the first frame update
    void Start()
    { 
        gasCollected = 0;
      
        wingCollected = false;
        fullGas = false;
        gasNeeded = 5;
        //TODO 
        //Integrate player health to check if he can eat
        // currently health is initially set to false this will be changed
        fullHealth = true;
        health = 5;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collectable){
       if (collectable.gameObject.CompareTag("Gas") && !fullGas ){

            Destroy(collectable.gameObject);
            gasCollected = gasCollected+1;
            if(gasCollected == gasNeeded){
                    fullGas = true;


            }
       }
       else if (collectable.gameObject.CompareTag("Food") && !fullHealth){
         
         Destroy(collectable.gameObject);
            health += 1;


       }
       else if (collectable.gameObject.CompareTag("Wing")){
            Destroy(collectable.gameObject);
             wingCollected = true;


        } else if (collectable.gameObject.CompareTag("Ship")){

                if(fullGas && wingCollected){
                        //GAME FINISHED

                }

        }

    }
}
