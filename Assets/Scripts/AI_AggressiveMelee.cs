public class AI_AggressiveMelee : NavmeshMovement
{
    protected override void Update()
    {
        base.Update();
        GroupAggressiveSight();
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