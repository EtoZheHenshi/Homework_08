using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterBody body;
    private StateMachine movementSM;
    private StandingState standing;
    private RunningState running;
    private bool isRunning;

    public CharacterBody Body { get { return body; } }
    public StandingState Standing { get { return standing; } }
    public RunningState Running { get { return running; } }
    public bool IsRunning {  get { return isRunning; } set { isRunning = value; } }

    void Start()
    {
        movementSM = new StateMachine();
        standing = new StandingState(this, movementSM);
        running = new RunningState(this, movementSM);

        movementSM.Initialization(standing);
    }

    // Update is called once per frame
    void Update()
    {
        movementSM.CurrentState.Update();
    }
}
