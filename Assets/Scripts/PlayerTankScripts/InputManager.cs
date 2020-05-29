using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//required scripts
[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankMotor))]
[RequireComponent(typeof(Attack))]
public class InputManager : MonoBehaviour
{
    //state machine for move schemes
    public enum inputScheme { WASD, arrowKeys };
    public inputScheme input = inputScheme.WASD;

    //Declares the needed scripts
    private TankMotor motor;
    private TankData data;
    private Attack attack;

    //finds the needed scripts
    void Start()
    {
        motor = GetComponent<TankMotor>();
        data = GetComponent<TankData>();
        attack = GetComponent<Attack>();
    }

    //Calls the inputs
    void Update()
    {
        HandleInputs();
    }

    //Controls the two movement schemes implemented
    void HandleInputs()
    {
        switch (input)
        {
            //Player1 Movement set
            case inputScheme.WASD:
                if (Input.GetKey(KeyCode.W))
                    motor.Move(data.moveSpeedForward);
                else if (Input.GetKey(KeyCode.S))
                    motor.Move(-data.moveSpeedBack);
                else
                    motor.Move(0);

                if (Input.GetKey(KeyCode.D))
                    motor.Rotate(data.rotateSpeed);
                else if (Input.GetKey(KeyCode.A))
                    motor.Rotate(-data.rotateSpeed);
                else
                    motor.Rotate(0);

                if (Input.GetKeyDown(KeyCode.Space))
                    attack.Shoot();

                break;

            //Player2 movement set
            case inputScheme.arrowKeys:
                if (Input.GetKey(KeyCode.UpArrow))
                    motor.Move(data.moveSpeedForward);
                else if (Input.GetKey(KeyCode.DownArrow))
                    motor.Move(-data.moveSpeedBack);
                else
                    motor.Move(0);

                if (Input.GetKey(KeyCode.RightArrow))
                    motor.Rotate(data.rotateSpeed);
                else if (Input.GetKey(KeyCode.LeftArrow))
                    motor.Rotate(-data.rotateSpeed);
                else
                    motor.Rotate(0);

                if (Input.GetKeyDown(KeyCode.Mouse0))
                    attack.Shoot();

                break;

            //If no movement is selected
            default:
                Debug.LogError("Input Scheme not selected");
                break;
        }
    }
}