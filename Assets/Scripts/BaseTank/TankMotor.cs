using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TankMotor : MonoBehaviour
{
    //Referencing scripts
    private CharacterController charCont;
    private Transform tf;

    //Finds scripts
    void Start()
    {
        charCont = gameObject.GetComponent<CharacterController>();
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

    //Enemy Rotation
    public bool RotateTowards(Vector3 target, float speed)
    {
        Vector3 vectorToTarget = target - tf.position;
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget);
        if (targetRotation == tf.rotation)
            return false;

        tf.rotation = Quaternion.RotateTowards(tf.rotation, targetRotation, speed * Time.deltaTime);
        return false;
    }
}