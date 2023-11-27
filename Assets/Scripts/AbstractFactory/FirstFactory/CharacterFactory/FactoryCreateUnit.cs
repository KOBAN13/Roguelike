using AbstractFactory.CharacterFactory;

namespace AbstractFactory
{
    public abstract class FactoryCreateUnit<TAnimals, THumanoids>
    {
        public abstract TAnimals GetAnimal(TAnimals createAnimal);
        public abstract THumanoids GetHumanoid(THumanoids createHumanoid);
    }
}