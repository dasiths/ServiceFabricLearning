using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using TestActor.Interfaces;
using TestStatefulService.Interfaces;

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

            ITestStatefulService service = ServiceProxy.Create<ITestStatefulService>(new Uri("fabric:/ServiceFabricTest/TestStatefulService"), new ServicePartitionKey(1));

            var message = service.GetResultAsync();
            Console.Write(message.Result);
            Console.ReadLine();
        }
    }
}
