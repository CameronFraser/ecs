namespace ECS.Components
{
    /// <summary>
    /// Determines if entity is controlled by keyboard or gamepad input
    /// The existence of it implies that this is true
    /// </summary>
    class MouseControlledComponent : EntityComponent
    {
        public MouseControlledComponent()
        {
            this.Name = "mouse_controlled";
        }
    }
}
