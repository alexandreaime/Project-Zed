using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -39.24f;
    public float jumpHeight = 3f;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;
    Vector3 velocity;
    
   
    void Update()
    {
        if (PauseMenu.GameIsPaused == true)
        {
            return;
        }
        
        // On vérifie si le joueur est au sol ou pas
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // lui applique la gravité
        }
        
        // On va calculer la vélocité du joueur en un Vecteur 3D
        float x = Input.GetAxis("Horizontal"); // -1 = gauche | 0 = le personnage ne bouge pas | 1 = droite
        float z = Input.GetAxis("Vertical"); // -1 = recule | 0 = le personnage ne bouge pas | 1 = avance

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
       
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
