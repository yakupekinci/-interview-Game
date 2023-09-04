using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBot2 : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public Transform targetWaypoint;
    public int targetWaypointIndex = 0;
    public float minDistance = 0.1f;
    public int lastWaypointIndex;
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 10f;
    public GameObject panell;
    public GameObject botcar;

    public int Temp;

    void Start()
    {

        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex];
    }


    void Update()
    {
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



        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (this.GetComponent<MovementBot2>().enabled == true)
            {
                this.GetComponent<MovementBot>().targetWaypointIndex = Temp;
                this.GetComponent<MovementBot>().targetWaypoint = waypoints[Temp];
                this.GetComponent<MovementBot>().enabled = true;
                this.GetComponent<MovementBot2>().enabled = false;
            }

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
        }

        targetWaypoint = waypoints[targetWaypointIndex];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="bot")
        {
            Debug.Log("aaaaaaaaaaaaa");
            panell.SetActive(true);
            this.GetComponent<MovementBot2>().enabled = false;
            botcar.SetActive(false);
            Timer.isCounting = false;
        }
        if (other.tag == "coin")
        {
            Debug.Log("PARARARARARA");
            other.GetComponent<CoinColllcet2>().SetCollected();
        }
    }
}
