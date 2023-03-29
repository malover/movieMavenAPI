using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Movies
{
	public class List
	{
		public class Query : IRequest<List<MovieDTO>> { }

		public class Handler : IRequestHandler<Query, List<MovieDTO>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;
			public Handler(DataContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}

			public async Task<List<MovieDTO>> Handle(Query request, CancellationToken cancellationToken)
			{
				var movieDTOs = await _context.Movies
					.Include(m => m.ParentMovie)
					.ThenInclude(p => p.RelatedMovies)
					.ProjectTo<MovieDTO>(_mapper.ConfigurationProvider)
					.ToListAsync();
					
				return movieDTOs;
			}
		}
	}
}