public class UseButton : ActionButton
{
    public void Use()
    {
        Player.Instance.UseItem(_slot.Index);
    }
}
