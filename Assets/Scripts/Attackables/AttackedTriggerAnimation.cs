using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackedTriggerAnimation : MonoBehaviour, IAttackable
{
    private Animator animator;
    [SerializeField] private string triggerToSet;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnAttack(GameObject attacker, Attack attack)
    {
        animator.SetTrigger(triggerToSet);
    }
}