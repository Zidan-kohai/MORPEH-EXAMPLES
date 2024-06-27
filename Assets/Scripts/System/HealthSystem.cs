using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(HealthSystem))]
public sealed class HealthSystem : UpdateSystem {

    private Filter filter;
    private Stash<HealthComponent> healthStash;
    public override void OnAwake() 
    {
        filter = World.Filter.With<HealthComponent>().Build();
        healthStash = World.GetStash<HealthComponent>();
    }

    public override void OnUpdate(float deltaTime) 
    {
        foreach (Entity entity in filter)
        {
            ref HealthComponent healtComponent = ref healthStash.Get(entity);

            Debug.Log(healtComponent.Health);
        }
    }
}