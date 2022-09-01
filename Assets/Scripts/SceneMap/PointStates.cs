using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
    [System.Serializable]
 public class PointStates : MonoBehaviour
 {
        public List<PointsStates> States = new List<PointsStates>();
 }

    [SerializeField]
    public enum PointsStates
    {
        Locked,
        Open,
        OneStar,
        TwoStars,
        ThreeStars
    }
}