public class DeleteButton : ActionButton
{
    public void Delete()
    {
        gameObject.SetActive(false);
        _slot.Delete();
        Player.Instance.DeleteItem(_slot.Index);
    }
}
