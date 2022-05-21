using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RockStars.Api.Controllers.v1.Songs.Requests;
using RockStars.ApiFramework.Tools;
using RockStars.Application.Songs.Command.AddSong;
using RockStars.Application.Songs.Query.GetSongById;
using RockStars.Application.Songs.Query.ReadSongFromRedis;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace RockStars.Api.Controllers.v1.Songs
{
    [ApiVersion("1")]
    public class SongController : BaseControllerV1
    {
        public SongController(ILogger<SongController> logger,
                                 IMediator mediator,
                                 IMapper mapper)
            : base(logger, mediator, mapper)
        { }

        [HttpGet]
        [SwaggerOperation("get a Song by id")]
        public async Task<ApiResult<SongQueryModel>> GetByIdAsync([FromQuery] int songId)
        {
            var result = await _mediator.Send(new GetSongByIdQuery() { SongId = songId });
            return new ApiResult<SongQueryModel>(result);
        }

        [HttpPost]
        [SwaggerOperation("add a Song")]
        public async Task<ApiResult<int>> AddAsync(AddSongRequest request)
        {
            var command = _mapper.Map<AddSongRequest, AddSongCommand>(request);

            var result = await _mediator.Send(command);

            return new ApiResult<int>(result);
        }

        [HttpDelete]
        [SwaggerOperation("Delete a Song")]
        public async Task<ApiResult<int>> DeleteAsync(DeleteSongRequest request)
        {
            var command = _mapper.Map<DeleteSongRequest, DeleteSongCommand>(request);

            var result = await _mediator.Send(command);

            return new ApiResult<int>(result);
        }

        [HttpGet("cache-redis")]
        [SwaggerOperation("get a Song from cache. this is a example for how to use cache")]
        public async Task<ApiResult<ReadSongFromRedisResponse>> ReadFromCacheAsync([FromQuery] int songId)
        {
            var result = await _mediator.Send(new ReadSongFromRedisQuery(songId));
            return new ApiResult<ReadSongFromRedisResponse>(result);
        }
    }
}
