using StratedyPattern;
using UnityEngine;

public class PlayerStrategy : MonoBehaviour
{
    public PlayerIdle PlayerIdle { get; private set; }
    public PlayerMovingToPrincess PlayerMovingToPrincessToPrincess { get; private set; }
    public PlayerMovingToOrk PlayerMovingToOrk { get; private set; }
    
    [SerializeField] private ParametersStrategyMovement parametersStrategyMovementToIdle;
    [SerializeField] private ParametersStrategyMovement parametersStrategyMovementToPrincess;
    [SerializeField] private ParametersStrategyMovement parametersStrategyMovementToOrk;

    private void Start()
    {
        PlayerIdle = new PlayerIdle();
        PlayerMovingToOrk = new PlayerMovingToOrk();
        PlayerMovingToPrincessToPrincess = new PlayerMovingToPrincess();

        PlayerIdle._parametersStrategyMovement = parametersStrategyMovementToIdle;
        PlayerMovingToOrk._parametersStrategyMovement = parametersStrategyMovementToOrk;
        PlayerMovingToPrincessToPrincess._parametersStrategyMovement = parametersStrategyMovementToPrincess;
    }
}

public class PlayerIdle : MovmentStrategy
{
    public override ParametersStrategyMovement _parametersStrategyMovement { get; set; }

    public void LaunchAStrategy()
    {
        Move();
        Jump();
        Rotate();
    }
}

public class PlayerMovingToPrincess : MovmentStrategy
{
    public override ParametersStrategyMovement _parametersStrategyMovement { get; set; }

    public void LaunchAStrategy()
    {
        Move();
        Jump();
        Rotate();
    }
    public override void Move()
    {
        Debug.Log("иду спасать принцессу со скоростью" + _parametersStrategyMovement.SpeedMove);
    }

    public override void Jump()
    {
        Debug.Log("прыгаю через припядствия c силой прыжка" + _parametersStrategyMovement.ForceJump);
    }

    public override void Rotate()
    {
        Debug.Log("принцесса крутиться у меня на хуе со скоростью" + _parametersStrategyMovement.RotateCharacter);
    }
}


public class PlayerMovingToOrk : MovmentStrategy
{
    public override ParametersStrategyMovement _parametersStrategyMovement { get; set; }
    
    public void LaunchAStrategy()
    {
        Move();
        Jump();
        Rotate();
    }
    
    public override void Move()
    {
        Debug.Log("иду c орку ебашиться со скоростью" + _parametersStrategyMovement.SpeedMove);
    }

    public override void Jump()
    {
        Debug.Log("пргаю около орка нанося удары с силой прыжка" + _parametersStrategyMovement.ForceJump);
    }

    public override void Rotate()
    {
        Debug.Log("кручусь как юла от ударов орка" + _parametersStrategyMovement.RotateCharacter);
    }
}
