﻿using Enemy;
using Enemy.Interface;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "HumanConfig")]
    public class HumanConfig : ScriptableObject, IConfigable
    {
        [field: SerializeField] [field: Range(1, 45)] public float Speed { get; private set; }
        [field: SerializeField] [field: Range(1, 45)] public float MaxHealth { get; private set; }
        [field: SerializeField] [field: Range(1, 48)] public float Damage { get; private set; }
        [field: SerializeField] [field: Range(1, 25)] public float Armor { get; private set; }
        [field: SerializeField] public Human CertainPrefab { get; private set; }
        public IPrefab Prefab => CertainPrefab;
    }
}