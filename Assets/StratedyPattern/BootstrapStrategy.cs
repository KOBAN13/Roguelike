using StratedyPattern;
using UnityEngine;
using UnityEngine.Serialization;

public class BootstrapStrategy : MonoBehaviour
{
    [FormerlySerializedAs("_player")] [SerializeField] private PlayerStrategy playerStrategy;
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
           playerStrategy.PlayerIdle.LaunchAStrategy();
        }

        if (Input.GetKey(KeyCode.W))
        { 
            playerStrategy.PlayerMovingToOrk.LaunchAStrategy();
        }

        if (Input.GetKey(KeyCode.E))
        {
            playerStrategy.PlayerMovingToPrincessToPrincess.LaunchAStrategy();
        }
    }
}
