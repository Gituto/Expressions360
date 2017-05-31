using Expressions360.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Expressions360.Models;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace Expressions360.Repositories
{
    public class ArticlesRepository : IArticlesInterface
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Expressions360"].ToString());
        public string Add(ArticlesModel article)
        {
           string query="INSERT INTO Articles(Title,Body,Image,Attachment)"
                +"VALUES(@Title,@Body,@Image,@Attachment)";
            con.Execute(query,new { article.Title, article.Body, article.Image, article.Attachment } );
            string result = "Article Added";
            return result;
        }

        public ArticlesModel ArticleDetails(int Id)
        {
            throw new NotImplementedException();
        }

        public ArticlesModel Find(int Id)
        {
            throw new NotImplementedException();
        }
        public List<ArticlesModel> UserArticles()
        {
            string query = "SELECT Id,Title,Body,Image,Attachment FROM Articles WHERE Username=@Username";
            var result = con.Query<ArticlesModel>(query);
            return result.ToList();
        }

        public List<ArticlesModel> GetAllArticles()
        {
            string query = "Select Id,Title,Body,Image,Attachment From Articles";
            var result = con.Query<ArticlesModel>(query);
            return result.ToList();
        }

        public bool Remove(int Id)
        {
            try
            {
                var Sqlquery = "DELETE FROM Articles WHERE Id=@Id";
                this.con.Execute(Sqlquery, new { Id });
                return true;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ArticlesModel Update(ArticlesModel article)
        {
            var query = "UPDATE Articles SET Title=@Title,Body=@Body,Image=@Image,Attachment=@Attachment WHERE Id=@Id";
            this.con.Execute(query, article);
            return article;
        }
    }
}