using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameDevEVO 
{
    [RequireComponent(typeof(CapsuleCollider2D))]
 public abstract class BaseBonus : MonoBehaviour
 {
        private const float Speed=5f;
        [SerializeField]
        private UnityEvent Activated;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out PlayerMove playerMove))
            {
                Activate(playerMove.gameObject);
                Activated.Invoke();
                gameObject.SetActive(false);
            }
        }

        protected virtual void Activate(GameObject player)
        {

        }

        private void Update()
        {
            transform.Translate(Vector3.down * Speed * Time.deltaTime);
            if(transform.position.y < -12)
            {
                gameObject.SetActive(false);
            }
        }
    }
}