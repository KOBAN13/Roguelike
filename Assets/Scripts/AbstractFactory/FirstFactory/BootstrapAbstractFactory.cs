using System;
using System.Collections.Generic;
using AbstractFactory.CharacterFactory;
using UnityEngine;

namespace AbstractFactory
{
    public class BootstrapAbstractFactory : MonoBehaviour
    {
        private CreateConcreteUnit<Boar, Human> _createConcreteUnit;
        private CreateConcreteUnit<Wolf, Ork> _createUnit;
        [SerializeField] private List<ConfigUnit> configs;

        private void Awake()
        {
            _createConcreteUnit = new CreateConcreteUnit<Boar, Human>();
            _createUnit = new CreateConcreteUnit<Wolf, Ork>();
            
            Boar = _createConcreteUnit.GetAnimal(Boar);
            Human = _createConcreteUnit.GetHumanoid(Human);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Boar.Initilizate(configs[0]);
                Boar.Move();
                Boar.Damage();
                Boar.ImproveSomeCharacteristics();
                
                Human.Initilizate(configs[1]);
                Human.Move();
                Human.Damage();
                Human.ArmYourself();
            }
        }

        public Human Human { get; set; }

        public Boar Boar { get; set; }
    }
}