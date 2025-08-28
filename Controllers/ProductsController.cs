﻿using Microsoft.AspNetCore.Mvc;
using ProductApi.DTOs;
using ProductApi.Services.Interface;

namespace ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly  IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var productsDto = await _productService.GetProducts();
        if (productsDto == null)
        {
            return NotFound("Products not found");
        }
        return Ok(productsDto);
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var productDto = await _productService.GetProductById(id);
        if (productDto == null)
        {
            return NotFound("Product not found");
        }
        return Ok(productDto);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] ProductDto productDto)
    {
        if (productDto == null)
        {
            return BadRequest("Product data is null");
        }
        await _productService.AddProduct(productDto);
        
        return new CreatedAtRouteResult("GetProduct", 
            new { id = productDto.Id }, productDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] ProductDto productDto)
    {
        if (id != productDto.Id)
        {
            return BadRequest("Product ID mismatch");
        }

        if (productDto == null)
        {
            return BadRequest("Product data is null");
        }

        await _productService.UpdateProduct(productDto);
        return Ok(productDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ProductDto>> Delete(int id)
    {
        var productDto = await _productService.GetProductById(id);

        if (productDto == null)
        {
            return NotFound("Product not found");
        }
        
        await _productService.DeleteProduct(id);
        return Ok();
    }
}