using System.Collections.Generic;
using System.Linq;
using CS321_W4D1_BookAPI.Core.Models;

namespace CS321_W4D1_BookAPI.Core.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly IAuthorRepository _authorRepo;

        public AuthorService(IAuthorRepository authorRepo)
        {
            // TODO: keep a reference to the BookContext in _bookContext
            _authorRepo = authorRepo;
        }

        public Author Add(Author author)
        {
            // TODO: implement add
            _authorRepo.Add(author);
            return author;
        }

        public Author Get(int id)
        {
            // TODO: return the specified Author using Find()
            return _authorRepo.Get(id);
        }

        public IEnumerable<Author> GetAll()
        {
            // TODO: return all Authors using ToList()
            return _authorRepo.GetAll();
        }

        public Author Update(Author updatedAuthor)
        {
            // get the ToDo object in the current list with this id 
            var currentAuthor = _authorRepo.Get(updatedAuthor.Id);

            // return null if todo to update isn't found
            if (currentAuthor == null) return null;

            // update the todo and save
            _authorRepo.Update(currentAuthor);
            return currentAuthor;
        }

        public void Remove(Author author)
        {
            // TODO: remove the author
            _authorRepo.Remove(author);
        }

    }
}
