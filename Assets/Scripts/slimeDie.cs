using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class slimeDie : MonoBehaviour

{
    
void OnCollisionEnter2D (Collision2D col)
{
if (col.gameObject.tag.Equals ("Bullet"))
{
Destroy (col.gameObject);
Destroy (gameObject);
} 
if (col.gameObject.tag.Equals("Player")){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
 }
}
