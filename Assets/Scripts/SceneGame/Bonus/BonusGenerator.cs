using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class BonusGenerator : MonoBehaviour
 {
        [SerializeField] private BonusQueue m_BonusQueue;
        [SerializeField] private GameBonuseDataSO m_GameBonuseData;

        private List<int> m_BonusChance = new List<int>();
        private int m_MaxChance;

        private void Awake()
        {
            Calculate();
            
        }

        private void Calculate()
        {
            for (int i = 0; i < m_GameBonuseData.Bonuses.Count; i++)
            {
                m_MaxChance += m_GameBonuseData.Bonuses[i].Weight;
                m_BonusChance.Add(m_MaxChance);
            }
            m_BonusChance.Add(m_MaxChance * 3);
        }

        public bool TryGetBonus()
        {
            int chance = UnityEngine.Random.Range(0, m_BonusChance[m_BonusChance.Count-1]);
            bool yesChance = false;

            if (chance<m_MaxChance)
            {
                int min = 0;
                for (int i = 0; i < m_BonusChance.Count-1; i++)
                {
                    if (chance>= min && chance < m_BonusChance[i])
                    {
                        Generate(m_GameBonuseData.Bonuses[i].gameObject);
                        yesChance = true;
                        break;
                    }

                    min = m_BonusChance[i];
                }
            }

            return yesChance;
        }
        private void Generate(GameObject bonusPrefab)
        {
            GameObject bonus = Instantiate(bonusPrefab, m_BonusQueue.transform);
            bonus.SetActive(false);
            m_BonusQueue.AddObject(bonus);
        }
    }
}