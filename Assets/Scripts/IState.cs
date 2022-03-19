using UnityEngine;

public interface IState
{
    public void Action1(Context context);
    public void Action2(Context context);
    public void Action3(Context context);
}

public interface Context
{
    void SetState(IState newState);
}

public interface IContext
{
    void SetState(State state);
}

public class State : MonoBehaviour, Context
{
    private IState m_CurrentState;

    public void Action1() => m_CurrentState.Action1(this);
    public void Action2() => m_CurrentState.Action2(this);
    public void Action3() => m_CurrentState.Action3(this);

    void Context.SetState(IState newState)
    {
        m_CurrentState = newState;
    }
}

public class State1 : IState
{
    public void Action1(Context context)
    {
    }

    public void Action2(Context context)
    {
    }

    public void Action3(Context context)
    {
    }
}

public class State2 : IState
{
    public void Action1(Context context)
    {
        context.SetState(new State2());
    }

    public void Action2(Context context)
    {
        context.SetState(new State3());
    }

    public void Action3(Context context)
    {
    }
}

public class State3 : IState
{
    public void Action1(Context context)
    {
        context.SetState(new State1());
    }

    public void Action2(Context context)
    {
    }

    public void Action3(Context context)
    {
    }
}