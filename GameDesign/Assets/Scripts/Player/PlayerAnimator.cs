using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimator : MonoBehaviour
{
    private PlayerMovement _movement;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    [Header("Particle FX")]
    [SerializeField] private GameObject _jumpFX;
    [SerializeField] private GameObject _landFX;

    public bool _startedJumping {  private get; set; }
    public bool _justLanded { private get; set; }

    public float _currentVelocityY;

    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = _spriteRenderer.GetComponent<Animator>();
    }

    private void LateUpdate()
    {
      CheckAnimationState();
    }

    private void CheckAnimationState()
    {
        if (_startedJumping)
        {
            _animator.SetTrigger("Jump");

            //GameObject obj = Instantiate(jumpFX, transform.position - (Vector3.up * transform.localScale.y / 2), Quaternion.Euler(-90, 0, 0)); TODO
            //Destroy(obj, 1);

            _startedJumping = false;
            return;
        }

        if (_justLanded)
        {
            //_animator.SetTrigger("Land");

            //GameObject obj = Instantiate(landFX, transform.position - (Vector3.up * transform.localScale.y / 1.5f), Quaternion.Euler(-90, 0, 0)); TODO
            //Destroy(obj, 1);

            _justLanded = false;
            return;
        }

        //_animator.SetInteger("Dir Y", (int)_movement.MoveInput.y);
        //_animator.SetFloat("Vel Y", _movement.Rigidbody.velocity.y);
        _animator.SetFloat("Speed", Mathf.Abs(_movement.Rigidbody.velocity.x));
        //_animator.SetBool("FastFall", _movement.Rigidbody.velocity.y < -24);
        //_animator.SetBool("ByTheWall", _movement.IsSliding);
        //_animator.SetBool("WallJump", _movement.IsWallJumping);
        //_animator.SetBool("Gliding", _movement.IsGliding);
    }

    public void SetAttackTrigger() => _animator.SetTrigger("Attack");

    public void SetDeathState() => _animator.SetTrigger("Death");
}
