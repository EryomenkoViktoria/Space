using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class CannonSingle : CannonBase
 {
        [SerializeField]
        private Transform m_BulletStartPosition;

        public override void Shot()
        {
            BulletActivate(m_BulletStartPosition);
        }
    }
}