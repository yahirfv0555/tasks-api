using earrings_api.Features.Notes.Models;
using EarringsApi.Handlers;
using EarringsApi.Models;

namespace earrings_api.Features.Notes
{
    public class NotesRepository
    {
        public NotesRepository() { }

        internal async Task<List<NoteDto>> GetNotes(NoteFilter filter)
        {
            var spParams = NotesDB.GetNotesParams(filter);

            try
            {
                List<NoteDto> notes = await DapperHandler.GetFromProcedure<NoteDto>(NotesDB.spGetNotes, spParams);

                return notes;
            }
            catch (Exception)
            {

                return [];
            }
        }

        internal async Task<Execution> CreateNote(NoteDao note)
        {
            var spParams = NotesDB.CreateNoteParams(note);
            try
            {
                Execution execution = await DapperHandler.SetFromProcedure(NotesDB.spCreateNote, spParams);

                return execution;
            } 
            catch (Exception ex)
            {
                return new()
                {
                    Successful = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
