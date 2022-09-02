using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GameDevEVO
{
    public class BulletsGenerator : EditorWindow
    {
        private readonly GUIStyle m_TitleText = new GUIStyle();
        private Sprite m_Sprite;
        private ColliderType m_ColliderType;
        private BulletsType m_BulletsType;
        private GameObject m_Effect;

        public string AssetsData { get; private set; }

        [MenuItem("Window/My editor/Bullet prefabs")]
        public static void Init()
        {
            BulletsGenerator bulletsGenerator = GetWindow<BulletsGenerator>("Generator prefabov");
            bulletsGenerator.Show();
        }


        private void OnEnable()
        {
            TextStyle();
        }
        private void TextStyle()
        {
            m_TitleText.alignment = TextAnchor.MiddleCenter;
            m_TitleText.fontSize = 14;
            m_TitleText.fontStyle = FontStyle.Bold;
        }
        private void OnGUI()
        {
            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField("Setting for prefabs", m_TitleText);
            EditorGUILayout.Space(5);

            GUILayout.BeginHorizontal("box");
            EditorGUILayout.LabelField("Sprite for prefab");
            m_Sprite = (Sprite)EditorGUILayout.ObjectField(m_Sprite, typeof(Sprite), false);
            GUILayout.EndHorizontal();
            EditorGUILayout.Space(5);

            GUILayout.BeginHorizontal("box");
            m_ColliderType = (ColliderType)EditorGUILayout.EnumPopup(m_ColliderType);
            EditorGUILayout.LabelField("Collider type");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal("box");
            m_BulletsType = (BulletsType)EditorGUILayout.EnumPopup(m_BulletsType);
            EditorGUILayout.LabelField("Bullet type");
            GUILayout.EndHorizontal();

            if (m_BulletsType == BulletsType.Type3)
            {
                EditorGUILayout.Space(5);
                GUILayout.BeginHorizontal("box");
                m_Effect = (GameObject)EditorGUILayout.ObjectField(m_Effect, typeof(GameObject), false);
                EditorGUILayout.LabelField("Effect bullet");
                GUILayout.EndHorizontal();
            }

            EditorGUILayout.Space(5);
            if (GUILayout.Button("New Prefab"))
            {
                var go = new GameObject("Bullet");
                go.AddComponent<SpriteRenderer>().sprite = m_Sprite;

                AddCollider(go);
                AddBulletType(go);

                string path = "Assets/Scripts/Tools/ForPrefabs/" + go.name + ".prefab";
               // string path = "Assets/Prefabs/" + go.name + ".prefab";
                path = AssetDatabase.GenerateUniqueAssetPath(path);
                PrefabUtility.SaveAsPrefabAsset(go, path);
                DestroyImmediate(go);
            }
        }

        private void AddBulletType(GameObject go)
        {
            go.AddComponent<BulletMove1>();
            switch (m_BulletsType)
            {
                case BulletsType.Type1:
                    go.AddComponent<BulletType1>();
                    break;
                case BulletsType.Type2:
                    go.AddComponent<BulletType1>();
                    go.AddComponent<BulletType2>();
                    break;
                case BulletsType.Type3:
                    go.AddComponent<BulletType2>();
                    if (m_Effect)
                        PrefabUtility.InstantiatePrefab(m_Effect, go.transform);
                    break;
            }
        }
            private void AddCollider(GameObject go)
        {
            switch (m_ColliderType)
            {
                case ColliderType.PoligonCollider2D:
                    go.AddComponent<PolygonCollider2D>();
                    break;
                case ColliderType.CapsuleCollider2d:
                    go.AddComponent<CapsuleCollider2D>();
                    break;
            }
        }
        

        public enum ColliderType
        {
            PoligonCollider2D,
            CapsuleCollider2d
        }

        public enum BulletsType
        {
            Type1,
            Type2,
            Type3
        }
    }
}