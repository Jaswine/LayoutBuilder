using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutBuilder.Dtos.Collection;
using LayoutBuilder.Services.CollectionServices;
using LayoutBuilder.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LayoutBuilder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionService _collectionService;

        public CollectionController(ICollectionService collectionService) 
        {
            _collectionService = collectionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Collection>>> GetAllCollections()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok( await _collectionService.GetAllCollections(userId));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Collection>> GetSingle(int id) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok( await _collectionService.GetCollectionById(id, userId));
        }

        [HttpPost]
        public async Task<ActionResult<Collection>> AddNewCollection(CreateCollectionDto newCollection) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok(await _collectionService.AddNewCollection(userId, newCollection));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Collection>> UpdateTitleCollection(int id, CreateCollectionDto  updatedCollection) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok(await _collectionService.UpdateCollection(id, userId, updatedCollection));
        }

        [HttpPut("{id}/addNewProject")]
        public async Task<ActionResult<Collection>> AddProjectToCollection(int id, UpdateProjectsCollectionDto  updatedCollection) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok(await _collectionService.AddProjectToCollection(id, userId, updatedCollection));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Collection>> RemoveCollection(int id) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok(await _collectionService.RemoveCollection(id, userId));
        }
    }
}