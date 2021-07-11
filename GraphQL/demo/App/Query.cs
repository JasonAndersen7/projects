using System;
using GraphQL;
using GraphQL.Types;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public class Query
    {

        [GraphQLMetadata("jedis")]
        public IEnumerable<Jedi> GetJedis()
        {
            return StarWarsDB.GetJedis();
        }

        [GraphQLMetadata("hello")]
        public string GetHello()
        {
            return "Hello Query class";
        }


        [GraphQLMetadata("jedi")]
        public Jedi GetJedi(int id)
        {
            return StarWarsDB.GetJedis().SingleOrDefault(j => j.Id == id);
        }

    }
}