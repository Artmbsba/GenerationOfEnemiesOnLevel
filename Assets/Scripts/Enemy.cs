using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(EnemyAnimation))]
[RequireComponent(typeof(Movment))]
public class Enemy : MonoBehaviour
{
    [SerializeField, Range(0.0f, 1.0f)] private float _speed = 1.0f;

    private EnemyAnimation _enemyAnimation;
    private Movment _movement;

    private void Awake()
    {
        _movement = GetComponent<Movment>();
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }

    private void Update()
    {
        _movement.Move(_speed);
        _enemyAnimation.SetSpeed(_speed);
    }  
}
