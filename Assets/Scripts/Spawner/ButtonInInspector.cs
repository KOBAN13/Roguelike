using System;
using UnityEditor;
using UnityEngine;

namespace AbstractFactory.SecondFactory
{
    [CustomEditor(typeof(EnemySpawn))]
    public class ButtonInInspector : Editor
    {
        private EnemySpawn _enemySpawn;

        public void OnEnable()
        {
            _enemySpawn = (EnemySpawn)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Spawn Enemy"))
            {
                _enemySpawn.StartSpawnEnemy();
            }

            if (GUILayout.Button("Stop Spawn"))
            {
                _enemySpawn.StopSpawnEnemy();
            }
        }
    }
}