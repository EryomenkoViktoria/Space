using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class PointStatesData : MonoBehaviour
 {
        private const string Key = "StatesData";

        public void Save(PointStates pointStates)
        {
            PlayerPrefs.SetString(Key, JsonUtility.ToJson(pointStates));
            PlayerPrefs.Save();
        }

        public PointStates Load()
        {
            if (PlayerPrefs.HasKey(Key))
            {
                return JsonUtility.FromJson<PointStates>(PlayerPrefs.GetString(Key));
            }

            return null;
        }
 }
}