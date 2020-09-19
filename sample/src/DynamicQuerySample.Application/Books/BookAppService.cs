using System;
using System.Linq;
using DynamicQuerySample.Books.Dtos;
using Volo.Abp.Application.Services;

namespace DynamicQuerySample.Books
{
    public class BookAppService : CrudAppService<Book, BookDto, Guid, GetListInput, CreateUpdateBookDto, CreateUpdateBookDto>,
        IBookAppService
    {
        private readonly IBookRepository _repository;
        
        public BookAppService(IBookRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override IQueryable<Book> CreateFilteredQuery(GetListInput input)
        {
            return _repository.ExecuteDynamicQuery(input.FilterGroup);
        }
    }
}