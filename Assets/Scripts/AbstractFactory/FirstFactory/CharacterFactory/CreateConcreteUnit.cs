
namespace AbstractFactory.CharacterFactory
{
    public class CreateConcreteUnit<TAnimals, THumanoids> : FactoryCreateUnit<TAnimals, THumanoids> where TAnimals : new() where THumanoids : new()
    {
        public override TAnimals GetAnimal(TAnimals createAnimal) => new TAnimals();

        public override THumanoids GetHumanoid(THumanoids createHumanoid) => new THumanoids();
    }
}