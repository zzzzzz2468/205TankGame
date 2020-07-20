using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//required scripts
[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankMotor))]
[RequireComponent(typeof(Shoot))]
public class InputManager : MonoBehaviour
{
    //state machine for move schemes
    public enum inputScheme { WASD, arrowKeys };
    public inputScheme input = inputScheme.WASD;

    //Declares the needed scripts
    private TankMotor motor;
    private TankData data;
    private Shoot shoot;

    private bool isMoving = false;

    //finds the needed scripts
    void Start()
    {
        motor = GetComponent<TankMotor>();
        data = GetComponent<TankData>();
        shoot = GetComponent<Shoot>();
    }

    //Calls the inputs
    void Update()
    {
        HandleInputs();

        if (isMoving)
        {
            data.curFuel -= data.fuelLoss;
            isMoving = false;
        }
    }

    //Controls the two movement schemes implemented
    void HandleInputs()
    {
        switch (input)
        {
            //Player1 Movement set
            case inputScheme.WASD:
                if (Input.GetKey(KeyCode.W) && data.curFuel >= 0)
                {
                    motor.Move(data.moveSpeedForward);
                    isMoving = true;
                }
                else if (Input.GetKey(KeyCode.S) && data.curFuel >= 0)
                {
                    motor.Move(-data.moveSpeedBack);
                    isMoving = true;
                }
                else
                {
                    motor.Move(0);
                    isMoving = false;
                }

                if (Input.GetKey(KeyCode.D))
                    motor.Rotate(data.rotateSpeed);
                else if (Input.GetKey(KeyCode.A))
                    motor.Rotate(-data.rotateSpeed);
                else
                    motor.Rotate(0);

                if (Input.GetKeyDown(KeyCode.Space))
                    shoot.ShootBullet();

                if (Input.GetKeyDown(KeyCode.F))
                    Destroy(this.gameObject);

                break;

            //Player2 movement set
            case inputScheme.arrowKeys:
                if (Input.GetKey(KeyCode.UpArrow) && data.curFuel >= 0)
                {
                    motor.Move(data.moveSpeedForward);
                    isMoving = true;
                }
                else if (Input.GetKey(KeyCode.DownArrow) && data.curFuel >= 0)
                {
                    motor.Move(-data.moveSpeedBack);
                    isMoving = true;
                }
                else
                {
                    motor.Move(0);
                    isMoving = false;
                }

                if (Input.GetKey(KeyCode.RightArrow))
                    motor.Rotate(data.rotateSpeed);
                else if (Input.GetKey(KeyCode.LeftArrow))
                    motor.Rotate(-data.rotateSpeed);
                else
                    motor.Rotate(0);

                if (Input.GetKeyDown(KeyCode.Mouse0))
                    shoot.ShootBullet();

                if (Input.GetKeyDown(KeyCode.End))
                    Destroy(this.gameObject);

                break;

            //If no movement is selected
            default:
                Debug.LogError("Input Scheme not selected");
                break;
        }
    }
}