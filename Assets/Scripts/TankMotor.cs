using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(TankData))]
public class TankMotor : MonoBehaviour
{
    //Referencing scripts
    private CharacterController charCont;
    private TankData data;
    private Transform tf;

    void Start()
    {
        charCont = gameObject.GetComponent<CharacterController>();
        data = gameObject.GetComponent<TankData>();
        tf = gameObject.GetComponent<Transform>();
    }

    //Player Movement
    public void Move(float frontSpeed, float backSpeed)
    {
        if(Input.GetKey(KeyCode.W))
        {
            Vector3 speedVector = tf.forward * frontSpeed;
            charCont.SimpleMove(speedVector);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 speedVector = -tf.forward * backSpeed;
            charCont.SimpleMove(speedVector);
        }
    }

    //Player Rotation
    public void Rotate(float speed)
    {
        if(Input.GetKey(KeyCode.D))
        {
            Vector3 rotateVector = Vector3.up * speed * Time.deltaTime;
            tf.Rotate(rotateVector, Space.Self);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Vector3 rotateVector = -Vector3.up * speed * Time.deltaTime;
            tf.Rotate(rotateVector, Space.Self);
        }
    }

    void Update()
    {
        
    }
}