using earrings_api.Features.Notes.Models;
using EarringsApi.Handlers;
using EarringsApi.Models;

namespace earrings_api.Features.Notes
{
    public class NotesRepository
    {
        private readonly DapperHandler dapperHandler;
        public NotesRepository() 
        {
            dapperHandler = new();
        }

        internal async Task<List<NoteDto>> GetNotes(NoteFilter filter)
        {
            var spParams = NotesDB.GetNotesParams(filter);

            try
            {
                List<NoteDto> notes = await dapperHandler.GetFromProcedure<NoteDto>(NotesDB.spGetNotes, spParams);

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
                Execution execution = await dapperHandler.SetFromProcedure(NotesDB.spCreateNote, spParams);

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

        internal async Task<Execution> UpdateNote(NoteDao note)
        {
            var spParams = NotesDB.UpdateNoteParams(note);
            try
            {
                Execution execution = await dapperHandler.SetFromProcedure(NotesDB.spUpdateNote, spParams);

                return execution;
            }
            catch(Exception ex)
            {
                return new()
                {
                    Successful = false,
                    Message = ex.Message,
                };
            }
        }

        internal async Task<Execution> DeleteNote(NoteFilter filter)
        {
            var spParams = NotesDB.DeleteNoteParams(filter);
            try
            {
                Execution execution = await dapperHandler.SetFromProcedure(NotesDB.spDeleteNote, spParams);

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
