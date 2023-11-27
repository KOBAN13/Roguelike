using System;
using System.Collections.Generic;

namespace Enemy
{
    public interface IInherited
    {
        public List<Type> GetAllClassesOfEnemies();
    }
}