using CoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Repository.IRepository
{
    public interface IEntertainmentRepo
    {
        IEnumerable<Entertainment> GetEntertainment();
    }
}
