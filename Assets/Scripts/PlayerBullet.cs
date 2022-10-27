using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private int damage = 1;

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Hit!");
        Destroy(gameObject);
    }
}
