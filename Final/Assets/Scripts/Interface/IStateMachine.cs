using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachine<T> where T : IBaseState<T>
{
    abstract void SetCurrentState(T baseState);
    public abstract void SwitchState(T oldState, T newState);
}
