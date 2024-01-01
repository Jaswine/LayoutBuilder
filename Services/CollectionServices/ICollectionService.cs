using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutBuilder.Dtos.Collection;

namespace LayoutBuilder.Services.CollectionServices
{
    public interface ICollectionService
    {
        Task<CollectionResponse<List<Collection>>> GetAllCollections(string userId);
        Task<CollectionResponse<Collection>> GetCollectionById(int id, string userId);
        Task<CollectionResponse<Collection>> AddNewCollection(string userId, CreateCollectionDto newCollection);
        Task<CollectionResponse<Collection>> UpdateCollection(int id, string userId, CreateCollectionDto updateCollection);
        Task<CollectionResponse<Collection>> AddProjectToCollection(int id, string userId, UpdateProjectsCollectionDto updateCollection);
        Task<CollectionResponse<Collection>> RemoveProjectFromCollection(int id, string userId, UpdateProjectsCollectionDto updateCollection);
        Task<CollectionResponse<Collection>> RemoveCollection(int id, string userId);
    }
}