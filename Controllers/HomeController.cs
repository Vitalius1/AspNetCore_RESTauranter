using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RESTauranter.Models;
using System.Linq;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private ReviewContext _context;

        public HomeController(ReviewContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        [Route("post")]
        public IActionResult Post(Review newReview)
        {
            if(ModelState.IsValid)
            {
                if(newReview.DateVisited > DateTime.Today)
                {
                    ViewBag.DateError = "The Date can not be a future date.";
                    return View("index");
                }
                _context.Add(newReview);
                _context.SaveChanges();
                return RedirectToAction("Show");
            }
            return View("index");
        }


        [HttpGet]
        [Route("reviews")]
        public IActionResult Show()
        {
            List<Review> Result = _context.Reviews.OrderByDescending(Review => Review.DateVisited).ToList();
            foreach(Review rev in Result){
                System.Console.WriteLine(rev.ResName);
            }
            ViewBag.Reviews = Result;
            return View("reviews");
        }
    }
}
