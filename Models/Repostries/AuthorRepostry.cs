using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemo.Models.Repostries
{
    public class AuthorRepostry :IauthorstoreRepostry<Author>
    {
        List<Author> authors;
        public AuthorRepostry(){
            authors = new List<Author>(){
                new Author {
                    Id =1,FullName="sccsdcsdds",
                },
                new Author {
                    Id =2,FullName="sccsdcsdds",
                },
            };
        }
        public IList<author> List(){
            return authors;
        }
        public author Find(int Id){
            return authors.SingleOrDefault(b => b.Id == id);
        }
        public void Add(TEntity entity){
            authors.Add(entity);
        }
        public void Update(int id ,TEntity entity){
           var author =  Find(id)
           author.Title = entity.Title;
           author.Descreption = entity.Descreption;
           author.Author = entity.Author;
        }
        public void Delete(int Id){
           authors.Remove(Find(id));
        }
    }
}