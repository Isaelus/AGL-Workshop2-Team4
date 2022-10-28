using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;

public class collectObjects : MonoBehaviour
{
        public SpriteRenderer changesSprite;
        public Sprite wingedShip;
        public Sprite fullShip;
    public float gasCollected;
   
    private bool wingCollected;
    private bool fullGas;
    private bool fullHealth;
    private float gasNeeded;
    private float health;
    public TMP_Text gasText;
    public TMP_Text youNeedWings;

    // Start is called before the first frame update
    void Start()
    { 
         
        gasCollected = 0;      
        gasText.text = gasCollected.ToString() +"/5";
      
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
    /*
    *if statements when colliding with 
    * FOOD, GAS , WINGS, & SHIP
    */
    void OnTriggerEnter2D(Collider2D collectable){
        //checks if gas is full if not then collect gas
       if (collectable.gameObject.CompareTag("Gas") && !fullGas ){

            Destroy(collectable.gameObject);
            gasCollected = gasCollected+1;
             gasText.text = gasCollected.ToString()+"/5";
        
            if(gasCollected == gasNeeded){
                    fullGas = true;


            }
       }
       //checks if health is full if not then allowed to eat
       else if (collectable.gameObject.CompareTag("Food") && !fullHealth){
         
         Destroy(collectable.gameObject);
            health += 1;


       }
       // collect the wing
       else if (collectable.gameObject.CompareTag("Wing")){
            Destroy(collectable.gameObject);
             wingCollected = true;


        } 
        //GET IN SHIP 
        else if (collectable.gameObject.CompareTag("Ship")){
                if(wingCollected){
                //Adds wings to ship
                        changesSprite.sprite = wingedShip;
                }
                if(fullGas && !wingCollected){
                        //calls coroutine to remove text after x seconds
                         StartCoroutine(popupText());
                        
                          
                }

                if(fullGas && wingCollected){
                        //GAME FINISHED
                        //sprite changed to full
                         changesSprite.sprite = fullShip;

                }

        }

    }
    //pops text waits 4 second and removes text
    IEnumerator popupText(){
         youNeedWings.text = "you need WINGS to fly";
        yield return new WaitForSeconds(4f);
         youNeedWings.text = "";

    }
}
