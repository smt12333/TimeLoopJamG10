using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Vector2 moveinput;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject audio;
   
    
    void Update()
    {
        //el void Update se utiliza para recibir Inputs del usuario.
        MovePlayer();

    }

    private void MovePlayer()
    {


     float moveX = Input.GetAxisRaw("Horizontal");
     float moveY = Input.GetAxisRaw("Vertical");
     moveinput = new Vector2(moveX, moveY).normalized;
     bool isWalking = moveinput.x >= 0.01f || moveinput.y >= 0.01f || moveinput.x <= -0.01f || moveinput.y <= -0.01f;
        
     audio.SetActive(isWalking);

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
