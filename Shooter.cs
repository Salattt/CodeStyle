using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] public float _bulletSpeed;
    [SerializeField] private float _timeBetweenShoots;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        StartCoroutine(ShootingRutine());
    }

    private IEnumerator ShootingRutine()
    {
        WaitForSeconds timer = new WaitForSeconds(_timeBetweenShoots);

        while(enabled)
        {
            Vector3 direction = (_target.position - _transform.position).normalized;
            Rigidbody NewBullet = Instantiate(_bulletPrefab, _transform.position + direction, Quaternion.identity);

            NewBullet.transform.up = direction;
            NewBullet.velocity = direction * _bulletSpeed;

            yield return timer;
        }
    }
}