using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public int maxHealth = 5;
    public int currentHealth;
    public bool hitInvulnerable = false;
    public float hitInvulnerableDuration = 1f;
    public bool dodgeInvulnerable = false;
    public float dodgeInvulnerableDuration = 0.5f;
    public Collider2D hitbox;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        hitbox = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(DodgeIFrame());
        }
    }

    public void TakeDamage(int damage) {
        
        if (!hitInvulnerable) {
            StartCoroutine(HitIFrame());
        }
        else if (dodgeInvulnerable) {
            return;
        }
        else {
            return;
        }

        Debug.Log("AAAAA I got hit!");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0) {
            Death();
        }
    }

    public void Death() {
        Debug.Log("OUCHIE OUCH *dies*");
        Destroy(gameObject);
    }

    //shout out to Aleksandr Hovhannisyan on his website for the Iframe Code!
    private IEnumerator HitIFrame() {
        Debug.Log("Player Got Hit. HitI-Frame");
        hitInvulnerable = true;
        hitbox.enabled = false;

        yield return new WaitForSeconds(hitInvulnerableDuration);

        hitbox.enabled = true;
        hitInvulnerable = false;
        Debug.Log("Hit I-Frames Gone.");
    }

    private IEnumerator DodgeIFrame() {
        Debug.Log("Dodging...");
        dodgeInvulnerable = true;
        hitbox.enabled = false;
        
        yield return new WaitForSeconds(dodgeInvulnerableDuration);

        dodgeInvulnerable = false;
        hitbox.enabled = true;
        Debug.Log("Dodge I-Frames Gone.");

        yield return new WaitForSeconds(1.5f); // this needs to be the dodge cooldown.
    }

}
