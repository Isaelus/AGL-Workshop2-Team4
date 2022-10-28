using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public const float MOVE_SPEED = 5f;
    bool canDash = true;
    bool canMove = true;
    public float dashSpeed = 10f;
    public float dashTime = 0.25f;
    public float dashCooldown = 1f;
    float currentDashTime;
    float currentCooldown;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 moveDir;
    Vector2 mousePos;

    // Update is called once per frame
    void Update() {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space) && canDash) {
            StartCoroutine(Dash(moveDir));
        }
    }

    void FixedUpdate() {
        if (canMove) 
            rb.velocity = moveDir * MOVE_SPEED;

        // Vector2 lookDir = mousePos - rb.position;
        // float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        // rb.rotation = angle;
    }

    private IEnumerator Dash(Vector2 direction) {
        canDash = false;
        canMove = false;
        currentDashTime = dashTime;
        while (currentDashTime > 0f) {
            currentDashTime -= Time.deltaTime;
            
            if (direction.x != 0 && direction.y != 0) {
                float diagSpeed = (dashSpeed / 2) + 1;
                rb.velocity = direction * diagSpeed;
            } else {
                rb.velocity = direction * dashSpeed;
            }
                
            yield return null;
        }
        
        rb.velocity = new Vector2(0f, 0f);
        
        currentCooldown = dashCooldown;
        while (currentCooldown > 0f) {
            currentCooldown -= Time.deltaTime;
            canMove = true;
            yield return null;
        }
        canDash = true;
    }
}
