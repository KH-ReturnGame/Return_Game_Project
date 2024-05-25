public abstract class State
{
    public abstract void Enter(Player entity);
    public abstract void Execute(Player entity);
    public abstract void Exit(Player entity);
}
