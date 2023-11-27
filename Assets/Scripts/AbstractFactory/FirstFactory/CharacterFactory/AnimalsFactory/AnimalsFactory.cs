using AbstractFactory.CharacterFactory;

namespace AbstractFactory
{
    public abstract class AnimalsFactory : global::CharacterFactory
    {
        public abstract void ImproveSomeCharacteristics();

        public abstract void Initilizate(ConfigUnit configUnit);
    }
}