public class AI_AggressiveMelee : NavmeshMovement
{
    protected override void Update()
    {
        base.Update();
        AggressiveSight();
        switch (_state)
        {
            case State._Idle:
                WanderFromOrigin();
                break;
            case State._Wander:
                WanderFromOrigin();
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