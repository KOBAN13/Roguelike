using Configs;

namespace Enemy.Interface
{
    public interface IVisitorEnemyConfigs
    {
        void Visit(BoarConfig boar);
        void Visit(WolfConfig wolf);
        void Visit(HumanConfig human);
        void Visit(OrkConfig ork);
        void VisitConfig(IConfigable config);
    }
}