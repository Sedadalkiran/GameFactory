using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _initialPosition;
    [SerializeField]
    private float  _patrolRange;
    private Vector3 _minPatrolPosition;
    private Vector3 _maxPatrolPosition;
    private Vector3 _destinationPoint;
    [SerializeField]
    private float _moveSpeed;
    private GameObject _goldPrefab;
    
    private void Awake()
    {
        _initialPosition = transform.position;
        _minPatrolPosition = _initialPosition  + (Vector3.left * _patrolRange);
        _maxPatrolPosition=_initialPosition + (Vector3.right * _patrolRange);
        SetDestination(_maxPatrolPosition);
        LoadGoldFromResources();
    }

 

    private void SetDestination(Vector3 destination)
    {
        _destinationPoint = destination;
    }
    private void Update()
    {
        if (Math.Abs(Vector3.Distance(transform.position, _maxPatrolPosition)) < 0.1f)
        {
            SetDestination(_minPatrolPosition);
        }
        else if (Math.Abs(Vector3.Distance(transform.position, _minPatrolPosition)) < 0.1f)
        {
            SetDestination(_maxPatrolPosition);        
        }
        transform.position = Vector3.MoveTowards(transform.position, _destinationPoint, Time.deltaTime * _moveSpeed); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        BallController ballController = collision.collider.GetComponent<BallController>();
        bool isPlayer = ballController != null;

        if (isPlayer)
        {
            ballController.Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);

        Instantiate(_goldPrefab,transform.position,transform.rotation);


    }

    public void LoadGoldFromResources()
    {
        _goldPrefab = Resources.Load<GameObject>("Coin");
    }

}
