using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizEngine.Data.Entities;

namespace QuizEngine.Data.Repositories
{
    public interface IPlayerRepository
    {
        Player Get(string playerId);
    }
}
