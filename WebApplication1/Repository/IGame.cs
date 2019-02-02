using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Game;

namespace WebApplication1.Game
{
    public interface IGame
    {
        List<GameModel> GetGames();
        GameModel GetGame(int id);
       // GameModel EditGame(int id, string name, int puntuation);
        GameModel AddGame(IFormCollection collection);
        //GameModel SearchGame(int id);
    }
}
