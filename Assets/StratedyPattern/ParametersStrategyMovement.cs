using System;
using UnityEngine;

namespace StratedyPattern
{
    [CreateAssetMenu(fileName = "ParametersMovement")]
    public class ParametersStrategyMovement : ScriptableObject
    {
        [field: SerializeField] public float SpeedMove { get; private set; }
        [field: SerializeField] public float RotateCharacter { get; set; }
        [field: SerializeField] public float ForceJump { get; set; }
    }
}