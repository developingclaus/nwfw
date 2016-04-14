using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using nwfw.Models;
using nwfw.Repositories.Interfaces;
using nwfw.ViewModels;

namespace nwfw.Controllers
{
  [Route("api/[controller]")]
  public class WoodController : Controller
  {
    private IWoodRepo _repo;
    private ILogger<WoodController> _logger;
    private IMapper _mapper;

    public WoodController(IWoodRepo repo, ILogger<WoodController> logger, IMapper mapper)
    {
      _repo = repo;
      _logger = logger;
      _mapper = mapper;
    }
    
    // GET: api/wood
    [HttpGet]
    public JsonResult Get()
    {
      return Json(_repo.GetAllWood());
    }

    // GET api/wood/1
    [HttpGet("{id}")]
    public JsonResult Get(int id)
    {
      var wood = _repo.GetWoodById(id);
      return Json(_mapper.Map<WoodViewModel>(wood));
    }

    // POST api/wood
    [HttpPost]
    public JsonResult Post([FromBody]WoodViewModel vm)
    {
      try
      {
        if (ModelState.IsValid)
        {
          var newWood = _mapper.Map<Wood>(vm);
          
          _logger.LogInformation("Attempting to save a new Wood");
          _repo.PostWood(newWood);
          
          if (_repo.SaveAll())
          {
            Response.StatusCode = (int)HttpStatusCode.Created;
            return Json(_mapper.Map<WoodViewModel>(newWood));            
          }
          
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to save new Wood", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      
      return Json(new{message = "failed", ModelState = ModelState});
    }

    // PUT api/wood/1
    [HttpPut("{id}")]
    public JsonResult Put(int id, [FromBody]WoodViewModel vm)
    {
      try
      {
        if (ModelState.IsValid)
        { 
          if (vm.Id != id)
          {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new {message = "Attempted to update different Wood"});
          }
                    
          var wood = _mapper.Map<Wood>(vm);
          _logger.LogInformation("Attempting to save a new Wood");
          _repo.PutWood(wood); 
          
          if (_repo.SaveAll())
          {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(_mapper.Map<WoodViewModel>(wood));            
          }
        }
        
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to update Wood", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      return Json(new{message = "failed", ModelState = ModelState});
    }

    // DELETE api/wood/5
    [HttpDelete("{id}")]
    public JsonResult Delete(int id)
    {
      try
      {
        _logger.LogInformation("Attempting to delete a Wood");
        var deletedWood = _repo.DeleteWood(id);
        
        if (_repo.SaveAll())
        {
          Response.StatusCode = (int)HttpStatusCode.OK;
          return Json(_mapper.Map<WoodViewModel>(deletedWood));   
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to delete Wood", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      return Json(new{message = "failed"});
    }
  }
}
