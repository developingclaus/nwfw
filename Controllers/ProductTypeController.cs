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
  public class ProductTypeController : Controller
  {
    private IProductTypeRepo _repo;
    private ILogger<ProductTypeController> _logger;
    private IMapper _mapper;

    public ProductTypeController(IProductTypeRepo repo, ILogger<ProductTypeController> logger, IMapper mapper)
    {
      _repo = repo;
      _logger = logger;
      _mapper = mapper;
    }
    
    // GET: api/producttype
    [HttpGet]
    public JsonResult Get()
    {
      return Json(_repo.GetAllProductTypes());
    }

    // GET api/producttype/1
    [HttpGet("{id}")]
    public JsonResult Get(int id)
    {
      var producttype = _repo.GetProductTypeById(id);
      return Json(_mapper.Map<ProductTypeViewModel>(producttype));
    }

    // POST api/producttype
    [HttpPost]
    public JsonResult Post([FromBody]ProductTypeViewModel vm)
    {
      try
      {
        if (ModelState.IsValid)
        {
          var newProductType = _mapper.Map<ProductType>(vm);
          
          _logger.LogInformation("Attempting to save a new ProductType");
          _repo.PostProductType(newProductType);
          
          if (_repo.SaveAll())
          {
            Response.StatusCode = (int)HttpStatusCode.Created;
            return Json(_mapper.Map<ProductTypeViewModel>(newProductType));            
          }
          
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to save new ProductType", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      
      return Json(new{message = "failed", ModelState = ModelState});
    }

    // PUT api/producttype/1
    [HttpPut("{id}")]
    public JsonResult Put(int id, [FromBody]ProductTypeViewModel vm)
    {
      try
      {
        if (ModelState.IsValid)
        { 
          if (vm.Id != id)
          {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new {message = "Attempted to update different ProductType"});
          }
                    
          var producttype = _mapper.Map<ProductType>(vm);
          _logger.LogInformation("Attempting to save a new ProductType");
          _repo.PutProductType(producttype); 
          
          if (_repo.SaveAll())
          {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(_mapper.Map<ProductTypeViewModel>(producttype));            
          }
        }
        
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to update ProductType", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      return Json(new{message = "failed", ModelState = ModelState});
    }
    
    // DELETE api/producttype/5
    [HttpDelete("{id}")]
    public JsonResult Delete(int id)
    {
      try
      {
        _logger.LogInformation("Attempting to delete a ProductType");
        var deletedProductType = _repo.DeleteProductType(id);
        
        if (_repo.SaveAll())
        {
          Response.StatusCode = (int)HttpStatusCode.OK;
          return Json(_mapper.Map<ProductTypeViewModel>(deletedProductType));   
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to delete ProductType", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      return Json(new{message = "failed"});
    }
  }
}
