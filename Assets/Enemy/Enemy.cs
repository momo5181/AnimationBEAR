using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
 public Animator animator;
  public List<Transform> patrolWayPoints;
  public GameObject debugsphere; //代替玩家最位子
  public GameObject Player{get => player;} //取得玩家信息
  public Vector3 LastKnowPos{get=>lastKnowPos;set =>lastKnowPos=value;} 
  public NavMeshAgent Agent{get => agent;}
     public float moveSpeed=5f; // 这里的 5f 是一个示例速度，你可以根据需要调整

  private Vector3 lastKnowPos;  //取得玩家最後座標
  private StateMachine stateMachine;
  private NavMeshAgent agent;

  [Header("槍")]
  public Transform gunBarrel;

  [Range(0.1f,10f)]
  public float fireRate;

  [Header("視野")]
  public float sightDistance =20f;
  public float field0fView = 85f; 
  public float eyeHeight;

  [SerializeField]
  private string currentState;
  private GameObject player;
    
  void Start()
  {
    animator = GetComponent<Animator>();
    stateMachine=GetComponent<StateMachine>();
    agent=GetComponent<NavMeshAgent>();
    stateMachine.Initialise();
    player=GameObject.FindGameObjectWithTag("Player");
  
      
        
  }

  // Update is called once per frame
  void Update()
  {
      CanSeePlayer();
      currentState=stateMachine.activeState.ToString();
      debugsphere.transform.position=lastKnowPos;
  }
  public bool CanSeePlayer()
  {
    if(player!=null)
    {
        if(Vector3.Distance(transform.position,player.transform.position)<sightDistance)
        {
        Vector3 targetDirection=player.transform.position-transform.position-(Vector3.up*eyeHeight);
        float angleToPlayer= Vector3.Angle(targetDirection,transform.forward);
          if(angleToPlayer>=-field0fView && angleToPlayer<=field0fView)
          {
            Ray ray=new Ray(transform.position+(Vector3.up*eyeHeight),targetDirection);
            RaycastHit hitInfo=new RaycastHit();
            if(Physics.Raycast(ray,out hitInfo,sightDistance))
            {
            if(hitInfo.transform.gameObject==player)
            {
            Debug.DrawRay(ray.origin,ray.direction*sightDistance);
            return true;
            }
          
            }    
          }
        }
    }
    return false;
  }
}
