using AutoMapper;
using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.Aplication.GenresOperations.Queries.GetGenres;
using Ab_pk_task_MovieStore.Aplication.GenresOperations.Queries.GetGenreDetail;
using Ab_pk_task_MovieStore.Aplication.GenresOperations.Commands.CreateGenre;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Queries.GetActors;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Queries.GetDirectors;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Queries.GetMovies;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Queries.GetMovieActors;
using Ab_pk_task_MovieStore.Aplication.CustemersOperations.Queries.GetCustemers;


namespace Ab_pk_task_MovieStore.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {


            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateGenreModel, Genre>();


            CreateMap<Actor, ActorViewModel>();


            CreateMap<Director, DirectorViewModel>();

            CreateMap<Custemer, CustemerViewModel>();

            CreateMap<Movie, MovieViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(movieActor=> movieActor.Id)));


            CreateMap<MovieActor, MovieActorViewModel>().ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.Actor, opt => opt.MapFrom(src => src.Actor.Name));
        }
    }
}
