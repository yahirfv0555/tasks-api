using Dapper;
using earrings_api.Features.Notes.Models;

namespace earrings_api.Features.Notes
{
    public class NotesDB
    {
        #region Nombres procedures

        internal const string spGetNotes = "SP_GET_NOTES";
        internal const string spCreateNote = "SP_CREATE_NOTE";
        internal const string spUpdateNote = "SP_UPDATE_NOTE";
        internal const string spDeleteNote = "SP_DELETE_NOTE";

        #endregion

        #region Parámetros

        internal static DynamicParameters GetNotesParams(NoteFilter filter)
        {
            DynamicParameters parameters = new(new
            {
                @p_note_id = filter.NoteId,
                @p_active = filter.Active,
                @p_title = filter.Title,
                @p_user_id = filter.UserId
            });

            return parameters;
        }

        internal static DynamicParameters CreateNoteParams(NoteDao note)
        {
            DynamicParameters parameters = new(new
            {
                @p_description = note.Description,
                @p_title = note.Title,
                @p_user_id = note.UserId,
                @p_created_by = note.ModificatedBy,
            });

            return parameters;
        }

        internal static DynamicParameters UpdateNoteParams(NoteDao note)
        {
            DynamicParameters parameters = new(new
            {
                @p_note_id = note.NoteId,
                @p_active = note.Active,
                @p_description = note.Description,
                @p_title = note.Title,
                @p_user_id = note.UserId,
                @p_modificated_by = note.ModificatedBy,
            });

            return parameters;
        }

        internal static DynamicParameters DeleteNoteParams(NoteFilter note)
        {
            DynamicParameters parameters = new(new
            {
                @p_note_id = note.NoteId
            });

            return parameters;
        }

        #endregion
    }
}
