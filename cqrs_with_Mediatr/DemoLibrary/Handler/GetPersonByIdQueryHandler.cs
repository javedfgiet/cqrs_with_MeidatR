using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Handler
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
    {
        private readonly IMediator _mediator;

        public GetPersonByIdQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        

        public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var result=await _mediator.Send(new GetPersonListQuery());
            var output= result.FirstOrDefault(x=>x.Id==request.Id);
            return output;
            
        }
    }
}
