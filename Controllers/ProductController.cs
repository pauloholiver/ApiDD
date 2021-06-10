
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

//Endpoint => URL
// http://localhost:5000
// https://localhost:5001 <- Produção sempre HTTPS
// https://meuapp.azurewebsites.net/


//https://localhost:5001/categories/
[Route("products")]
public class ProductController : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Product>>> Get(
        [FromServices] DataContext context)
    {
        var products = await context.Products.Include(x => x.Category).AsNoTracking().ToListAsync();
        return products;
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Product>> GetById(
        int id,
        [FromServices] DataContext context)
    {
        var product = await context.Products.Include(x => x.Category).AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync(x => x.Id == id);
        return product;
    }

    [HttpGet]
    [Route("categories/{id:int}")]
    public async Task<ActionResult<List<Product>>> GetByCategory(
    int id,
    [FromServices] DataContext context)
    {
        var products = await context.Products.Include(x => x.Category)
        .AsNoTracking().Where(x => x.CategoryId == id).ToListAsync();

        if (products.Count == 0)
        {
            return NotFound(new { message = "Categoria não encontrada ou sem produtos cadastrados" });
        }
        else
            return products;
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Product>> Post(
        [FromServices] DataContext context,
        [FromBody] Product model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            context.Products.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch
        {
            return BadRequest(new { message = "Não foi possível criar o produto" });
        }
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Product>> Put(
        int id,
        [FromBody] Product model,
        [FromServices] DataContext context)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            context.Entry<Product>(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch (Exception)
        {
            return BadRequest(new { message = "Não foi possível atualizar o produto" });
        }
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<List<Product>>> Delete(
        int id,
        [FromServices] DataContext context)
    {
        var Product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (Product == null)
            return NotFound(new { message = "Produto não encontrado" });

        try
        {
            context.Products.Remove(Product);
            await context.SaveChangesAsync();
            return Ok(Product);
        }
        catch (Exception)
        {
            return BadRequest(new { message = "Não foi possível remover o produto" });
        }
    }
}