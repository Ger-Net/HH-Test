using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    private Slot _slot;

    public void SetSlot(Slot slot)
    { 
        _slot = slot; 
    }
    public void Delete()
    {
        gameObject.SetActive(false);
        _slot.Delete();
    }
}
