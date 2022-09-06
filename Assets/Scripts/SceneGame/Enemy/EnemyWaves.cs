using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class EnemyWaves : MonoBehaviour
 {
        [SerializeField]
        private BonusGenerator m_BonusGenerator;
        [SerializeField]
        private BonusQueue m_BonusQueue;
        private LevelData m_Level;
        private int m_IndexWave;
        private int m_IndexEnemy;


        private List<GameObject> m_Enemies = new List<GameObject>();

        private void Awake()
        {
            int index = new LevelNameData().GetLevelIndex();
            m_Level = Resources.Load<LevelData>($"Levels/Level{index}");
        }

        public void Generate()
        {
            int offset = 2;
            Vector2 startPosition = new Vector2(0, new SafeAreaData().GetMax().y + offset);

            foreach (var wave in m_Level.Waves)
            {
                for (int i = 0; i < wave.CountInWave; i++)
                {
                    var enemy = Instantiate(wave.EnemyPrefab,transform);
                   
                    if( enemy.TryGetComponent(out EnemyBonusDrop enemyBonusDrop))
                    {
                        enemyBonusDrop.SetBonusQueue(m_BonusQueue);
                        enemyBonusDrop.SetHaveBonus(m_BonusGenerator.TryGetBonus());
                    }
                    
                    
                    enemy.transform.position = startPosition;
                    enemy.SetActive(false);
                    m_Enemies.Add(enemy);
                }
            }
        }

        public void Activate()
        {
            StartCoroutine(EnemyActivate());
        }

        private IEnumerator EnemyActivate()
        {
            WaitForSeconds wait =  new WaitForSeconds(0.5f);
            var count = m_Level.Waves[m_IndexWave].CountInWave;

            while (count > 0)
            {
                count--;
                m_Enemies[m_IndexEnemy].gameObject.SetActive(true);
                m_IndexEnemy++;
                yield return wait;
            }

            if(m_IndexWave < m_Level.Waves.Count - 1)
            {
                Invoke(nameof(Activate), m_Level.Waves[m_IndexWave].WaitAfterWave);
                m_IndexWave++;
            }
        }

      
    }
}