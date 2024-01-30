using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PowerUp : MonoBehaviour, Interactable
{
    private Animator _animator;

    enum PowerUpType
    {
        DASH,
        WALL_JUMP,
        GLIDE,
        AIR_JUMP,
        BOMB
    };
    
    [Space(10)]
    
    [Header("PowerUp Params")]
    [SerializeField]
    private PowerUpType _type;

    private bool _isDead = false;

    private void Start() => _animator = GetComponent<Animator>();

    public virtual void Interact(PlayerInteractor caller)
    {
        if (_isDead)
            return;

        switch (_type)
        {
            case (PowerUpType.DASH):
                GameProgress.HasDash = true;
                break;
            case (PowerUpType.WALL_JUMP):
                GameProgress.HasWallJump = true;
                break;
            case (PowerUpType.GLIDE):
                GameProgress.HasGlide = true;
                break;
            case (PowerUpType.AIR_JUMP):
                GameProgress.HasAirJump = true;
                break;
            case (PowerUpType.BOMB):
                GameProgress.HasBomb = true;
                break;
            default:
                break;
        }
        _isDead = true;
        Destroy();
    }
    protected virtual void Destroy() => Destroy(gameObject);

}
