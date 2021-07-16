using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRestFull.Models
{
    public class PersonajesModel
    {
        private int id { set; get; }
        private int? gms_id { set; get; }
        private string name { set; get; }

        public PersonajesModel()
        {
        }
        public  PersonajesModel(int id)
        {
            this.id = id;
        }

        public PersonajesModel(int gms_id ,string name)
        {
            this.gms_id = gms_id;
            this.name = name;
        } 
        public List<PersonajesModel> GetPersonajes()
        {
            using(DataBaseEntities db = new DataBaseEntities()) {
                return (from pm in db.Personajes_tb
                        select new PersonajesModel()
                        {
                            id = pm.rpt_id,
                            gms_id = pm.gms_id,
                            name = pm.rpt_nombre

                        }).ToList();
                    }
        }

        public void InsertPersonajes()
        {
            using(DataBaseEntities db = new DataBaseEntities())
            {
                db.Personajes_tb.Add(new Personajes_tb() { gms_id = this.gms_id, rpt_nombre = this.name });
                db.SaveChanges();
            }
        }

        public void UpdatePersonajes()
        {
            using (DataBaseEntities db = new DataBaseEntities())
            {
                var personaje = (from pm in db.Personajes_tb
                                 where pm.rpt_id == this.id
                                 select pm ).FirstOrDefault();

                personaje.gms_id = this.gms_id;
                personaje.rpt_nombre = this.name;
                db.SaveChanges();
            }
            
        }

        public void DeletePersonajes()
        {
            using (DataBaseEntities db = new DataBaseEntities())
            {
                var personaje = (from pm in db.Personajes_tb
                                 where pm.rpt_id == this.id
                                 select pm).FirstOrDefault();

                db.Personajes_tb.Remove(personaje);
                db.SaveChanges();
            }
            }
    }
}