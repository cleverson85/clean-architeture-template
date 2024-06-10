using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Data.Contexts;

namespace Infrastructure.Data.Repositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(Context context) : base(context)
    { }
}
