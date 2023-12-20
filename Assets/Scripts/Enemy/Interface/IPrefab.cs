using UnityEngine;

namespace Enemy.Interface
{
    public interface IPrefab
    {
        Object Prefab { get; }
        IPrefab GetPrefab();
    }
}

