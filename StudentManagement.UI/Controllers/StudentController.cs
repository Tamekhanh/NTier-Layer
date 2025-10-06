using Microsoft.AspNetCore.Mvc;
using StudentManagement.Application.DTOs;
using StudentManagement.Application.Interfaces;

namespace StudentManagement.UI.Controllers;

public class StudentController : Controller
{
    private readonly IStudentService _service;

    public StudentController(IStudentService service)
    {
        _service = service;
    }

    // READ
    public async Task<IActionResult> Index()
    {
        var students = await _service.GetAllAsync();
        return View(students);
    }

    // CREATE
    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(StudentDto dto)
    {
        if (ModelState.IsValid)
        {
            await _service.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        return View(dto);
    }

    // EDIT
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var student = await _service.GetByIdAsync(id);
        if (student == null) return NotFound();
        return View(student);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(StudentDto dto)
    {
        if (ModelState.IsValid)
        {
            await _service.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        return View(dto);
    }

    // DELETE
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _service.GetByIdAsync(id);
        if (student == null) return NotFound();
        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
