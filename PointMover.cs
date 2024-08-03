using System.Collections.Generic;
using UnityEngine;

public class PointMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _places;
    [SerializeField] private float _speed;
    [SerializeField] private float _error;

    private Transform _transform;
    private int _currentPlace = 0;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _places[_currentPlace].position, _speed * Time.deltaTime);

        if (Mathf.Abs((_transform.position - _places[_currentPlace].position).magnitude) < _error)
            SetupNextPlace();
    }

    private void SetupNextPlace()
    {
        _currentPlace++;

        if (_currentPlace >= _places.Count)
            _currentPlace = 0;

        transform.forward = _places[_currentPlace].position - transform.position;
    }
}