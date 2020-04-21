using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent((typeof(PlayerMotor)))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float lookSensitivity = 3f;
    
    private PlayerMotor motor;
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }
    
    void Update()
    {
        // On va calculer la vélocité du mouvement du joueur en un Vecteur 3D
        float _xMov = Input.GetAxisRaw("Horizontal");
        /*
         * -1 = gauche
         * 0 = le personnage ne bouge pas
         * 1 = droite
         * */
        
        float _zMov = Input.GetAxisRaw("Vertical");
        /*
         * -1 = recule
         * 0 = le personnage ne bouge pas
         * 1 = avance
         */

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        motor.Move(_velocity);
        
        // On va calculer la rotation du joueur en un Vecteur 3D
        float _yRot = Input.GetAxisRaw("Mouse X");
        
        Vector3 _rotation = new Vector3(0, _yRot, 0) * lookSensitivity;

        motor.Rotate(_rotation);
        
        // On va calculer la rotation de la camera en un Vecteur 3D
        float _xRot = Input.GetAxisRaw("Mouse Y");
        
        Vector3 _cameraRotation = new Vector3(_xRot, 0, 0) * lookSensitivity;

        motor.RotateCamera(_cameraRotation); 
    }
}
