using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        Health playerHealth = collision.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.InstantKill(); // Force health to 0 and trigger death
            Debug.Log("InstantKill() triggered from death zone.");

        }
    }
}
}


