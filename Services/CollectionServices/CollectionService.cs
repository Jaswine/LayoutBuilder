using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutBuilder.Dtos.Collection;
using Microsoft.EntityFrameworkCore;

namespace LayoutBuilder.Services.CollectionServices
{
    public class CollectionService : ICollectionService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CollectionService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }   

         // ! _____________  SHOW ALL COLLECTIONS _____________
        public async Task<CollectionResponse<List<Collection>>> GetAllCollections(string userId)
        {
            var collectionResponse = new CollectionResponse<List<Collection>>();

            // collectionResponse.Data = await _context.Collections.Include(p => p.User).Include(p => p.CollectionProjects).Where(p => p.UserId == int.Parse(userId)).ToListAsync();
            collectionResponse.Data = await _context.Collections
                .Include(p => p.User)
                .Include(p => p.CollectionProjects)
                    .ThenInclude(cp => cp.Project) 
                .Where(p => p.UserId == int.Parse(userId))
                .ToListAsync();
                
            return collectionResponse;
        }

         // ! _____________  SHOW ONE USER COLLECTIONS _____________
        public async Task<CollectionResponse<Collection>> GetCollectionById(int id, string userId)
        {
            var collectionResponse = new CollectionResponse<Collection>();

            var collection =  await _context.Collections.Include(p => p.CollectionProjects).FirstOrDefaultAsync(p => p.Id == id);
            if (collection is not null)
            {
                if (collection.UserId == int.Parse(userId)) {
                    collectionResponse.Data = collection;
                    return collectionResponse;
                }
            } 

            collectionResponse.Success = false;
            collectionResponse.Message = "Collection Not Found";
            return collectionResponse;
        }

        // ! _____________  CREATE A NEW COLLECTION _____________
        public async Task<CollectionResponse<Collection>> AddNewCollection(string userId, CreateCollectionDto newCollection) 
        {
            var collectionResponse = new CollectionResponse<Collection>();
            DateTime currentDateAndTime = DateTime.Now;

            var collection = new Collection();
            collection.Title = newCollection.Title;
            collection.IsFavorite = false;
           
            collection.UserId = int.Parse(userId);

            collection.UpdatedAt = currentDateAndTime;
            collection.CreatedAt = currentDateAndTime;

            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();

            collectionResponse.Message = "Collection created successfully";
            collectionResponse.Data = collection;

            return collectionResponse;
        }

        
        // ! _____________  UPDATE COLLECTION _____________
        public async Task<CollectionResponse<Collection>> UpdateCollection(int id, string userId, CreateCollectionDto updateCollection) 
        {
            var collectionResponse = new CollectionResponse<Collection>();
            DateTime currentDateAndTime = DateTime.Now;

            var collection = await _context.Collections.FirstOrDefaultAsync(p => p.Id == id);
            if (collection is not null)
            {
                if (collection.UserId == int.Parse(userId)) {
                    collection.Title = updateCollection.Title;
                    collection.UpdatedAt = currentDateAndTime;
                    await _context.SaveChangesAsync();

                    collectionResponse.Data = collection;
                    collectionResponse.Message = "Collection Updated Successfully!";
                    return collectionResponse;
                }
            } 

            collectionResponse.Success = false;
            collectionResponse.Message = "Collection Not Found";
            return collectionResponse;
        }

        // ! _____________  ADD PROJECT TO COLLECTION _____________
        public async Task<CollectionResponse<Collection>> AddProjectToCollection(int id, string userId, UpdateProjectsCollectionDto updateCollection)
        {
            var collectionResponse = new CollectionResponse<Collection>();
            DateTime currentDateAndTime = DateTime.Now;

            var collection = await _context.Collections
                .Include(c => c.CollectionProjects)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (collection is not null)
            {
                if (collection.UserId == int.Parse(userId)) {
                    var project = await _context.Projects.FirstOrDefaultAsync(p => updateCollection.ProjectId == p.Id);

                    if (project != null)
                    {
                        if (collection.CollectionProjects.All(cp => cp.ProjectId != project.Id))
                        {
                            var collectionProject = new CollectionProject
                            {
                                CollectionId = collection.Id,
                                ProjectId = project.Id
                            };

                            collection.CollectionProjects.Add(collectionProject);

                            collection.UpdatedAt = currentDateAndTime;

                            await _context.SaveChangesAsync();

                            collectionResponse.Data = collection;
                            collectionResponse.Message = "Project added to collection successfully!";
                            return collectionResponse;
                        }
                        else {
                            collectionResponse.Message = "Project is already in the collection.";
                        }
                    }
                    else {
                        collectionResponse.Message = "Project not found.";
                    }
                }
            } 

            collectionResponse.Success = false;
            collectionResponse.Message = "Collection Not Found";
            return collectionResponse;
        }

        // ! _____________  REMOVE PROJECT TO COLLECTION _____________
        public async Task<CollectionResponse<Collection>> RemoveProjectFromCollection(int id, string userId, UpdateProjectsCollectionDto updateCollection)
        {
            var collectionResponse = new CollectionResponse<Collection>();
            DateTime currentDateAndTime = DateTime.Now;

            var collection = await _context.Collections.FirstOrDefaultAsync(p => p.Id == id);
            if (collection is not null)
            {
                if (collection.UserId == int.Parse(userId)) {

                    collection.UpdatedAt = currentDateAndTime;
                    await _context.SaveChangesAsync();

                    collectionResponse.Data = collection;
                    collectionResponse.Message = "Collection Updated Successfully!";
                    return collectionResponse;
                }
            } 

            collectionResponse.Success = false;
            collectionResponse.Message = "Collection Not Found";
            return collectionResponse;
        }


        // ! _____________  REMOVE COLLECTION _____________
        public async Task<CollectionResponse<Collection>> RemoveCollection(int id, string userId) {
             var collectionResponse = new CollectionResponse<Collection>();

            var collection = await _context.Collections.FirstOrDefaultAsync(p => p.Id == id);

            if (collection is not null)
            {
                if (collection.UserId == int.Parse(userId)) {
                    _context.Collections.Remove(collection);
                    await _context.SaveChangesAsync();

                    collectionResponse.Message = "Collection removed successfully!";
                    return collectionResponse;
                }
            } 

            collectionResponse.Success = false;
            collectionResponse.Message = "Collection Not Found";
            return collectionResponse;
        }
    }
}