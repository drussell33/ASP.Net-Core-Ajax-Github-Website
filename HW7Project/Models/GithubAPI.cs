using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HW7Project.Models
{
    public class GithubAPI
    {

        public string Source { get; set; }
        private readonly IConfiguration _config;

        public GithubAPI(string endpoint, IConfiguration config)
        {
            Source = endpoint;
            _config = config;
        }

        public IEnumerable<User> GetGithubUser()
        {
            string jsonResponse = SendRequest(Source, _config["GITAPI:MySecretToken"], "drussell33");
            Debug.WriteLine(jsonResponse);

            List<User> finaloutput = new List<User>();
            User output = new User();

            JObject geo = JObject.Parse(jsonResponse);

            output.ProfileImageUrl = (string)geo["avatar_url"];
            output.Name = (string)geo["name"];
            output.UserName = (string)geo["login"];
            output.Email = (string)geo["email"];
            output.Company = (string)geo["company"];
            output.Location = (string)geo["location"];
            output.UserPageUrl = (string) geo["html_url"];

            finaloutput.Add(output);
            //Debug.WriteLine();

            return finaloutput;
        }

        public IEnumerable<Repo> GetGithubRepos()
        {
            string jsonResponse = SendRequest(Source, _config["GITAPI:MySecretToken"], "drussell33");
            //Debug.WriteLine(jsonResponse);
            List<Repo> output = new List<Repo>();
            JArray geo = JArray.Parse(jsonResponse);
            foreach (var i in geo)
            {
                string repoName = (string)i["name"];
                string repoOwner = (string)i["owner"]["login"];
                string updatedAtGet = (string)i["updated_at"];

                var timeInDays =  DateTime.Parse(updatedAtGet); 
                Debug.WriteLine(timeInDays);
                DateTime now = DateTime.Now;
                TimeSpan elapsed = now.Subtract(timeInDays);
                double daysAgo = elapsed.TotalDays;
                string updatedAt = "Last updated " + daysAgo.ToString("####") + " days ago";

                string repoOwnerImg = (string)i["owner"]["avatar_url"];
                string repoPageUrl = (string)i["html_url"];

                output.Add(new Repo() { RepoName = repoName, RepoOwner = repoOwner, UpdatedAt = updatedAt, RepoOwnerImg = repoOwnerImg, RepoPageUrl = repoPageUrl});
            }

            return output;
        }

        public IEnumerable<Commit> GetGithubCommits()
        {
            string jsonResponse = SendRequest(Source, _config["GITAPI:MySecretToken"], "drussell33");
            Debug.WriteLine(jsonResponse);
            List<Commit> output = new List<Commit>();
            JArray geo = JArray.Parse(jsonResponse);
            foreach (var i in geo)
            {
                string shortShaHashGet = (string)i["sha"];
                string shortShaHash = shortShaHashGet.Remove(8);
                string timeStamp = (string) i["commit"]["committer"]["date"];
                string committer = (string) i["commit"]["committer"]["name"];
                string commitMessage = (string) i["commit"]["message"];
                string commitPageUrl = (string) i["html_url"];

                output.Add(new Commit() { ShortShaHash = shortShaHash, TimeStamp = timeStamp, Committer = committer, CommitMessage = commitMessage, CommitPageUrl = commitPageUrl} );
            }



            return output;
        }


        private static string SendRequest(string uri, string credentials, string username)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", "token " + credentials);
            request.UserAgent = username;       // Required, see: https://developer.github.com/v3/#user-agent-required
            request.Accept = "application/json";

            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }

	}
}
