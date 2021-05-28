
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

//Endpoint => URL
// http://localhost:5000
// https://localhost:5001 <- Produção sempre HTTPS
// https://meuapp.azurewebsites.net/


//https://localhost:5001/categories/
[Route("categories")]
public class CategoryController : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Category>>> Get()
    {
        return new List<Category>();
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        return new Category();
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Category>> Post([FromBody] Category model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(model);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> Put(int id, [FromBody] Category model)
    {
        if (model.Id == id)
            return Ok(model);

        return NotFound();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public Task<ActionResult<Category>> Delete()
    {
        return Ok();
    }
}