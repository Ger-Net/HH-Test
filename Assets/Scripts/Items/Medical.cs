using UnityEngine;

[CreateAssetMenu()]
public class Medical : ItemData
{
    [SerializeField] private int _healAmount;
    public void Heal()
    {
        Player.Instance.Health += _healAmount;
        Count--;
    }
}
