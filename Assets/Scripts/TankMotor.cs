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
    public void Move(float Speed)
    {
            Vector3 speedVector = tf.forward * Speed;
            charCont.SimpleMove(speedVector);
    }

    //Player Rotation
    public void Rotate(float speed)
    {
            Vector3 rotateVector = Vector3.up * speed * Time.deltaTime;
            tf.Rotate(rotateVector, Space.Self);
    }

    void Update()
    {
        
    }
}