using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW7Project.Models;
using Microsoft.Extensions.Configuration;

namespace HW7Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpPost]
        public IActionResult GithubUserPage()
        { 
            GithubAPI userSource = new GithubAPI("https://api.github.com/users/drussell33", _config);
            IEnumerable<User> user = userSource.GetGithubUser();
            return Json(user);
        }

       
        [HttpPost]
        public IActionResult GithutReposPage()
        {
            GithubAPI userSource = new GithubAPI("https://api.github.com/users/drussell33/repos", _config);
            IEnumerable<Repo> repos = userSource.GetGithubRepos();
            return Json(repos);
        }


        public IActionResult GithutCommitsPage(string user, string repo)
        {
            Debug.WriteLine($"{user}, {repo}");
            string endpoint = "https://api.github.com/repos/" + $"{user}" + "/" + $"{repo}" + "/commits";
            GithubAPI userSource = new GithubAPI(endpoint, _config);
            IEnumerable<Commit> commits = userSource.GetGithubCommits();
            return Json(commits);
        }



        public IActionResult Index()
        {
            //string secret = _config["GITAPI:MySecretToken"];
            //Debug.WriteLine("secret " + secret); 
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
