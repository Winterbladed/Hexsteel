public class AI_Passive : NavmeshMovement
{
    protected override void Update()
    {
        base.Update();
        switch (_state)
        {
            case State._Idle:
                Wander();
                break;
            case State._Wander:
                Wander();
                break;
            case State._Aggro:
                Wander();
                break;
            case State._Retreat:
                RetreatToWander();
                break;
        }
    }
}