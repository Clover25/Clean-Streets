using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    public int health = 100;
    private bool isHeld;
    private Animator gunAnim;
        
	void Start ()
    {
        gunAnim = GetComponent<Animator>();

        SendHealthData();
    }


    void Update()
    {     


        if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Animator>().SetBool("isFiring", true);


            }

            else if (Input.GetMouseButtonUp(0))
            {
                GetComponent<Animator>().SetBool("isFiring", false);
            }
            
            if (health <= 0)
        {
            Die();
        }
        
    } 

    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Scene3");
    }


    public void TakeDamage(int damage)
        {
            health -= damage;
            SendHealthData();

            
        }	  

    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }
}
