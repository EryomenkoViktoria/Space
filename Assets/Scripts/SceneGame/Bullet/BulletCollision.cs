using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
    [RequireComponent(typeof(CapsuleCollider2D))]
 public class BulletCollision : MonoBehaviour
 {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            ResetObject();
        }

        private void ResetObject()
        {
            transform.rotation = Quaternion.identity;
            gameObject.SetActive(false);
        }
    }
}