using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeDie : MonoBehaviour
{
void OnCollisionEnter2D (Collision2D col)
{
if (col.gameObject.tag.Equals ("Bullet"))
{
Destroy (col.gameObject);
Destroy (gameObject);
}
 }
}
