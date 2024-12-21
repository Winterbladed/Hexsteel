public enum DamageType
{
    _None,
    //Base Physical
    _Blunt,
    _Pierce,
    _Slash,
    //Base Elemental
    _Toxin,
    _Ice,
    _Fire,
    _Electric,
    //Advanced Elemental
    _Virus,
    _Gas,
    _Corrode,
    _Melt,
    _Magnetic,
    _Blast,
    //Secret
    _Hex,
}

public enum ProjectileVector
{
    Straight, Left, Right, Upper, Lower,
    UpperLeft, UpperRight, LowerRight, LowerLeft
}

public enum ProjectileType { Normal, Physics }

public enum _TargetData
{
    _Player,
    _Rigidbody,
    _AudioSource,
    _Interactable,
    _Item,
    _Health,
    _Movement,
    _NavmeshMovement,
    _AI_Passive,
    _AI_Aggressive,
    _AI_Neutral,
}

public enum State
{
    _Idle,
    _Wander,
    _Aggro,
    _Retreat,
}