using Enemy;
using Enemy.Interface;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "OrkConfig")]
    public class OrkConfig : ScriptableObject, IConfigable
    {
        [field: SerializeField] [field: Range(1, 7)] public float Speed { get; private set; }
        [field: SerializeField] [field: Range(1, 567)] public float MaxHealth { get; private set; }
        [field: SerializeField] [field: Range(1, 43)] public float Damage { get; private set; }
        [field: SerializeField] [field: Range(1, 50)] public float Armor { get; private set; }
        [field: SerializeField] public Ork CertainPrefab { get; private set; }
        public IPrefab Prefab => CertainPrefab;
    }
}
