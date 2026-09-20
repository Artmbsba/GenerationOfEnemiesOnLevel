using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnerPoint : MonoBehaviour
{
    [SerializeField] private Collider _spawnLocation;

   public Collider Collider => _spawnLocation;
}
