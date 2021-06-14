using CoreAPI.Models;
using CoreAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Options;
using System.Runtime.InteropServices;

namespace CoreAPI.Repository
{
    public class EntertainmentRepo : IEntertainmentRepo
    {
        public IEnumerable<Entertainment> GetEntertainment()
        {
            var client = new RestClient($"https://opentdb.com/api.php?amount=5&category=11&difficulty=medium&type=multiple");
            var request = new RestRequest(Method.GET);
            IRestResponse response =  client.Execute(request);
            if (response.IsSuccessful)
            {

                //dynamic content = JsonConvert.DeserializeObject(response.Content);

                //var str = content.results;


                //List<Entertainment> lstEnt = new List<Entertainment>();
                //Entertainment ent = new Entertainment();
                //foreach(var items in str)
                //{
                //    var cat = items;
                //    var ques = items[3];
                //    var corr = items[4];
                //    lstEnt.Add(ent);
                //}

                var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                var results = content.SelectTokens("results[*]")
                    .Select(res => new Entertainment
                    {
                        Category = (string)res["category"],
                        Question = (string)res["question"],
                        CorrectAnswer = (string)res["correct_answer"],
                        TotalOptions=res["incorrect_answers"]?.ToObject<string[]>()
                        
                    }).ToList();

                //var optionResult = content.SelectTokens("results[incorrect_answers]")
                //                .Select(resopt => new TotalOptions
                //                {
                //                    option1 = resopt["incorrect_answers"]?.ToObject<string>()
                //                }).ToList();


                return results;
            }

            Console.WriteLine(response.Content);

            return null;
        }
    }
}
