using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monserMovement : MonoBehaviour
{   
        public float minSpeed = 3f;
    public float maxSpeed = 6f;
    public float moveSpeed; // Speed of the monster's movement
    public float minMoveDistance = 3f; // Minimum distance the monster will move in each direction
    public float maxMoveDistance = 10f; // Maximum distance the monster will move in each direction

    private Vector3 startPosition;
    private bool moveRight = true; // Flag to indicate the direction of movement
    private float moveDistance; // Randomly generated distance for each movement
    private Vector3 moveDirection;
    public float minCollisionDistance = 1f; // Minimum distance to keep from colliding objects

    private void Start()
    {
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        startPosition = transform.position;
        GenerateRandomMoveDistance();
        GenerateRandomDirection();
    }

    private void Update()
    {
        // Calculate the target position based on the movement direction
        Vector3 targetPosition = startPosition + moveDirection * moveDistance;

        // Move the monster towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the monster has reached the target position
        if (transform.position == targetPosition)
        {
            // Reverse the movement direction
            moveRight = !moveRight;

            // Generate a new random move distance
            GenerateRandomMoveDistance();
            // Generate a new random direction
            GenerateRandomDirection();
        }
    }

    private void GenerateRandomMoveDistance()
    {
        // Generate a random move distance within the specified range
        moveDistance = Random.Range(minMoveDistance, maxMoveDistance);
    }

    private void GenerateRandomDirection()
    {
        // Generate a random value between 0 and 1
        float randomValue = Random.value;

        // Set the move direction based on the random value
        if (randomValue < 0.5f)
        {
            moveDirection = Vector3.right; // Move left and right
        }
        else
        {
            moveDirection = Vector3.forward; // Move forward and backward
        }
    }

     void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("object"))
        {
            
            // Calculate the direction away from the collided object
            Vector3 collisionDirection = transform.position - other.transform.position;

            // Normalize the direction and add a small offset
            collisionDirection.Normalize();
            collisionDirection += Random.insideUnitSphere * minCollisionDistance;

            // Set the move direction away from the collided object
            moveDirection = collisionDirection.normalized;

            // Move the monster a small distance away from the collided object
            transform.position += moveDirection * minCollisionDistance;
        }
    }
}