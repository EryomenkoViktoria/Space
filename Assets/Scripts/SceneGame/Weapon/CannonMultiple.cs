using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class CannonMultiple : CannonBase
 {
        [SerializeField]
        private List<Transform> m_BulletStart;

        public override void Shot()
        {
            foreach(var item in m_BulletStart)
            {
                BulletActivate(item);
            }
        }
    }
}