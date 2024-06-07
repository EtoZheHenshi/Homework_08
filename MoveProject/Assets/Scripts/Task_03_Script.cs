using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_03_Script : MonoBehaviour
{
    [SerializeField] private Character[] runners;
    [SerializeField] private GameObject baton;
    private GameObject batonPosition;
    private int currentRunner;
    private int nextRunner;

    void Start()
    {
        batonPosition = new GameObject();
        SetTransform(batonPosition.transform, baton.transform);
        ChangeRunner();
    }

    void Update()
    {
        runners[currentRunner].transform.position = Vector3.MoveTowards(runners[currentRunner].transform.position, 
            runners[nextRunner].transform.position, Time.deltaTime * 1.5f);
        if (runners[currentRunner].transform.position == runners[nextRunner].transform.position)
        {
            ChangeRunner();
        }
    }

    private void ChangeRunner()
    {
        runners[currentRunner].IsRunning = false;
        currentRunner = nextRunner;
        if (nextRunner == runners.Length - 1)
        {
            nextRunner = 0;
        }
        else
        {
            nextRunner++;
        }
        baton.transform.SetParent(runners[currentRunner].Body.RightHand.transform);
        SetTransform(baton.transform, batonPosition.transform);
        runners[currentRunner].transform.LookAt(runners[nextRunner].transform);
        runners[currentRunner].IsRunning = true;
    }

    private void SetTransform(Transform target, Transform template)
    {
        target.localPosition = template.localPosition;
        target.localRotation = template.localRotation;
    }
}
