using System;

namespace Enemy.Interface
{
    public interface IDied<T>
    {
        Action<T> Died { get; set; }

        public void OnDiedUnit(T player);
    }
}