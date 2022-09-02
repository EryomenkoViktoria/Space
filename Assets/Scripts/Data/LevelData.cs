using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
    [CreateAssetMenu(fileName = "Level1", menuName = "GameSO/Level")]
    public class LevelData : ScriptableObject
    {

        public List<Wave> Waves = new List<Wave>();
    }

    [System.Serializable]
    public class Wave
    {
        public GameObject EnemyPrefab;
        [Range(0, 100)]
        public int CountInWave;
        [Range(0, 360)]
        public int WaitAfterWave;
    }
}