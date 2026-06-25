using BharatAssist.Core.Entities;
using BharatAssist.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using BharatAssist.API.DTOs;
using BharatAssist.Shared;
namespace BharatAssist.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly BharatAssistDbContext _context;

    public CategoryController(BharatAssistDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var categories = _context.Categories
            .Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Icon = c.Icon
            })
            .ToList();

        return Ok(new ApiResponse<List<CategoryDto>>
        {
            Success = true,
            Message = "Categories fetched successfully.",
            Data = categories
        });
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var category = _context.Categories.Find(id);

        if (category == null)
            return NotFound();

        return Ok(category);
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById),
            new { id = category.CategoryId },
            category);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Category updatedCategory)
    {
        var category = _context.Categories.Find(id);

        if (category == null)
            return NotFound();

        category.CategoryName = updatedCategory.CategoryName;
        category.Icon = updatedCategory.Icon;
        category.DisplayOrder = updatedCategory.DisplayOrder;
        category.IsActive = updatedCategory.IsActive;

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var category = _context.Categories.Find(id);

        if (category == null)
            return NotFound();

        _context.Categories.Remove(category);
        _context.SaveChanges();

        return NoContent();
    }
}