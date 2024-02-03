using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int currentPlayerHealth = 15;
    public int enemyDamage = 3;

    public PlayerExplosionParticles particles;
    private Animator playerAnimator;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        particles = GetComponent<PlayerExplosionParticles>();
    }
    
    public void HurtPlayer()
    {
        currentPlayerHealth -= enemyDamage;
        playerAnimator.SetTrigger("Hit");

        if(currentPlayerHealth <= 0)
        {
            particles.Explode();
            Invoke("Death", 1.5f);
        }
    }

    private void Death()
    {
        SceneManager.LoadScene("Dead");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HitCollider")
        {
            HurtPlayer();
        }
    }
}
