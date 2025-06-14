using UnityEngine;

public class RockHead : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HitFromLeft()
    {
        animator.SetTrigger("LeftHit");
    }

    public void HitFromRight()
    {
        animator.SetTrigger("RightHit");
    }

    public void HitFromTop()
    {
        animator.SetTrigger("TopHit");
    }
}

