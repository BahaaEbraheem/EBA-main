using Microsoft.EntityFrameworkCore;
using OA.DataAccess;
using OA.Domin.Attributes;
using OA.Domin.Reflection;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Services.Seeding
{
    public class SeedTestDataService<T> : ISeedTestDataService where T : class, new()
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public SeedTestDataService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public void Seed(string typeName, int totalSeed)
        {
            var type = ReflectionAccessor.GetType(typeName);

            for (int i = 0; i < totalSeed; i++)
            {
                var testEntity = GetTestEntity(type);
                dbSet.Add(testEntity);
                dbContext.SaveChanges();
            }

        }


        public T GetTestEntity(Type type)
        {
            var props = type.GetProperties();

            var testEntity = ReflectionAccessor.FastActivator<T>.Create();

            return testEntity;

            //foreach(var prop in props)
            //{

            //}

        }

    }
}
