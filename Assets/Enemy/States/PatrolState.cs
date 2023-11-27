using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
public int waypointIndex = 0; // 为 waypointIndex 添加初始值

private Vector3 moveDirection;
 public override void Enter()
 {
  
   
  // if (enemy != null && enemy.animator != null)
   // {
   //    // enemy.animator.SetBool("isPatrolling", true);
   // }
  // else
  //  {
   //     Debug.LogError("Enemy or Animator is null.");
   // }
   //   if (enemy.animator != null)
    //{
      //  enemy.animator.SetBool("isPatrolling", true);
    //}

//enemy.animator.SetBool("isPatrolling", true);
 }

 public override void Exit()
 {
    // if (enemy.animator != null)
    //{
    //    enemy.animator.SetBool("isPatrolling", false);
   // }
//enemy.animator.SetBool("isPatrolling", false);
 }

 public override void Perform()
 {
 PatrolCycle();
 if(enemy.CanSeePlayer())
 {
stateMachine.ChangeState(new AttackState());
 }
 }
 public void PatrolCycle()
 { 
     

   if(enemy.Agent.remainingDistance<0.00001f)
    {
       if(waypointIndex<enemy.patrolWayPoints.Count-1)
       
         waypointIndex++;
        else
        waypointIndex=0;
       enemy.Agent.SetDestination(enemy.patrolWayPoints[waypointIndex].position);
       
    }

 }


}
