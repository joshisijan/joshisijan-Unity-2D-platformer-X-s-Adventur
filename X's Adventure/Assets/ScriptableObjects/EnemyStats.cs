using UnityEngine;

[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    public int health = 2;
    public float movementSpeed = 100f;
    public float activeDistance = 10;
    public float attackDistance = 5f;
    public float stoppingDistance = 2f;
    public float reloadingTime = 6f;
}
