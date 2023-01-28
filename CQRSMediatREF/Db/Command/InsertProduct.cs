using CQRSMediatREF.Db.Model;
using MediatR;

namespace CQRSMediatREF.Db.Command
{
    public class InsertProduct
    {
        //Command : Traer lo que necesitamos para hacer la insercion
        public record Command(Product product):IRequest<Response>; //un record para que no se puedan actualizar los valroes


        //Handler : Logica insercion
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly MainDBContext _dbContext;
            public Handler(MainDBContext mainDBContext)
            {
                _dbContext = mainDBContext;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                _dbContext.Products.Add(request.product);
                _dbContext.SaveChanges();
                return new Response(request.product);
            }
        }



        //Response : Aca lo que nos va a devolver
        public record Response(Product Product);
    }
}
