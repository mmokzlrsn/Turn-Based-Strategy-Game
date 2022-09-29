using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;
    [SerializeField]
    private Animator unitAnimator;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        float stoppingDistance = .1f;
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized; //only want vector

            float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime; //movement

            float rotateSpeed = 20f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime); //rotation

            unitAnimator.SetBool("IsWalking", true);
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);
        }

         
        
    }


    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }



}
