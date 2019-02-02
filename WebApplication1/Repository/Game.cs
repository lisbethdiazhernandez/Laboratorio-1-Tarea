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
    public class Game : IGame
    {
        List<GameModel> listgames = new List<GameModel>();
               
        public Game()
        {

            listgames.Add(new GameModel()
            {
                Id = 122,
                Name = "Malu",
                Puntuation = 10,

            });
            GameModel est2 = new GameModel()
            {
                Id = 421,
                Name = "Willy",
                Puntuation = 98,
            };
            listgames.Add(est2);
            GameModel est3 = new GameModel();
            est3.Id = 1218;
            est3.Name = "Juan";
            est3.Puntuation = 66;
            listgames.Add(est3);
        }

        public List<GameModel> GetGames()
        {
            return listgames;
        }

        public GameModel GetGame(int id)
        {
            GameModel games =
                listgames.FirstOrDefault(x => x.Id == id);
            return games;
        }
        public GameModel AddGame(IFormCollection collection)
        {
            GameModel games = new GameModel()
            {
                Id = Convert.ToInt16(collection["Id"]),
                Name = collection["Name"].ToString(),
                Puntuation = Convert.ToInt16(collection["Puntuation"])
            };
            listgames.Add(games);
            return games;
        }
    }
}
