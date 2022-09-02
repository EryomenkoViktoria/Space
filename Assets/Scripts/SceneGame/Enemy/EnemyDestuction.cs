using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class EnemyDestuction : MonoBehaviour
 {
        public void Activate()
        {
            Destroy(gameObject);
        }
 }
}