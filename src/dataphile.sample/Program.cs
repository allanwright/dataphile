using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

namespace Dataphile.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string basePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Data");

            var services = new ServiceCollection()
                .AddFileStore(options => options.BasePath(basePath));
            
            IServiceProvider serviceProvider =
                services.BuildServiceProvider();

            IFileStoreService fileStoreService =
                serviceProvider.GetService<IFileStoreService>();

            var hoverboard = new Entity() { Id = 1, Name = "Hoverboard" };
            var almanac = new Entity() { Id = 2, Name = "Grays Sports Almanac" };

            // Insert new entities
            fileStoreService.Insert(hoverboard, hoverboard.Id);
            fileStoreService.Insert(almanac, almanac.Id);

            hoverboard.Name = "Pit Bull Hoverboard";

            // Update existing entity
            fileStoreService.Update(hoverboard, hoverboard.Id);

            // Read a single entity by id
            var pitbull = fileStoreService.ReadSingle<Entity>(hoverboard.Id);

            // Read all entities.
            IEnumerable<Entity> entities = fileStoreService.ReadAll<Entity>();

            foreach (Entity entity in entities)
            {
                // Delete an entity.
                fileStoreService.Delete<Entity>(entity.Id);
            }
        }
    }
}