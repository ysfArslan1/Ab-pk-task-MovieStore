using AutoMapper;
using Ab_pk_task_MovieStore.Entities;
using Ab_pk_task_MovieStore.Aplication.GenresOperations.Queries.GetGenres;
using Ab_pk_task_MovieStore.Aplication.GenresOperations.Queries.GetGenreDetail;
using Ab_pk_task_MovieStore.Aplication.GenresOperations.Commands.CreateGenre;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Queries.GetActors;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Queries.GetDirectors;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Queries.GetMovies;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Queries.GetMovieActors;
using Ab_pk_task_MovieStore.Aplication.CustomersOperations.Queries.GetCustomers;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Queries.GetOrders;
using Ab_pk_task_MovieStore.Aplication.ActorsOperations.Queries.GetActorDetail;
using Ab_pk_task_MovieStore.Aplication.DirectorsOperations.Queries.GetDirectorDetail;
using Ab_pk_task_MovieStore.Aplication.CustomersOperations.Queries.GetCustomerDetail;
using Ab_pk_task_MovieStore.Aplication.MoviesOperations.Queries.GetMovieDetail;
using Ab_pk_task_MovieStore.Aplication.MovieActorsOperations.Queries.GetMovieActorDetail;
using Ab_pk_task_MovieStore.Aplication.OrdersOperations.Queries.GetOrderDetail;


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
            CreateMap<Actor, ActorDetailViewModel>();


            CreateMap<Director, DirectorViewModel>();
            CreateMap<Director, DirectorDetailViewModel>();

            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Customer, CustomerDetailViewModel>();

            CreateMap<Movie, MovieViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name))
                .ForMember(dest => dest.ActorIds, opt => opt.MapFrom(src => src.Actors.Select(movieActor=> movieActor.Id)));
            CreateMap<Movie, MovieDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(movieActor => movieActor.Id)));


            CreateMap<MovieActor, MovieActorViewModel>().ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.Actor, opt => opt.MapFrom(src => src.Actor.Name));
            CreateMap<MovieActor, MovieActorDetailViewModel>().ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.Actor, opt => opt.MapFrom(src => src.Actor.Name));


            CreateMap<Order, OrderViewModel>().ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.Custemer, opt => opt.MapFrom(src => src.Custemer.Name));
            CreateMap<Order, OrderDetailViewModel>().ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.Custemer, opt => opt.MapFrom(src => src.Custemer.Name));
        }
    }
}
