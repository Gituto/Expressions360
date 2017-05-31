using Expressions360.Models;
using Expressions360.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expressions360.Controllers
{
    public class ArticlesController : Controller
    {
        //Searching And Paging
        // GET: Articles
        public ActionResult Index(string searchString, string currentFilter, int? page)
        {
            ArticlesRepository ArticlesRepo = new ArticlesRepository();
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.currentFilter = searchString;
            var articles = from posts in ArticlesRepo.GetAllArticles() select posts;
            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(search => search.Title.Contains(searchString));
            }

            int pageSize = 3;
            int pageNumber = (page?? 1);
            return View(articles.ToPagedList(pageNumber,pageSize));
            //return View(ArticlesRepo.GetAllArticles());
            
        }
      

        // GET: Articles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        [HttpPost]
        public ActionResult Create(ArticlesModel article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ArticlesRepository ArticleRepo = new ArticlesRepository();
                    ArticleRepo.Add(article);
                    ViewBag.Message="Your Article has been published";

                }
                // TODO: Add insert logic here

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
            
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int Id)
        {
            ArticlesRepository ArticlesRepo = new ArticlesRepository();

            return View(ArticlesRepo.GetAllArticles().Find(article=>article.Id==Id));
        }

        // POST: Articles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ArticlesModel Article)
        {
            try
            {
                // TODO: Add update logic here
                ArticlesRepository ArticleRepo = new ArticlesRepository();
                ArticleRepo.Update(Article);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      
        // POST: Articles/Delete/5
        
        public ActionResult Delete(int Id)
        {
            try
            {
                // TODO: Add delete logic here
                ArticlesRepository ArticlesRepo = new ArticlesRepository();
                if (ArticlesRepo.Remove(Id))
                {
                    ViewBag.AlertMsg = "Article deleted succesfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
