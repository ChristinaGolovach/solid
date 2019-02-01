using System;

namespace SolidWorkshopRefactored
{
    /// <summary>
    /// Represents an abstract entity.
    /// </summary>
    public abstract class AbstractEntity
    {
        /// <summary>
        /// Gets or sets an abstract entity identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets date when an abstract entity was created.
        /// </summary>
        public DateTime CreadedDate { get; set; }
    }
}
