using MediatR;

namespace RockStars.Application.Products.Query.ReadProductFromRedis
{
    public class ReadProductFromRedisQuery : IRequest<ReadProductFromRedisResponse>
    {
        public ReadProductFromRedisQuery(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; private set; }
    }
}
