using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour {

    [SerializeField] private float maxObstacleSpacing;
    [SerializeField] private float minObstacleSpacing;
    [SerializeField] private float topPosition;
    [SerializeField] private float botPosition;
    [SerializeField] private float zLocation;
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private GameObject[] finalObstacleArray;
    [SerializeField] private Transform player;


    public Queue<GameObject> tempObstacleList;
    public int LastGridIndex = 0;


    private void Start()
    {
        tempObstacleList = new Queue<GameObject>(obstaclePrefabs);
    }


    void FixedUpdate()
    {

        // check for certain position to generate obstacles
        if (player.position.x > (LastGridIndex * 70))
        {
            // obstacle index presented in obstaclePrefabs
            int obsIndex = LastGridIndex % obstaclePrefabs.Length;

            // generate two obstacles
            int oddObstacle = Random.Range(40, 60);
            GenerateObstacle((LastGridIndex * 70) + oddObstacle);

            int evenObstacle = Random.Range(30, 60);
            if (oddObstacle - evenObstacle < 40)
            {
                evenObstacle += 30;
            }
            GenerateObstacle((LastGridIndex * 70) + evenObstacle);


            LastGridIndex++;
        }

    }


    void GenerateObstacle(float Xposition)
    {
        var obstacleObject = tempObstacleList.Dequeue();
        var mPosition = (obstacleObject.name == "Top") ? topPosition : botPosition;

        var obstacle = Instantiate(obstacleObject, transform);
        SetTransformExistingObstacle(obstacle, Xposition, mPosition);

        // re-init obstacleObject queue list
        if (tempObstacleList.Count == 0)
            tempObstacleList = new Queue<GameObject>(obstaclePrefabs);
    }


    void SetTransformExistingObstacle(GameObject obstacle, float Xposition, float Yposition)
    {
        obstacle.transform.position = new Vector3(Xposition, Yposition, zLocation);
    }


}


