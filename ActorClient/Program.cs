using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using TestActor.Interfaces;

namespace ActorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ITestActor actor = ActorProxy.Create<ITestActor>(ActorId.CreateRandom(), new Uri("fabric:/ServiceFabricTest/TestActorService"));
            var retval = actor.GetCountAsync(new CancellationToken());
            Console.Write(retval.Result);
            Console.ReadLine();
        }
    }
}
