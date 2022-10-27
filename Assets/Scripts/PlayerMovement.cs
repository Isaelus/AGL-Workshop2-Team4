using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public const float MOVE_SPEED = 5f;
    bool canDash;
    public float dashDist = 3f;
    public float dashTime = 1f;
    public float dashCooldown = 0.5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 moveDir;
    Vector2 mousePos;

    // Update is called once per frame
    void Update() {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space)) {
            canDash = true;
        }
    }

    void FixedUpdate() {
        rb.velocity = moveDir * MOVE_SPEED;
        if(canDash)
            StartCoroutine(Dash());

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) + Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private IEnumerator Dash() {
        canDash = false;
        bool isDashing = true;
        rb.MovePosition((Vector2)transform.position + moveDir * dashDist);
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
    }
}
