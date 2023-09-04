using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOT1 : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public Transform targetWaypoint;
    public int targetWaypointIndex = 0;
    public float minDistance = 0.1f;
    public int lastWaypointIndex;
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 10f;
    public bool BOTROTATE;
    public int Temp;
    float time;

    void Start()
    {
        time = Random.Range(10f, 10f);
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex];
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            BOTROTATE = true;
            time = Random.Range(3f, 5f);
        }


        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;
        Vector3 directionToTarget = -targetWaypoint.position + transform.position;
        if (directionToTarget != Vector3.zero)
        {
            Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);
        }


        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        if (BOTROTATE)
        {
            if (this.GetComponent<BOT1>().enabled == true)
            {
                this.GetComponent<BOT2>().Temp = Temp;
                this.GetComponent<BOT2>().targetWaypointIndex = Temp;
                this.GetComponent<BOT2>().targetWaypoint = waypoints[Temp];
                this.GetComponent<BOT2>().enabled = true;
                this.GetComponent<BOT1>().enabled = false;
            }
            BOTROTATE = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
    }


    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {

            targetWaypointIndex++;
            UpdateTargetWaypoint();
            Temp = targetWaypointIndex;
        }
    }

    void UpdateTargetWaypoint()
    {
        if (targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0;
            Temp = 0;
        }

        targetWaypoint = waypoints[targetWaypointIndex];
    }
}
