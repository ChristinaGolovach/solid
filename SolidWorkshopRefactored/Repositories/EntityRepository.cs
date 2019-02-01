using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SolidWorkshopRefactored.Factory;

namespace SolidWorkshopRefactored
{
    /// <summary>
    /// Represents a base class for <see cref="IEntityRepository"/>.
    /// </summary>
    public class EntityRepository : IEntityRepository
    {
        private IDbConnection _dbConnection;

        private IConnectionFactory _connectionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityRepository"/> class with specified <see cref="IConnectionFactory"/>. 
        /// </summary>
        /// <param name="connectionFactory">A <see cref="IConnectionFactory"/>.</param>
        public EntityRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// Gets all entities from Database.
        /// </summary>
        /// <returns>A <see cref="IEnumerable{Entity}"/>.</returns>
        /// <exception cref="ApplicationException">Throws when failed read attempt has done.</exception>
        public IEnumerable<Entity> GetAll()
        {
            using(_dbConnection = _connectionFactory.CreateConnection())
            {
                try
                {
                    _dbConnection.Open();

                    //perform read

                    return new List<Entity>();
                }
                catch (DbException exception)
                {
                    // or custom DbReadingException
                    throw new ApplicationException("Exception has occurred during the reading data from DB.", exception);
                }
            }
        }

        /// <summary>
        /// Saves changes of entity in Database.
        /// </summary>
        /// <param name="entity">A <see cref="Entity"/>.</param>
        /// <returns>A <see cref="Entity"/>.</returns>
        /// <exception cref="ApplicationException">Throws when two failed save attempts have done.</exception>
        public Entity Save(Entity entity)
        {
            using (_dbConnection = _connectionFactory.CreateConnection())
            {
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        _dbConnection.Open();

                        //perform save

                        return entity;
                    }
                    catch (DbException exception)
                    {                       
                        if (i == 2)
                            // or custom DbSavingException
                            throw new ApplicationException("Exception has occurred during the saving data in DB.", exception);
                    }                    
                }

                return entity;
            }
        }        
    }
}
