using System;
using GraphQL;
using GraphQL.Types;



namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int jediNumber = 1;

            if (args.Length >0)
                jediNumber = Int32.Parse(args[0]);

            // Graph Query Language
            // Query : what we   query for
            // Types: 
            // Mutation: what we can call that semantically we will change something

            // we can query for hello, and the type of response is string
            // var schema = Schema.For(@"type Query { hello: String}");

            var schema = Schema.For(@"
  type Jedi {
      name: String,
      side: String,
      id: ID
  }

  type Query {
      hello: String,
      jedis: [Jedi],
      jedi(id: ID): Jedi
  }
  ", _ =>
            {
                _.Types.Include<Query>();
            });

            // resolver code : maps something inside of our query and if user asks for Hello,
            // we will answer with Hello
            var root = new { Hello = "Hello World!" };

            var jsonQuery = "{jedi(id: "+jediNumber+") { name, side }}";

            //execute our query by assigning it to the property query 
            var json = schema.Execute(_ =>
              {
                  //  _.Query = "{hello}";
                  //_.Query ="{jedis {name, side}}";
                  _.Query = jsonQuery;
                  _.Root = root;
              });

            Console.WriteLine(json);

        }
    }
}
