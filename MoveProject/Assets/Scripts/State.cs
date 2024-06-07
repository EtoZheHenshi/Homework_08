namespace Assets.Scripts
{
    public abstract class State
    {
        protected Character character;
        protected StateMachine stateMachine;

        protected State(Character character, StateMachine stateMachine)
        {
            this.character = character;
            this.stateMachine = stateMachine;
        }

        public virtual void Enter()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void Exit()
        {
        }
    }
}
