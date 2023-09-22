using UnityEngine;

public abstract class ActionButton : MonoBehaviour
{
    protected Slot _slot;

    public void SetSlot(Slot slot)
    {
        _slot = slot;
    }
}
