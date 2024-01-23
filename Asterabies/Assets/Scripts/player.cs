using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed = 24f;
    public int health = 3;
    [SerializeField] private TMP_Text hp;
    [SerializeField] private Transform bulletspawn;
    [SerializeField] private Rigidbody2D bulletprefab;
    [SerializeField] private Rigidbody2D asteroidprefab;
    private float bulletspeed = 8f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement(){
        if(Input.GetKey("w")){
            speed = 24f;
            transform.position += transform.up * 0.001f * speed;
        }
        else if(speed > 0f){
            speed -= 0.05f;
            transform.position += transform.up * 0.001f * speed;
        }
        if(Input.GetKey("d")){
            transform.Rotate(0f, 0f, -0.8f, Space.Self);
        }
        if(Input.GetKey("a")){
            transform.Rotate(0f, 0f, 0.8f, Space.Self);
        }
    }

    void Shooting(){
        if(Input.GetKeyDown("space")){
            Rigidbody2D bullet = Instantiate(bulletprefab, bulletspawn.position, Quaternion.identity);
            Vector2 playerVelocity = rb.velocity;
            Vector2 playerDirection = transform.up;
            float playerFSpeed = Vector2.Dot(playerVelocity, playerDirection);
            if(playerFSpeed < 0){
                playerFSpeed = 0;
            }
            bullet.velocity = playerDirection * playerFSpeed;
            bullet.AddForce(bulletspeed * transform.up, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Asteroid") && health > 0){
            health--;
            hp.text = "HP: " + health;

            GameManager gameManager = FindAnyObjectByType<GameManager>();
            gameManager.hpnum -= 1;
        }
        if(health <= 0){
            GameManager gameManager = FindAnyObjectByType<GameManager>();

            gameManager.GameOver();

            Destroy(gameObject);
        }
    }
}
