using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float timeBetweenAttacks = 5.5f;
    bool playerInRange;
    float timer; 
    GameObject player;

    void Start () {
        //playerController = GetComponent<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();
           // Blink(player.GetComponent<MeshRenderer>(), timer);
            
        }
    }

   void  OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;           
           // GameController.GameOver();
        }
        else if(other.gameObject.CompareTag("Bullet"))
        {        
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameController.AddPoints();
        }

    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }




    void Attack()
    {
        timer = 0f;
        if (GameController.playerHealth >= 1 )
        {
            GameController.playerHealth--;
                       
        }
        else
        {
            player.SetActive(false);
            if (GameController.gameOver != true)
            {
                GameController.GameOver();
            }
        }

        
    }

    void Blink(MeshRenderer mr, float timer)
    {

    }
}
