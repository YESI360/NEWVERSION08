
using System.Collections;
using UnityEngine;
using FSG.MeshAnimator;

public class MovementController : MonoBehaviour
{
    //public Animator animator = null;
    public MeshAnimator animator = null;
    public float moveSpeed = 5f;
    public float idleTime = 5f;
    public float maxMoveDistance = 20f;

    private IEnumerator Start()
    {
        while (enabled)
        {
            Vector3 targetPosition = transform.position + Random.insideUnitSphere * maxMoveDistance;
            targetPosition.y = 0;
            Vector3 currentPosition = transform.position;
            //animator.SetBool("moving", true);
            transform.LookAt(targetPosition);

            while (currentPosition != targetPosition)
            {
                animator.Play("Breathing Idle 1");
                //currentPosition = Vector3.MoveTowards(currentPosition, targetPosition, Time.deltaTime * moveSpeed);
                //transform.position = currentPosition;
                yield return null;
            }
            
            animator.Play("RunningInPlace");
            //animator.SetBool("moving", false);
            yield return new WaitForSeconds(idleTime);
        }
    }
}
