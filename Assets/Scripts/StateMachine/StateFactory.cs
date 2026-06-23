using System;
using System.Collections.Generic;

public class StateFactory<T> 
{
    private T _ctx;
    private Dictionary<Type, State<T>> _states = new();

    public StateFactory(T ctx)
    {
        _ctx = ctx;
    }

    public State<T> Get<TState>() where TState : State<T>
    {
        Type t = typeof(TState);

        if (!_states.ContainsKey(t))
        {
            var state = (TState) Activator.CreateInstance(t, _ctx, this);
            _states[t] = state;
        }
        
        return _states[t];
    }
}