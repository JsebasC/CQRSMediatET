using CQRSMediatREF.Db.Model;
using MediatR;

namespace CQRSMediatREF.Db.Command
{
    public class GetProduct
    {
        //Command : Traer lo que necesitamos para hacer la insercion
        public record ById(int Id):IRequest<Response>; //un record para que no se puedan actualizar los valroes


        //Handler : Logica insercion
        public class GetByIdHandler : IRequestHandler<ById, Response>
        {
            private readonly MainDBContext _dbContext;
            public GetByIdHandler(MainDBContext mainDBContext)
            {
                _dbContext = mainDBContext;
            }

            public async Task<Response> Handle(ById request, CancellationToken cancellationToken)
            {
                var product = _dbContext.Products.Find(request.Id);               
                return new Response(product);
            }
        }

        //Podemos agregar mas handler
        public record GetByValue(decimal Value) : IRequest<Response>;
        public class GetValue : IRequestHandler<GetByValue, Response>
        {
            private readonly MainDBContext _dbContext;
            public GetValue(MainDBContext mainDBContext) 
            {
                _dbContext = mainDBContext;
            }
            public async Task<Response> Handle(GetByValue request, CancellationToken cancellationToken)
            {
                var product = _dbContext.Products.Where(x=> x.Value == request.Value).FirstOrDefault();
                return new Response(product);
            }
        }



        //Response : Aca lo que nos va a devolver
        public record Response(Product Product);
    }
}
