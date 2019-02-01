using System;
using System.Collections.Generic;


namespace SolidWorkshopRefactored
{
    /// <summary>
    /// Represents a base class of <see cref="IService"/>.
    /// </summary>
    public class Service : IService
    {
        private IEntityRepository entityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class with specified <see cref="IEntityRepository"/>. 
        /// </summary>
        /// <param name="entityRepository">A <see cref="IEntityRepository"/>.</param>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="entityRepository"/> is null.</exception>
        public Service(IEntityRepository entityRepository)
        {
            entityRepository = entityRepository ?? throw new ArgumentNullException($"The {nameof(entityRepository)} can not be null.");

            this.entityRepository = entityRepository;
        }

        /// <summary>
        /// Saves changes of <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">A <see cref="Entity"/> for saving chages.</param>
        /// <returns>A <see cref="Entity"/>.</returns>
        /// <exception cref="ApplicationException">Throws when <paramref name="entity"/> is null.</exception>
        /// <exception cref="ApplicationException">Throws when save attempt has done.</exception>
        public Entity Save(Entity entity)
        {
            entity = entity ?? throw new ArgumentNullException($"The {nameof(entity)} can not be null.");

            try
            {
                var savedEntity = entityRepository.Save(entity);

                return savedEntity;
            }
            //DbSavingException
            catch (ApplicationException exception)
            {
                //log exception
                throw;
            }          
        }

        /// <summary>
        /// Reads all <see cref="Entity"/>.
        /// </summary>
        /// <returns>A <see cref="IEnumerable{Entity}"/>.</returns>
        /// <exception cref="ApplicationException">Throws when failed read attempt has done.</exception>
        public IEnumerable<Entity> ReadAll()
        {
            try
            {
                var entities = entityRepository.GetAll();

                return entities;
            }

            //DbReadingException
            catch (ApplicationException exception)
            {
                //log exception
                throw;
            }
        }
    }
}
