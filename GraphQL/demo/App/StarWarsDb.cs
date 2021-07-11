using System;
using System.Collections;
using System.Collections.Generic;


namespace App
{
    public class StarWarsDB
    {


        public static IEnumerable<Jedi> GetJedis()
        {
            return new List<Jedi>()
        {
            new Jedi(){Id = 1, name="Luke", side="Light"},
            new Jedi(){ Id = 2, name="Yoda", side="Light"},
            new Jedi(){Id=3, name="Darth Vader", side="Dark"}
        
        };
    }
}
}