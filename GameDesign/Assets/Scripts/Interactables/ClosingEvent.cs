using UnityEngine;

public class ClosingEvent : Event
{
    [SerializeField]
    private GameObject _passageLocker;
    public override void Invoke()
    {
        _passageLocker.SetActive(true);
    }
}