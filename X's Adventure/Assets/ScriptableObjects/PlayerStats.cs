using UnityEngine;

[CreateAssetMenu]
public class PlayerStats : ScriptableObject
{
    public int health = 3;
    public int maxHealth = 5;
    public float movementSpeed = 300f;
    public float jumpForce = 400f;
    public float firePower = 0.25f;
    public float energyIncreaser = 0.005f;
}
