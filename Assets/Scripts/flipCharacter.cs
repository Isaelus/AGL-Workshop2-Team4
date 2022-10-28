using System;
using UnityEngine;

public class flipCharacter : MonoBehaviour
{
    private bool FacingRight = true;
    
 
    // Start is called before the first frame update

 
    // Update is called once per frame
    void Update()
    {
        //find mouse position and transform it into the world position
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
 
        //and compare it with the needed "middle" point then flip if it is needed
        //here the player is the "middle"
        if (mousePos.x < transform.position.x && FacingRight)
        {
            Flip();
        }
        else
        if (mousePos.x > transform.position.x && !FacingRight)
        {
            Flip();
        }
 
    }
 
 
    void Flip ()
    {
        Vector3 tmpScale = transform.localScale;
        tmpScale.x = - tmpScale.x;
        transform.localScale = tmpScale;
        FacingRight = !FacingRight;
    }
 
}