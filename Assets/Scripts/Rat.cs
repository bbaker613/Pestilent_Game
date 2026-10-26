using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Rat : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] public int health = 25;
    [SerializeField] public int damage = 5;

    public TextMeshProUGUI ratHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void Attack()
    {
        animator.SetBool("isAttacking", true);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        ratHealth.text = "Health: " + health.ToString();

        if (health > 0)
        {
        }
        else
        {
            animator.SetBool("isDead", true);
        }
    }

    void postDeath()
    {
        Destroy(gameObject);
    }

    void disableAnim()
    {
        animator.SetBool("isAttacking", false);
    }
}
