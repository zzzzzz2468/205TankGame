using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankMotor))]

public class InputManager : MonoBehaviour
{
    public enum inputScheme { WASD, arrowKeys };
    public inputScheme input = inputScheme.WASD;

    private TankMotor motor;
    private TankData data;
    void Start()
    {
        motor = gameObject.GetComponent<TankMotor>();
        data = gameObject.GetComponent<TankData>();
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        switch (input)
        {
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
                break;

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
                break;

            default:
                Debug.LogError("Input Scheme not selected");
                break;
        }
    }
}