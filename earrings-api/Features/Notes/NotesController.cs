using earrings_api.Features.Notes.Models;
using EarringsApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace earrings_api.Features.Notes
{
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
        public async Task<ActionResult<List<NoteDto>>> GetNotes([FromQuery] NoteFilter filter) 
        {
            List<NoteDto> notes = await notesRepository.GetNotes(filter);

            return Ok(notes);
        }

        [HttpPost]
        public async Task<ActionResult<Execution>> CreateNote([FromBody] NoteDao note)
        {
            Execution execution = await notesRepository.CreateNote(note);

            return execution;
        }

    }
}
