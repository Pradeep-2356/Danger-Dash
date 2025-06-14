using UnityEngine;
using System.Collections;

public class WinManager : MonoBehaviour
{
    private Animator anim;
    private bool hasWon = false;
    private Rigidbody2D rb;
    private PlayerMovement movement;

    [SerializeField] private float delayBeforeWinUI = 2f; // Adjust delay as needed

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WinZone") && !hasWon)
        {
            hasWon = true;
            anim.SetTrigger("win");

            // Stop movement
            if (movement != null)
                movement.enabled = false;

            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;

            StartCoroutine(DelayedWinUI());
        }
    }

    private IEnumerator DelayedWinUI()
    {
        yield return new WaitForSeconds(delayBeforeWinUI);
        FindObjectOfType<UIManager>().LevelPassed();
    }
}
