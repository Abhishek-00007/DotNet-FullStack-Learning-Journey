using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureNoteAPI.Data;
using SecureNoteAPI.DTOs;
using SecureNoteAPI.Models;
using System.Security.Claims;

namespace SecureNoteAPI.Controllers;

[ApiController]

[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly AppDbContext _context;

    public NotesController(AppDbContext context)
    {
        _context = context;
    }

    private int GetUserId()
    {
        return int.Parse(
            User.FindFirstValue(
                ClaimTypes.NameIdentifier)!);
    }

    [HttpPost]
    public async Task<IActionResult> Add(NoteDto dto)
    {
        var note = new Note
        {
            Title = dto.Title,
            Content = dto.Content,
            UserId = GetUserId()
        };

        _context.Notes.Add(note);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Note added successfully.",
            noteId = note.Id
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var notes = await _context.Notes
            .Where(n => n.UserId == GetUserId())
            .ToListAsync();

        return Ok(notes);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        NoteDto dto)
    {
        var note = await _context.Notes
            .FirstOrDefaultAsync(
                x => x.Id == id &&
                     x.UserId == GetUserId());

        if (note == null)
            return NotFound();

        note.Title = dto.Title;
        note.Content = dto.Content;

        await _context.SaveChangesAsync();

        return Ok("Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var note = await _context.Notes
            .FirstOrDefaultAsync(
                x => x.Id == id &&
                     x.UserId == GetUserId());

        if (note == null)
            return NotFound();

        _context.Notes.Remove(note);

        await _context.SaveChangesAsync();

        return Ok("Deleted");
    }
}