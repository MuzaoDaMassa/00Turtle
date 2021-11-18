using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_InitialState : StateMachineBehaviour
{
    

    private Transform player;
    
    private Boss boss;
    private Rigidbody2D bossRb2d;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = animator.GetComponent<Boss>();

        boss.CallJumpAttack();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (boss._bossHp <= 5)
        {
            animator.SetBool("isEnraged", true);
        }

        boss.LookAtPlayer();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
