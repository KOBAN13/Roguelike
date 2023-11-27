using System;
using AbstractFactory.CharacterFactory;
using UnityEngine;

namespace AbstractFactory
{
    public abstract class HumanoidFactory : global::CharacterFactory
    {
        public abstract void ArmYourself();
        
        public abstract void Initilizate(ConfigUnit configUnit);

    }
}