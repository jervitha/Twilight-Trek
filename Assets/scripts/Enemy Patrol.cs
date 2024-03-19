using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float timeAtPoints;
    private float waitCounter;
    private int currentPoint;
    public Transform[] PatrolPoints;

    private void Start()
    {
        foreach (Transform t in PatrolPoints)
        {
            t.SetParent(null);
        }
        waitCounter = timeAtPoints;
       
    }

   private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, PatrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, PatrolPoints[currentPoint].position) < 0.001f)
        {
            waitCounter -= Time.deltaTime;
           
            if (waitCounter <= 0)
            {
                currentPoint++;
                if (currentPoint >= PatrolPoints.Length)
                {
                    currentPoint = 0;
                }
                waitCounter = timeAtPoints;
              
                if (transform.position.x > PatrolPoints[currentPoint].position.x)
                {
                    transform.localScale = Vector3.one;

                }
                else
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);

                }
            }
        }
    }
}
