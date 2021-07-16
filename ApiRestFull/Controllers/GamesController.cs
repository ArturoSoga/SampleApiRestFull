using ApiRestFull.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ApiRestFull.Controllers
{
    public class GamesController : ApiController
    {
        

        // GET: Games
        public object Get()
        {
            try { 
            return new JuegosModel().GetJuegos();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        // POST: Games
        public string Post(JuegosModel Game)
        {
            try {

                new JuegosModel(Game.name).InsertJuegos();
                return "200";

            }catch(Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        // PUT: Games
        public object Put(JuegosModel Game)
        {
            try
            {

                new JuegosModel(Game.id,Game.name).UpdateJuegos();
                return "200";

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        // DELETE: Games
        public object Delete(JuegosModel Game)
        {
            try
            {

                new JuegosModel(Game.id).DeleteJuegos();
                return "200";

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}