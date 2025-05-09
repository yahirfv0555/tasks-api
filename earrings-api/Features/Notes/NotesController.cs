using earrings_api.Features.Notes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace earrings_api.Features.Notes
{
    [AllowAnonymous]
    [EnableCors("AllowAnyOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NotesController : Controller
    {
        private readonly NotesRepository notesRepository;
        public NotesController()
        {
            notesRepository = new NotesRepository();
        }

        [HttpGet]
        public async Task<ActionResult<List<NoteDto>>> GetNotes() 
        {
            List<NoteDto> notes = await notesRepository.GetNotes();

            return Ok(notes);
        }

    }
}
