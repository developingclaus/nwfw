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
  public class VendorController : Controller
  {
    private IVendorRepo _repo;
    private ILogger<VendorController> _logger;
    private IMapper _mapper;

    public VendorController(IVendorRepo repo, ILogger<VendorController> logger, IMapper mapper)
    {
      _repo = repo;
      _logger = logger;
      _mapper = mapper;
    }
    
    // GET: api/vendor
    [HttpGet]
    public JsonResult Get()
    {
      return Json(_repo.GetAllVendors());
    }

    // GET api/vendor/1
    [HttpGet("{id}")]
    public JsonResult Get(int id)
    {
      var vendor = _repo.GetVendorById(id);
      return Json(_mapper.Map<VendorViewModel>(vendor));
    }

    // POST api/vendor
    [HttpPost]
    public JsonResult Post([FromBody]VendorViewModel vm)
    {
      try
      {
        if (ModelState.IsValid)
        {
          var newVendor = _mapper.Map<Vendor>(vm);
          
          _logger.LogInformation("Attempting to save a new Vendor");
          _repo.PostVendor(newVendor);
          
          if (_repo.SaveAll())
          {
            Response.StatusCode = (int)HttpStatusCode.Created;
            return Json(_mapper.Map<VendorViewModel>(newVendor));            
          }
          
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to save new Vendor", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      
      return Json(new{message = "failed", ModelState = ModelState});
    }

    // PUT api/vendor/1
    [HttpPut("{id}")]
    public JsonResult Put(int id, [FromBody]VendorViewModel vm)
    {
      try
      {
        if (ModelState.IsValid)
        { 
          if (vm.Id != id)
          {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new {message = "Attempted to update different Vendor"});
          }
                    
          var vendor = _mapper.Map<Vendor>(vm);
          _logger.LogInformation("Attempting to save a new Vendor");
          _repo.PutVendor(vendor); 
          
          if (_repo.SaveAll())
          {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(_mapper.Map<VendorViewModel>(vendor));            
          }
        }
        
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to update Vendor", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      return Json(new{message = "failed", ModelState = ModelState});
    }

    // DELETE api/vendor/5
    [HttpDelete("{id}")]
    public JsonResult Delete(int id)
    {
      try
      {
        _logger.LogInformation("Attempting to delete a Vendor");
        var deletedVendor = _repo.DeleteVendor(id);
        
        if (_repo.SaveAll())
        {
          Response.StatusCode = (int)HttpStatusCode.OK;
          return Json(_mapper.Map<VendorViewModel>(deletedVendor));   
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to delete Vendor", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      return Json(new{message = "failed"});
    }
  }
}
