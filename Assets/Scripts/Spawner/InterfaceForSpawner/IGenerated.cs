using System;

namespace Enemy.Interface
{
    public interface IGenerated<in T>
    {
        Action<T> GenerateObject { get; }

        void OnGenerateUnit(T enemy);
    }
}