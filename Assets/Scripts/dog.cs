using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog : MonoBehaviour
{

    private GameObject movePointer;
    private Vector3 recentTargetPos;

    [SerializeField] private float turnSpeed;
    [SerializeField] private float speed = 5f;
    private string pointerTag = "Pointer";
    private bool shouldMove = false;
    private CircleCollider2D ghostCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(shouldMove == true)
        {
            CheckAndMove(movePointer);
        }
        else
        {
            LookForTarget(pointerTag);
        }
    }
    private void LookForTarget(string tag)
    {
        if (GameObject.FindGameObjectWithTag(tag) != null)
        {

            
            shouldMove = true;
            movePointer = GameObject.FindGameObjectWithTag(tag);
        }

    }
    private void CheckAndMove(GameObject target)
    {
        if (target != null)
        {
            
            recentTargetPos = target.transform.position;
            MoveTowards(target.transform.position);
        }
        else
        {
            if(transform.position != recentTargetPos)
            {
                MoveTowards(recentTargetPos);
            }
            
        }

     
        
    }
    private void MoveTowards(Vector3 target)
    {
        
        
        Vector2 vectorToTarget = (target - transform.position);
        float angleToTarget = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion rotationToTarget = Quaternion.AngleAxis(angleToTarget, Vector3.forward);
        float roundedAngle = Mathf.Round(angleToTarget/10)*10;
        if (roundedAngle < 0) { roundedAngle += 360; }
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget , Time.deltaTime * turnSpeed);
        if (Mathf.Round(transform.rotation.eulerAngles.z/10)*10 == roundedAngle)
        {
            transform.position += speed * Time.deltaTime * transform.right;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(pointerTag))
        {
            Destroy(collision.gameObject);

            shouldMove = false;
        }
        
    }
}
