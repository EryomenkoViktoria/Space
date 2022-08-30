using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
    [System.Serializable]
 public class PointStates : MonoBehaviour
 {
        public List<PointState> States = new List<PointState>();
 }

    [SerializeField]
    public enum PointState
    {
        Locked,
        Open,
        OneStar,
        TwoStars,
        ThreeStars
    }
}