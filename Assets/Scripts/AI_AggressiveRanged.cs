public class AI_AggressiveRanged : NavmeshMovement
{
    protected override void Update()
    {
        base.Update();
        AggressiveSight();
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
                AttackRangeWhenNearTarget();
                break;
            case State._Retreat:
                RetreatToIdle();
                break;
        }
    }
}