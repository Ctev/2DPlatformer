using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;

    private Transform _groundCheck;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _render;
    private Animator _animator;
    private Vector2 _direction;
    private bool _onGround;
    private float _groundCheckRadius;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _render = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _groundCheck = transform.GetChild(0);
        _groundCheckRadius = _groundCheck.GetComponent<CircleCollider2D>().radius;
    }

    private void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _animator.SetFloat("Speed", Mathf.Abs(_direction.x));
        _rigidbody.velocity = new Vector2(_speed * _direction.x, _rigidbody.velocity.y);

        if (_direction.x > 0)
            _render.flipX = false;
        else if (_direction.x < 0)
            _render.flipX = true;

        if (Input.GetKey(KeyCode.Space) && _onGround)
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        
        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }
}
