using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
    [RequireComponent(typeof(CapsuleCollider2D))]
 public class BulletCollision : MonoBehaviour
 {
        [SerializeField, Range(100, 500)]
        private int m_Damage = 150;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent( out IDamageable damageable))
            {
                damageable.TakeDamage(m_Damage);
            }
            ResetObject();
        }

        private void ResetObject()
        {
            transform.rotation = Quaternion.identity;
            gameObject.SetActive(false);
        }
    }
}