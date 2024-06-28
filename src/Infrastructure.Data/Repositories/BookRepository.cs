using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Data.Contexts;

namespace Infrastructure.Data.Repositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(Context context) : base(context)
    { }
}
