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
}

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
    _ArmoredFaction,
    _ShieldedFaction,
    _HealthyFaction,
}

public enum State
{
    _Idle,
    _Wander,
    _Aggro,
    _Retreat,
}