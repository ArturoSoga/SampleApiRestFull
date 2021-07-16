using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRestFull.Models
{
    public class JuegosModel
    {
        public int id { set; get; }
        public string name { set; get; }


        public JuegosModel(string name)
        {
            this.name = name;
        }
        public JuegosModel(int id)
        {
            this.id = id;
        }
        public JuegosModel(int id,string name)
        {
            this.id = id;
            this.name = name;
        }
        public JuegosModel(){}

        public List<JuegosModel> GetJuegos()
        {
            using(DataBaseEntities db = new DataBaseEntities())
            {
                return (from gms in db.Juegos_tb 
                        select new JuegosModel() { 

                            id = gms.gms_id,
                            name = gms.gms_nombre

                        }).ToList();
            }
        }

        public void InsertJuegos()
        {
            using (DataBaseEntities db = new DataBaseEntities())
            {
                db.Juegos_tb.Add(new Juegos_tb() {gms_nombre = this.name });
                db.SaveChanges();
            }
        }

        public void UpdateJuegos()
        {
            using (DataBaseEntities db = new DataBaseEntities())
            {
                var Game = (from gm in db.Juegos_tb
                            where gm.gms_id == this.id
                            select gm).FirstOrDefault();


                Game.gms_nombre = this.name;

                db.SaveChanges();
            }
        }

        public void DeleteJuegos()
        {
            using (DataBaseEntities db = new DataBaseEntities())
            {
                var Game = (from gm in db.Juegos_tb
                            where gm.gms_id == this.id
                            select gm).FirstOrDefault();

                db.Juegos_tb.Remove(Game);
                db.SaveChanges();
            }
        }

    }
}