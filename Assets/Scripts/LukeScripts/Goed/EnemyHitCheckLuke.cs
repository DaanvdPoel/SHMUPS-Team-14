using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitCheckLuke : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Bullet"))
        {
            GetComponentInParent<EnemyScriptLuke>().TakeDamage(-1);
        }
    }
}
