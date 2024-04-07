using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;
using System;

using var channel = GrpcChannel.ForAddress("http://localhost:5117");
// var client = new GrpcServer.Users.UsersClient(channel);
var client = new GrpcServer.FishPond.FishPondClient(channel);


string input;

do
{
    Console.WriteLine("Average value for data - av");
    Console.WriteLine("Add or multiply data - am");
    Console.WriteLine("Get accumulator - g");
    Console.WriteLine("Stop exec - x");

    input = Console.ReadLine()!;

    switch (input)
    {
        case "av":
            await AverageValueForData();
            break;
        case "am":
            await AddOrMultiplyData();
            break;
        case "g":
            await GetAccumulator();
            break;
        case "x":
            break;
        default:
            break;
    }   
}
while (input != "x");

async Task AverageValueForData()
{
    //Console.WriteLine("Input integer numbers.\nEnter \"x\" to finish data stream");
    //try
    //{
    //    var call = client.AverageValueForData();
    //    while (true)
    //    {
    //        string userInput = Console.ReadLine()!;
    //        if (userInput == "x") break;

    //        int number = int.Parse(userInput);

    //        await call.RequestStream.WriteAsync(new Data
    //        {
    //            Value = number
    //        });
    //    }

    //    await call.RequestStream.CompleteAsync();

    //    var resp = await call;
    //    Console.ForegroundColor = ConsoleColor.Green;
    //    Console.WriteLine("Average value for data calculated");
    //    Console.ResetColor();
    //}
    //catch (Exception e)
    //{
    //    Console.WriteLine(e);
    //}
}

async Task AddOrMultiplyData()
{
    //Console.WriteLine("Input integer numbers.\nEnter \"x\" to finish data stream");
    //try
    //{
    //    var call = client.AddOrMultiplyData();
    //    var serverReaderTask = Task.Run(async () =>
    //    {
    //        await foreach (var resp in call.ResponseStream.ReadAllAsync())
    //        {
    //            Console.ForegroundColor = ConsoleColor.Green;
    //            Console.WriteLine(resp.Value);
    //            Console.ResetColor();
    //        }
    //    });

    //    while (true)
    //    {
    //        string userInput = Console.ReadLine()!;
    //        if (userInput == "x") break;

    //        int number = int.Parse(userInput);

    //        await call.RequestStream.WriteAsync(new Data
    //        {
    //            Value = number
    //        });
    //    }

    //    await call.RequestStream.CompleteAsync();
    //}
    //catch (Exception e)
    //{
    //    Console.WriteLine(e);
    //}
}   

async Task GetAccumulator()
{
    Console.ForegroundColor = ConsoleColor.Green;
    try
    {
        var resp = await client.GetAllDataAsync(new Google.Protobuf.WellKnownTypes.Empty());      
        Console.WriteLine($"Accumulator: {resp.Data}");    
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
    Console.ResetColor();
}   


# region User methods
//do
//{
//    Console.WriteLine("Add user - a1");
//    Console.WriteLine("Delete user - d1");
//    Console.WriteLine("Delete many users - dm");
//    Console.WriteLine("Update user - u1");
//    Console.WriteLine("Get user - g1");
//    Console.WriteLine("Get many users - gm");
//    Console.WriteLine("Stop exec - x");
//    input = Console.ReadLine();
//    Console.ForegroundColor = ConsoleColor.Green;
//    switch (input)
//    {
//        case "a1":
//            await AddUser();
//            break;
//        case "d1":
//            await DeleteUser();
//            break;
//        case "dm":
//            await DeleteUsers();
//            break;
//        case "u1":
//            await UpdateUser();
//            break;
//        case "g1":
//            await GetUser();
//            break;
//        case "gm":
//            await GetUsers();
//            break;
//        case "x": break;
//        default: break;
//    }
//    Console.ResetColor();
//} while (input != "x");

//async Task AddUser()
//{
//    Console.WriteLine("Enter user id, name, surname, address, phone number");
//    string id = Console.ReadLine();
//    string name = Console.ReadLine();
//    string surname = Console.ReadLine();
//    string address = Console.ReadLine();
//    string phoneNumber = Console.ReadLine();


//    try
//    {
//        var resp = await client.AddNewUserAsync(new User
//        {
//            Id = id,
//            Name = name,
//            Surname = surname,
//            Address = address,
//            PhoneNumbers = { new User.Types.PhoneNumber { Number = phoneNumber } }
//        });
//        Console.WriteLine(resp.Text);
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}

//async Task UpdateUser()
//{
//    Console.WriteLine("Enter user id, name, surname, address, phone number");
//    string id = Console.ReadLine();
//    string name = Console.ReadLine();
//    string surname = Console.ReadLine();
//    string address = Console.ReadLine();
//    string phoneNumber = Console.ReadLine();

//    try
//    {
//        var resp = await client.UpdateUserAsync(new User
//        {
//            Id = id,
//            Name = name,
//            Surname = surname,
//            Address = address,
//            PhoneNumbers = { new User.Types.PhoneNumber { Number = phoneNumber } }
//        });
//        Console.WriteLine(resp.Text);
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}

//async Task DeleteUser()
//{
//    Console.WriteLine("Enter user id");
//    string id = Console.ReadLine();

//    try
//    {
//        var resp = await client.DeleteUserAsync(new UserId
//        {
//            Id = id
//        });
//        Console.WriteLine(resp.Text);
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}

//async Task DeleteUsers()
//{
//    Console.WriteLine("Enter user ids.\nEnter \"-1\" to stop inputs");
//    try
//    {
//        var call = client.DeleteUsers();

//        var serverReaderTask = Task.Run(async () =>
//        {
//            await foreach (var resp in call.ResponseStream.ReadAllAsync())
//            {
//                Console.WriteLine(resp.Text);
//            }
//        });
        
//        while (true)
//        {
//            string id = Console.ReadLine();
//            if (id == "-1") break;

//            await call.RequestStream.WriteAsync(new UserId
//            {
//                Id = id
//            });
//        }

//        await call.RequestStream.CompleteAsync();
//        await serverReaderTask;
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}

//async Task GetUser()
//{
//    Console.WriteLine("Enter user id");
//    string id = Console.ReadLine();

//    try
//    {
//        var resp = await client.GetUserByIdAsync(new UserId
//        {
//            Id = id
//        });
//        Console.WriteLine($"{resp.Id} {resp.Name} {resp.Surname}");
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}

//async Task GetUsers()
//{
//    Console.WriteLine("Enter bottom and upper ids bound");
//    string fromId = Console.ReadLine();
//    string toId = Console.ReadLine();
//    try
//    {
//        var call = client.GetUsersFromTo(new UserIds
//        {
//            From = fromId,
//            To = toId
//        });

//        await foreach (var resp in call.ResponseStream.ReadAllAsync())
//        {
//            Console.WriteLine($"{resp.Id}   {resp.Name}   {resp.Surname}");
//        }
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}

# endregion