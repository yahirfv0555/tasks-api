using earrings_api.Features.Notes.Models;
using earrings_api.Features.Notes;
using EarringsApi.Features.Draws.Models;
using EarringsApi.Handlers;
using EarringsApi.Models;
using System.Security.Cryptography.Xml;

namespace EarringsApi.Features.Draws
{
    public class DrawsRepository
    {

        private readonly DapperHandler dapperHandler;

        public DrawsRepository()
        {
            dapperHandler = new();
        }

        internal async Task<List<DrawDto>> GetDraws(DrawFilter filter)
        {
            var spParams = DrawsDB.GetDrawsParams(filter);

            try
            {
                List<DrawDto> draws = await dapperHandler.GetFromProcedure<DrawDto>(DrawsDB.spGetDraws, spParams);

                return draws;
            }
            catch (Exception)
            {
                return [];
            }
        }

        internal async Task<Execution> CreateDraw(DrawDao draw)
        {
            var spParams = DrawsDB.CreateDrawParams(draw);

            try
            {
                Execution execution = await dapperHandler.SetFromProcedure(DrawsDB.spCreateDraw, spParams);

                return execution;
            }
            catch (Exception ex)
            {
                return new()
                {
                    Message = ex.Message,
                    Successful = false
                };
            }
        }

        internal async Task<Execution> UpdateDraw(DrawDao draw)
        {
            var spParams = DrawsDB.UpdateDrawParams(draw);

            try
            {
                Execution execution = await dapperHandler.SetFromProcedure(DrawsDB.spUpdateDraw, spParams);

                return execution;
            }
            catch (Exception ex)
            {
                return new()
                {
                    Message = ex.Message,
                    Successful = false
                };
            }
        }

        internal async Task<Execution> DeleteDraw(DrawFilter filter)
        {
            var spParams = DrawsDB.DeleteDrawParams(filter);

            try
            {
                Execution execution = await dapperHandler.SetFromProcedure(DrawsDB.spDeleteDraw, spParams);

                return execution;
            }
            catch (Exception ex)
            {
                return new()
                {
                    Message = ex.Message,
                    Successful = false
                };
            }
        }
    }
}
