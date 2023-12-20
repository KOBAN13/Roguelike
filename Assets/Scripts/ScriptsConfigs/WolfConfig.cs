using Enemy;
using Enemy.Interface;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "WolfConfig")]
    public class WolfConfig : ScriptableObject, IConfigable
    {
        [field: SerializeField] [field: Range(1, 65)] public float Speed { get; private set; }
        [field: SerializeField] [field: Range(1, 70)] public float MaxHealth { get; private set; }
        [field: SerializeField] [field: Range(1, 23)] public float Damage { get; private set; }
        [field: SerializeField] public Wolf CertainPrefab { get; private set; }
        public IPrefab Prefab => CertainPrefab;
        public float Armor { get; }
    }
}