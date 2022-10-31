using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private Rigidbody2D playerRb;
    private Vector2 moveinput;
    private Animator playerAnimator;
   
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        Time.timeScale = 1f;

    }


    void Update()
    {
        //el void Update se utiliza para recibir Inputs del usuario.

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveinput = new Vector2(moveX, moveY).normalized;

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("speed", moveinput.sqrMagnitude);
        
           
        


    }

    private void FixedUpdate()
    {
        //el void FixedUpdate se utiliza para simular fisicas, ya que toma el reloj interno del motor y no depende de los fotogramas del usuario.
        playerRb.MovePosition(playerRb.position + moveinput * speed * Time.fixedDeltaTime);

    }

    
  


}
