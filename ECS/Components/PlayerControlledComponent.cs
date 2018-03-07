using ECS.ECS;

namespace ECS.Components
{
    /// <summary>
    /// Determines if entity is controlled by keyboard or gamepad input
    /// The existence of it implies that this is true
    /// </summary>
    class PlayerControlledComponent : EntityComponent
    {
        public override string Name { get; set; }

        public PlayerControlledComponent()
        {
            this.Name = "player_controlled";
        }
    }
}
