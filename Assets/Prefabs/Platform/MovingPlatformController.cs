using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{

    public GameObject waypointObj;
    public float moveSpeed = 2.5f;
    public List<Transform> waypoints;
    private int currentTargetIndex;

    private void Awake()
    {
        waypoints = new List<Transform>();
        foreach (Transform child in transform.parent.GetChild(1))
        {
            waypoints.Add(child);
        }

        if (waypoints.Count > 0)
        {
            transform.position = waypoints[0].position;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (waypoints.Count > 1)
        {

            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentTargetIndex].position, Time.deltaTime * moveSpeed);

            if (Vector3.Distance(transform.position, waypoints[currentTargetIndex].position) < 0.1f)
            {
                currentTargetIndex = (currentTargetIndex + 1) % waypoints.Count;
            }


        }
    }



    public void AddWaypoint()
    {
        GameObject gObj = Instantiate(waypointObj, Vector2.zero, Quaternion.identity);
        gObj.transform.SetParent(transform.parent.GetChild(1));
        gObj.name = "Waypoint " + waypoints.Count;
        waypoints.Add(gObj.transform);
        
    }

    public void RemoveWaypoint(int index)
    {
        waypoints.RemoveAt(index);
        DestroyImmediate(transform.parent.GetChild(1).GetChild(index).gameObject);
    }   

    public void ClearWaypoint()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            DestroyImmediate(waypoints[i].gameObject);
        }   
        
        waypoints.Clear();
    }
}
