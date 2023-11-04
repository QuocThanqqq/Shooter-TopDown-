using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerSystem : MonoBehaviour
{

    [SerializeField]

    public float health;
    public float currentHealth;
    public Slider slider;
    private DataEnemys mEnemy;
    public ParticleSystem particle;
    public ParticleSystem particleHealth;
    
    
    public Animator animator;
    public  static int numberDNA;
    public Text _numberDNA;
    private void Start()
    {
       currentHealth = health;
    }

    public void Update()    
    {
        _numberDNA.text = numberDNA.ToString();
        slider.value = currentHealth;
    }



    public void TakeDamePlayer(float damged)
    {
        currentHealth -= damged;
        particle.Play();
        Debug.Log("Current Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            animator.Play("Death");
            StartCoroutine(TimeDelayAnimation());
            Debug.Log("Done");
            
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            
                mEnemy = collision.gameObject.GetComponent<EnemyBehaviour>().data;
                TakeDamePlayer(mEnemy.dame);        
        }
    }

    public void DnaCheat()
    {
        numberDNA += 3;
    }


    public void HealthCheat()
    {
        particleHealth.Play();
        currentHealth += 50;
    }

    IEnumerator TimeDelayAnimation()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      
    }

}
