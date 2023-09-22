public interface IStateSwither
{
    void SwitchState<T>() where T : BaseState;
}