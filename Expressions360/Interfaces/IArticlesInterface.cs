using Expressions360.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions360.Interfaces
{
    interface IArticlesInterface
    {
        ArticlesModel Update(ArticlesModel article);
        string Add(ArticlesModel article);
        bool Remove(int Id);
        List<ArticlesModel> GetAllArticles();
        ArticlesModel Find(int Id);
        ArticlesModel ArticleDetails(int Id);
    }
}
