using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _container;

    public event Action<Character> OnHit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }

    private void Shoot()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.identity, _container);
        bullet.SetDirection(direction);

        Subscribe(bullet);
    }

    private void RemoveBullet(Bullet bullet, Character enemy)
    {
        OnHit?.Invoke(enemy);

        Unsubscribe(bullet);
        Destroy(bullet.gameObject);
    }

    private void Subscribe(Bullet bullet)
    {
        bullet.OnCrashed += RemoveBullet;
    }

    private void Unsubscribe(Bullet bullet)
    {
        bullet.OnCrashed -= RemoveBullet;
    }    
}
