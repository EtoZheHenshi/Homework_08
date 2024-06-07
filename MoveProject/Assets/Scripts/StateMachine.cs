namespace Assets.Scripts
{
    public class StateMachine
    {
        public State CurrentState { get; private set; }

        public void Initialization(State startertState)
        {
            CurrentState = startertState;
            CurrentState.Enter();
        }

        public void ChangeState(State newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}
