using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Task_02_Script : MonoBehaviour
{
    [SerializeField] GameObject[] cubes;
    private float distance;
    private float passedDictance;
    private int runner;
    private int previousRunner;
    private int nextRunner;
    private Vector3 previousRunnerFinishPoint;

    void Start()
    {
        runner = -1;
        nextRunner = 0;
        ChangeRunner();
    }

    void Update()
    {
        cubes[runner].transform.position = Vector3.MoveTowards(cubes[runner].transform.position, cubes[nextRunner].transform.position, Time.deltaTime * 2);
        passedDictance = distance - Vector3.Distance(cubes[runner].transform.position, cubes[nextRunner].transform.position);
        if (previousRunner > -1)
        {
            cubes[previousRunner].transform.position = Vector3.Lerp(cubes[previousRunner].transform.position, previousRunnerFinishPoint, 0.01f);
        }
        if (distance * 0.7 < passedDictance)
        {
            ChangeRunner();
        }
    }

    private void ChangeRunner()
    {
        enabled = false;
        previousRunner = runner;
        runner = nextRunner;
        if (nextRunner == cubes.Length -1)
        {
            nextRunner = 0;
        }
        else
        {
            nextRunner++;
        }
        
        previousRunnerFinishPoint = CopyPosition(cubes[runner].transform.position);
        distance = Vector3.Distance(cubes[runner].transform.position, cubes[nextRunner].transform.position);
        cubes[runner].transform.LookAt(cubes[nextRunner].transform);
        enabled = true;
    }

    private Vector3 CopyPosition(Vector3 vector)
    {
        float x = vector.x; 
        float y = vector.y;
        float z = vector.z;
        return new Vector3(x, y, z);
    }
}
