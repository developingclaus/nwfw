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
  public class ProductController : Controller
  {
    private IProductRepo _repo;
    private ILogger<ProductController> _logger;
    private IMapper _mapper;

    public ProductController(IProductRepo repo, ILogger<ProductController> logger, IMapper mapper)
    {
      _repo = repo;
      _logger = logger;
      _mapper = mapper;
    }
    
    // GET: api/product
    [HttpGet]
    public JsonResult Get()
    {
      return Json(_repo.GetAllProducts());
    }

    // GET api/product/1
    [HttpGet("{id}")]
    public JsonResult Get(int id)
    {
      var product = _repo.GetProductById(id);
      return Json(_mapper.Map<ProductViewModel>(product));
    }

    // POST api/product
    [HttpPost]
    public JsonResult Post([FromBody]ProductViewModel vm)
    {
      try
      {
        if (ModelState.IsValid)
        {
          var newProduct = _mapper.Map<Product>(vm);
          
          _logger.LogInformation("Attempting to save a new Product");
          _repo.PostProduct(newProduct);
          
          if (_repo.SaveAll())
          {
            Response.StatusCode = (int)HttpStatusCode.Created;
            return Json(_mapper.Map<ProductViewModel>(newProduct));            
          }
          
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to save new Product", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      
      return Json(new{message = "failed", ModelState = ModelState});
    }

    // PUT api/product/1
    [HttpPut("{id}")]
    public JsonResult Put(int id, [FromBody]ProductViewModel vm)
    {
      try
      {
        if (ModelState.IsValid)
        { 
          if (vm.Id != id)
          {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new {message = "Attempted to update different Product"});
          }
                    
          var product = _mapper.Map<Product>(vm);
          _logger.LogInformation("Attempting to save a new Product");
          _repo.PutProduct(product); 
          
          if (_repo.SaveAll())
          {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(_mapper.Map<ProductViewModel>(product));            
          }
        }
        
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to update Product", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      return Json(new{message = "failed", ModelState = ModelState});
    }
    
    // DELETE api/product/5
    [HttpDelete("{id}")]
    public JsonResult Delete(int id)
    {
      try
      {
        _logger.LogInformation("Attempting to delete a Product");
        var deletedProduct = _repo.DeleteProduct(id);
        
        if (_repo.SaveAll())
        {
          Response.StatusCode = (int)HttpStatusCode.OK;
          return Json(_mapper.Map<ProductViewModel>(deletedProduct));   
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to delete Product", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      return Json(new{message = "failed"});
    }
  }
}
