public class AI_Neutral : NavmeshMovement
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
                RunToTarget();
                AttackWhenNearTarget();
                break;
            case State._Retreat:
                RetreatToIdle();
                break;
        }
    }
}