using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private GameManager gameManager;
    private GameManager.Direction direction;
    private AudioSource audioSource;
    // private Animator animator;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        gameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();
        direction = gameManager.enemySelectedDirection;
        speed=gameManager.enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.DirectionalMovement(gameObject,speed,direction);
    }

    void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Stick")){
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().superSticks){
                Destroy(gameObject);
            } else{
                Destroy(other.gameObject);
            }
        }
    }


}
