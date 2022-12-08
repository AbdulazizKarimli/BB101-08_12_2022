//Thread thread1 = new Thread(ShowA);
//Thread thread2 = new Thread(ShowB);

//thread1.Start();
////thread1.Join();
//thread2.Start();
//Thread.Sleep(50);
//Console.WriteLine("Hello");
//Console.WriteLine("Hello1");

//ShowA();
//ShowB();
//reace condition
//void ShowA()
//{
//    for (int i = 0; i < 10000; i++)
//    {
//        //Thread.Sleep(50);
//        Console.Write("a ");
//    }
//}

//void ShowB()
//{
//    for (int i = 0; i < 10000; i++)
//    {
//        //Thread.Sleep(50);
//        Console.Write("b ");
//    }
//}

using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Thread.Exceptions;
using Thread.Models;

int count = 0;




//Increase();
//Decrease();

//object vilayetObj1 = new object();
//object vilayetObj = new object();

//Thread thread1 = new(Increase);
//Thread thread2 = new(Decrease);

//thread1.Start();
//thread2.Start();
//thread1.Join();
//thread2.Join();

//Console.WriteLine(count);

//void Increase()
//{
//    for (int i = 0; i < 1000000; i++)
//    {
//        lock (vilayetObj)
//        {
//            count++;
//        }
//    }
//}

//void Decrease()
//{
//    for (int i = 0; i < 1000000; i++)
//    {
//        lock (vilayetObj)
//        {
//            count--;
//        }
//    }
//}
try
{
    var response = await GetAsync("https://jsonplaceholder.typicode.com/posts");

    foreach (var item in response)
    {
        Console.WriteLine(item.Title);
    }
}
catch (NotFoundException ex)
{
    Console.WriteLine(ex.Message);
}

static async Task<List<Post>> GetAsync(string path)
{
    List<Post> post = default;
    using (HttpClient client = new HttpClient())
    {
        var responseMessage = await client.GetAsync(path);
        if (responseMessage.IsSuccessStatusCode)
        {
            var responseStr = await responseMessage.Content.ReadAsStringAsync();

            //post = JsonSerializer.Deserialize<List<Post>>(responseStr);
            post = JsonConvert.DeserializeObject<List<Post>>(responseStr);
        }
        else
        {
            throw new NotFoundException("data not found");
        }
    }
    return post;
}