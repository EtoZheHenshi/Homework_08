using UnityEngine;

namespace Assets.Scripts
{
    public class RunningState : State
    {
        private bool reverse;
        private Transform leftHand;
        private Transform rightHand;
        private Transform leftLeg;
        private Transform rightLeg;
        public RunningState(Character character, StateMachine stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            leftHand = character.Body.LeftHand.transform;
            rightHand = character.Body.RightHand.transform;
            leftLeg = character.Body.LeftLeg.transform;
            rightLeg = character.Body.RightLeg.transform;
        }

        public override void Update()
        {
            base.Update();
            Rotating(ref leftLeg, ref rightLeg);
            Rotating(ref rightHand, ref leftHand);

            if (!character.IsRunning)
            {
                stateMachine.ChangeState(character.Standing);
            }
        }

        private void Rotating(ref Transform forward, ref Transform back)
        {
            if (forward.localRotation.x <= -0.45f)
            {
                Transform tempVec = forward;
                forward = back;
                back = tempVec;
            }
            forward.Rotate(Vector3.left, 1f);
            back.Rotate(Vector3.left, -1f);
        }
    }
}
