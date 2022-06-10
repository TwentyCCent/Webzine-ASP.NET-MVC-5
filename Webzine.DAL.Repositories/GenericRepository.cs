// <copyright file="GenericRepository.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Webzine.EntitiesContext;
    using Webzine.Repositories.Contracts;

    /// <inheritdoc />
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class, new()
    {
        private readonly WebzineDbContext context;

        /// <summary>
        /// Table de base de données de type T.
        /// </summary>
        protected DbSet<T> table;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="GenericRepository{T}"/>.
        /// </summary>
        public GenericRepository()
        {
            this.context = new WebzineDbContext();
            this.table = this.context.Set<T>();
        }

        /// <inheritdoc />
        public T Find(object id)
        {
            return this.table.Find(id);
        }

        /// <inheritdoc />
        public IQueryable<T> FindAll()
        {
            return this.table;
        }

        /// <inheritdoc />
        public void Add(T value)
        {
            this.table.Add(value);
        }

        /// <inheritdoc />
        public void AddRange(List<T> value)
        {
            this.table.AddRange(value);
        }

        /// <inheritdoc />
        public void Update(T value)
        {
            this.table.Attach(value);
            this.context.Entry(value).State = EntityState.Modified;
        }

        /// <inheritdoc />
        public void Delete(object id)
        {
            T entityExisting = this.table.Find(id);
            this.table.Remove(entityExisting);
        }

        /// <inheritdoc />
        public int Count()
        {
            return this.table.Count();
        }

        /// <inheritdoc />
        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
