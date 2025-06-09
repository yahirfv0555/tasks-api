using Dapper;
using EarringsApi.Features.Draws.Models;

namespace EarringsApi.Features.Draws
{
    public class DrawsDB
    {
        #region Nombres procedures
        
        public const string spGetDraws = "SP_GET_DRAWS";
        public const string spCreateDraw = "SP_CREATE_DRAW";
        public const string spUpdateDraw = "SP_UPDATE_DRAW";
        public const string spDeleteDraw = "SP_DELETE_DRAW";
        
        #endregion

        #region Parámetros

        internal static DynamicParameters GetDrawsParams(DrawFilter filter)
        {
            DynamicParameters parameters = new(new
            {
                @p_draw_id = filter.DrawId,
                @p_active = filter.Active,
                @p_title = filter.Title,
                @p_user_id = filter.UserId,
                @p_tags = filter.Tags
            });

            return parameters;
        }

        internal static DynamicParameters CreateDrawParams(DrawDao draw)
        {
            DynamicParameters parameters = new(new
            {
                @p_image = draw.Image,
                @p_title = draw.Title,
                @p_user_id = draw.UserId,
                @p_tag = draw.Tag,
                @p_created_by = draw.ModificatedBy
            });

            return parameters;
        }

        internal static DynamicParameters UpdateDrawParams(DrawDao draw)
        {
            DynamicParameters parameters = new(new
            {
                @p_draw_id = draw.DrawId,
                @p_active = draw.Active,
                @p_image = draw.Image,
                @p_title = draw.Title,
                @p_user_id = draw.UserId,
                @p_tag = draw.Tag,
                @p_modificated_by = draw.ModificatedBy
            });

            return parameters;
        }

        internal static DynamicParameters DeleteDrawParams(DrawFilter filter)
        {
            DynamicParameters parameters = new(new
            {
                @p_draw_id = filter.DrawId
            });

            return parameters;
        }

        #endregion
    }
}


