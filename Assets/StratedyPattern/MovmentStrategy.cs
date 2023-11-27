using System.Collections;
using System.Collections.Generic;
using StratedyPattern;
using UnityEngine;

public abstract class MovmentStrategy : IMovable, IJumpable, IRotating
{
    public abstract ParametersStrategyMovement _parametersStrategyMovement { get; set; }
    public virtual void Move()
    {
        Debug.Log("стою афк");
    }
    
    public virtual void Jump()
    {
        Debug.Log("не прыгаю");
    }
    
    public virtual void Rotate()
    {
        Debug.Log("не кручусь");
    }
}
