using ECS.ECS;

namespace ECS.Components
{
    /// <summary>
    /// Determines if entity is controlled by keyboard or gamepad input
    /// The existence of it implies that this is true
    /// </summary>
    class MouseControlled: IEntityComponent
    {
        public string Name { get; set; }

        public MouseControlled()
        {
            this.Name = "mouse_controlled";
        }
    }
}
