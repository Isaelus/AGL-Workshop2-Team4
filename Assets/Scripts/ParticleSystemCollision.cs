using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other) {
        if (other.TryGetComponent(out Player player)) {
            if (player.dodgeInvulnerable) {
                return;
            }
            Debug.Log("Particle Hit! " + other.name);
            player.TakeDamage(1);
        }
    }
}
