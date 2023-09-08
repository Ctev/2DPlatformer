using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private SpriteRenderer _render;
    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _render = GetComponent<SpriteRenderer>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _path.GetChild(i);
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint % 2 == 0)
                _render.flipX = true;
            else
                _render.flipX = false;

            if (_currentPoint >= _points.Length)
                _currentPoint = 0;
        }
    }
}