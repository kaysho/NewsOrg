using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsOrg.Models;
using SQLite;

namespace NewsOrg.Database
{
    //Object that handles database operation
    public class NewsOrgDatabase
    {
        readonly SQLiteAsyncConnection database;

        public NewsOrgDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Article>().Wait();
            //database.CreateTablesAsync<SavedArticle>().Wait();
        }


        //get all articles in database
        public Task<List<Article>> GetArticlesAsync()
        {
            return database.Table<Article>().ToListAsync();
        }

        //get particular article in database
        public Task<Article> GetArticleAsync(int id)
        {
            return database.Table<Article>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        //save or update particular article in database
        public Task<int> SaveArticleAsync(Article article)
        {
            if (article.Id != 0)
            {
                return database.UpdateAsync(article);
            }
            else
            {
                return database.InsertAsync(article);
            }
        }

        //delete particlar article in database
        public Task<int> DeleteArticleAsync(Article article)
        {
            return database.DeleteAsync(article);
        }
    }
}
