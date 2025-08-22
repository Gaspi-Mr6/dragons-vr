using UnityEngine;

public class DragonCmp : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void TakeDamage()
    {
        animator.SetTrigger("Hit");
    }
}
