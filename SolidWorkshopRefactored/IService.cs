using System.Collections.Generic;

namespace SolidWorkshopRefactored
{
    /// <summary>
    /// Represents a service.
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Saves changes of <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">A <see cref="Entity"/> for the saving changes.</param>
        /// <returns>A <see cref="Entity"/>.</returns>
        Entity Save(Entity entity);

        /// <summary>
        /// Reads all <see cref="Entity"/>.
        /// </summary>
        /// <returns>A <see cref="IEnumerable{Entity}"/>.</returns>
        IEnumerable<Entity> ReadAll();
    }
}
