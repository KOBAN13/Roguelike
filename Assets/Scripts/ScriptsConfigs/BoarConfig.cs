using Enemy;
using Enemy.Interface;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "BoarConfig")]
    public class BoarConfig : ScriptableObject, IConfigable
    {
        [field: SerializeField] [field: Range(1, 15)] public float Speed { get; private set; }
        [field: SerializeField] [field: Range(1, 100)] public float MaxHealth { get; private set; }
        [field: SerializeField] [field: Range(1, 25)] public float Damage { get; private set; }
        [field: SerializeField] public Boar CertainPrefab { get; private set; }
        public float Armor { get; }
        public IPrefab Prefab => CertainPrefab;
    }
}