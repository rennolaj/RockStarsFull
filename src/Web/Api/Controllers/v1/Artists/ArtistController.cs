using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RockStars.Api.Controllers.v1.Artists.Requests;
using RockStars.ApiFramework.Tools;
using RockStars.Application.Artists.Command.AddArtist;
using RockStars.Application.Artists.Query.GetArtistById;
using RockStars.Application.Artists.Query.ReadArtistFromRedis;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace RockStars.Api.Controllers.v1.Artists
{
    [ApiVersion("1")]
    public class ArtistController : BaseControllerV1
    {
        public ArtistController(ILogger<ArtistController> logger,
                                 IMediator mediator,
                                 IMapper mapper)
            : base(logger, mediator, mapper)
        { }

        [HttpGet]
        [SwaggerOperation("get a Artist by id")]
        public async Task<ApiResult<ArtistQueryModel>> GetByIdAsync([FromQuery] int artistId)
        {
            var result = await _mediator.Send(new GetArtistByIdQuery() { ArtistId = artistId });
            return new ApiResult<ArtistQueryModel>(result);
        }

        [HttpPost]
        [SwaggerOperation("add a Artist")]
        public async Task<ApiResult<int>> AddAsync(AddArtistRequest request)
        {
            var command = _mapper.Map<AddArtistRequest, AddArtistCommand>(request);

            var result = await _mediator.Send(command);

            return new ApiResult<int>(result);
        }

        [HttpGet("cache-redis")]
        [SwaggerOperation("get a Artist from cache. this is a example for how to use cache")]
        public async Task<ApiResult<ReadArtistFromRedisResponse>> ReadFromCacheAsync([FromQuery] int artistId)
        {
            var result = await _mediator.Send(new ReadArtistFromRedisQuery(artistId));
            return new ApiResult<ReadArtistFromRedisResponse>(result);
        }
    }
}
