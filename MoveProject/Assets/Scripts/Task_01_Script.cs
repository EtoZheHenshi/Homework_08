using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Task_01_Script : MonoBehaviour
{
    private Vector3[] vecArray;
    private bool forward;
    private Transform distance;
    private Random rand;
    private int targetIndex;
    [SerializeField] private GameObject[] points;

    void Start()
    {
        rand = new Random();
        vecArray = new Vector3[4];
        forward = true;
        for (int i = 0; i < vecArray.Length; i++)
        {
            vecArray[i] = new Vector3(rand.Next(0, 11), rand.Next(0, 11), rand.Next(0, 11));
            points[i].transform.position = vecArray[i];
        }
        targetIndex = 1;
        transform.position = vecArray[0];
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, vecArray[targetIndex], Time.deltaTime * 2f);
        if (transform.position == vecArray[targetIndex])
        {
            if (targetIndex == vecArray.Length - 1 || targetIndex == 0)
            {
                forward = !forward;
            }

            if (forward)
            {
                targetIndex++;
            }
            else
            {
                targetIndex--;
            }
        }
    }
}
