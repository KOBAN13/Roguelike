using Enemy;
using Enemy.Interface;
using PlayerScripts;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Player Config")]
    public class PlayerConfig : ScriptableObject, IConfigable
    {
        [field: SerializeField] [field: Range(1, 15)] public float Speed { get; private set; }
        [field: SerializeField] [field: Range(1, 1500)] public float MaxHealth { get; private set; }
        [field: SerializeField] [field: Range(1, 25)] public float Damage { get; private set; }
        [field: SerializeField] [field: Range(1, 25)] public float Armor { get; private set; }

        [field: SerializeField] public Player CertainPrefab { get; set; }
        public IPrefab Prefab { get; }
    }
}