using UnityEngine;

namespace Assets.Scripts
{
    public class StandingState : State
    {
        public StandingState(Character character, StateMachine stateMachine) : base(character, stateMachine) 
        {
        }

        public override void Enter()
        {
            base.Enter();
            character.Body.LeftHand.transform.localRotation = new Quaternion(0, 0, 0, 1);
            character.Body.RightHand.transform.localRotation = new Quaternion(0, 0, 0, 1);
            character.Body.LeftLeg.transform.localRotation = new Quaternion(0, 0, 0, 1);
            character.Body.RightLeg.transform.localRotation = new Quaternion(0, 0, 0, 1);
        }

        public override void Update()
        {
            base.Update();
            if (character.IsRunning)
            {
                stateMachine.ChangeState(character.Running);
            }
        }
    }
}
