using UnityEngine;

public class PowerUpWithEvent : PowerUp
{
    [SerializeField]
    private Event _event;

    public override void Interact(PlayerInteractor caller)
    {
        _event.Invoke();
        base.Interact(caller);
    }

}
