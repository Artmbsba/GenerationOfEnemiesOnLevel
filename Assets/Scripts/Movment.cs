using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class Movment : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public void Move(float speed)
    {
        _enemy.transform.Translate(_enemy.transform.forward * (speed * Time.deltaTime),Space.World );
    }
}
