using UnityEngine;

namespace AbstractFactory.CharacterFactory
{
    [CreateAssetMenu(menuName = "ConfigUnit", fileName = "CreateConfig")]
    public class ConfigUnit : ScriptableObject
    {
        [field: SerializeField] public float DamageTo { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Health { get; private set; }
    }
}