using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject waypointObj;
    public float moveSpeed = 2.5f;
    public List<Transform> waypoints;
    private int currentTargetIndex;
    //[SerializeField] public GameObject itemFeedback;

    private LevelController levelController;


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
            transform.rotation = waypoints[0].rotation;
        }

    }

    public void Start()
    {
        levelController = LevelController.Instance;
    }
    // Update is called once per frame
    void Update()
    {
        if (waypoints.Count > 1)
        {

            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentTargetIndex].position, Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, waypoints[currentTargetIndex].rotation, 180);

            if (Vector3.Distance(transform.position, waypoints[currentTargetIndex].position) < 0.1f)
            {
                currentTargetIndex = (currentTargetIndex + 1) % waypoints.Count;
            }


        }
    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {

    //        GameObject.Instantiate(itemFeedback, this.transform.position, this.transform.rotation);

    //        //Increase player item pickup counter
    //        levelController.BeatedEnemy();
    //        Destroy(this.gameObject);

    //    }
    //}




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
