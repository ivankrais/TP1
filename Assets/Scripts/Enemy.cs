using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            animator.SetBool("IsHit", true);
        }
    }

    public void HitEnd()
    {
        animator.SetBool("IsHit", false);
    }
}
