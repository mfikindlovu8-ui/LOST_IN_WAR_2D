using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;

    void Update()
    {
        // You can add code here to trigger the enemy attack, for example, when the player is in range
    }

    void Attack()
    {
        // Detect players in range of attack
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        // Damage them
        foreach (Collider2D player in hitPlayers)
        {
            Debug.Log("Enemy hit " + player.name);
            // Here you can add code to damage the player
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

