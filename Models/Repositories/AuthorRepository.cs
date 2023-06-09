using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemo.Models.Repositories
{
    public class AuthorRepository :IBookstoreRepository<Author>
    {
        List<Author> authors;
        public AuthorRepository(){
            authors = new List<Author>(){
                new Author {
                    Id =1,FullName="sccsdcsdds",
                },
                new Author {
                    Id =2,FullName="sccsdcsdds",
                },
            };
        }
        public IList<Author> List(){
            return authors;
        }
        public Author Find(int Id){
            return authors.SingleOrDefault(b => b.Id == Id);
        }
        public void Add(Author entity){
            authors.Add(entity);
        }
        public void Update(int id ,Author entity){
           var author =  Find(id) ;
           author.FullName = entity.FullName;
        }
        public void Delete(int Id){
           authors.Remove(Find(Id));
        }

        public List<Author> Search(string term)
        {
            throw new NotImplementedException();
        }
    }
}