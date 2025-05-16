using Dapper;
using earrings_api.Features.Notes.Models;

namespace earrings_api.Features.Notes
{
    public class NotesDB
    {
        #region Nombres procedures

        internal const string spGetNotes = "SP_GET_NOTES";
        internal const string spCreateNote = "SP_CREATE_NOTE";

        #endregion

        #region Parámetros

        internal static DynamicParameters GetNotesParams(NoteFilter filter)
        {
            DynamicParameters parameters = new(new
            {
                @p_note_id = filter.NoteId,
                @p_active = filter.Active,
                @p_user_id = filter.UserId
            });

            return parameters;
        }

        internal static DynamicParameters CreateNoteParams(NoteDao note)
        {
            DynamicParameters parameters = new(new
            {
                @p_value = note.Value,
                @p_created_by = note.ModificatedBy,
                @p_title = note.Title,
                @p_user_id = note.UserId
            });

            return parameters;
        }

        #endregion
    }
}
