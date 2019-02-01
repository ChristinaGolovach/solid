using System.Collections.Generic;

namespace SolidWorkshopRefactored
{
    /// <summary>
    /// Represents a repository for <see cref="AbstractEntity"/>
    /// </summary>
    /// <typeparam name="TEntity"> A <see cref="AbstractEntity"/>.</typeparam>
    public interface IRepository <TEntity> where TEntity : AbstractEntity
    {
        /// <summary>
        /// Saves an entity in Database.
        /// </summary>
        /// <param name="entity"> A <see cref="AbstractEntity"/>for saving.</param>
        /// <returns>A <see cref="AbstractEntity"/>.</returns>
        TEntity Save(TEntity entity);

        /// <summary>
        /// Gets all entities from Database.
        /// </summary>
        /// <returns>A <see cref="IEnumerable{AbstractEntity}"/>.</returns>
        IEnumerable<TEntity> GetAll();
    }
}
