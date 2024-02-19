using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currentPlayerHealth = 15;
    public int enemyDamage = 3;
    public Text deathText;
    public GameObject menu;
    public GameObject score;
    public GameObject hp;

    public PlayerExplosionParticles particles;
    private Animator playerAnimator;
    void Start()
    {
        score.SetActive(false);
        hp.SetActive(false);
        menu.SetActive(true);
        Time.timeScale = 0f;
        deathText.text = "";
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
            deathText.text = "you died :(";
            Invoke("Death", 2f);
        }
    }

    private void Death()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HitCollider")
        {
            HurtPlayer();
        }
    }

    public void startButton(){
        score.SetActive(true);
        hp.SetActive(true);
        Time.timeScale = 1f;
        menu.SetActive(false);
    }
}
