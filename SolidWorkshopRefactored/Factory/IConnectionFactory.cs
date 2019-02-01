using System.Data;

namespace SolidWorkshopRefactored.Factory
{
    /// <summary>
    /// Represents a connection factory.
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// Creates a connection with Database.
        /// </summary>
        /// <returns> A <see cref="IDbConnection"/>.</returns>
        IDbConnection CreateConnection();
    }
}
