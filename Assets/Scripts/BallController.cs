using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private float jumpSpeed = 10f;
    private bool isGrounded;
    private Rigidbody rgbdy;
    // Start is called before the first frame update
    void Start()
    {
        rgbdy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputControl();
    }
    
    private void InputControl()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (!isGrounded)
        {
            return;
        }
        rgbdy.AddForce(Vector3.up*jumpSpeed,ForceMode.Impulse);
    }

    private void Move(Vector3 direction)
    {
        rgbdy.AddForce(direction * moveSpeed, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
       
        CheckEnemyCollision(other);
    }

    private void CheckEnemyCollision(Collision collision) 
    {
        bool hasCollidedWithEnemy = collision.collider.GetComponent<Enemy>();
        if (!hasCollidedWithEnemy)
        {
            return;

        }
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            bool isOnTopOfEnemy = enemy != null;

            if (isOnTopOfEnemy)
            {
                enemy.Die();

            }



        }
        Die();

    }

    private void OnTriggerEnter(Collider other)
    {
        Collectible collectible= other.GetComponent<Collectible>();
        bool isCollectible = collectible != null;

        if (isCollectible)
        {
            collectible.Collect();
        }
    }

    public void Die()
    {
        FindObjectOfType<LeveManagerl>().RestartScenes();
        GetComponent<MeshRenderer>().enabled = false;
        
        //Invoke(nameof(ChangeScenes),1f);
    }

  
  

}
