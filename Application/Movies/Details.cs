using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Movies
{
    public class Details
	{
		public class Query : IRequest<MovieDTO>
		{
			public string Id { get; set; }
		}

		public class Handler : IRequestHandler<Query, MovieDTO>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;
			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<MovieDTO> Handle(Query request, CancellationToken cancellationToken)
			{
                var movieDTO = await _context.Movies
        			.Where(m => m.Id == request.Id)
        			.Include(m => m.ParentMovie)
        			.ThenInclude(p => p.RelatedMovies)
        			.ProjectTo<MovieDTO>(_mapper.ConfigurationProvider)
        			.FirstOrDefaultAsync();

                return movieDTO;
			}
		}
	}
}