using AuctionServiceReference;
using ProductServiceReference;
using QuizServiceReference;
using System.ServiceModel;

#region QUIZ

//QuizServiceClient client = new QuizServiceClient();

//Console.WriteLine("Hello there!");

//int input;

//while (true)
//{
//    Console.WriteLine("Choose one of the options:\n1) Add Question\n2) Modify Question\n3) Quiz");
//    input = Convert.ToInt32(Console.ReadLine());

//    switch (input)
//    {
//        case 1:
//            {
//                Console.WriteLine("Enter question text");
//                string text = Console.ReadLine();

//                Console.WriteLine("Enter question answer - true or false");
//                string _answer = Console.ReadLine();
//                bool answer = _answer == "true" ? true : false;

//                Question q = new Question()
//                {
//                    Text = text,
//                    Answer = answer
//                };

//                client.AddQuestion(q);
//            }
//            break;
//        case 2:
//            {
//                Dictionary<int, Question> questions = client.GetQuestions();
//                foreach (var question in questions)
//                {
//                    Console.WriteLine($"{question.Key}) {question.Value.Text}");
//                }
//                Console.WriteLine("Choose question number");
//                int questionNumber = Convert.ToInt32(Console.ReadLine());

//                bool questionPresent = questions.TryGetValue(questionNumber, out _);
//                if (!questionPresent)
//                {
//                    Console.WriteLine("Question doesn't exist");
//                    break;
//                }

//                Console.WriteLine("1) Modify text\n2) Modify answer");

//                int response = Convert.ToInt32(Console.ReadLine());

//                if (response == 1)
//                {
//                    Console.WriteLine("Enter new text");
//                    string text = Console.ReadLine();
//                    client.ModifyQuestionText(questionNumber, text);
//                }
//                else if (response == 2)
//                {
//                    Console.WriteLine("Enter new answer - true or false");
//                    string _answer = Console.ReadLine();
//                    bool answer = _answer == "true" ? true : false;
//                    client.ModifyQuestionAnswer(questionNumber, answer);
//                }
//            }
//            break;
//        case 3:
//            {
//                Dictionary<int, Question> questions = client.GetQuestions();
//                int score = 0;
//                foreach (var question in questions)
//                {
//                    Console.WriteLine(question.Value.Text);
//                    Console.WriteLine("Enter your answer - true or false");
//                    string _answer = Console.ReadLine();
//                    bool answer = _answer == "true" ? true : false;

//                    if (answer == question.Value.Answer)
//                    {
//                        score++;
//                    }
//                }

//                Console.WriteLine($"Your score is {score}");
//            }
//            break;
//        default:
//            Console.WriteLine("Invalid input");
//            break;
//    }
//}

//client.Close();

#endregion

#region PRODUCTS

//ProductsServiceClient client = new ProductsServiceClient(new InstanceContext(new ProductsServiceCallbackHandler()));

//Console.WriteLine("Hello there! Let's register first");
//client.Register();

//int input;

//while (true)
//{
//    Console.WriteLine("Choose one of the options:\n1) Add Product\n2) Get All Products\n3) Produce Product");
//    input = Convert.ToInt32(Console.ReadLine());

//    switch (input)
//    {
//        case 1:
//            {
//                Console.WriteLine("Enter product name");
//                string name = Console.ReadLine();

//                Product p = new Product()
//                {
//                    Name = name
//                };

//                client.AddNewProduct(p);
//            }
//            break;
//        case 2:
//            {
//                Dictionary<int, Product> products = client.GetAllProducts();
//                foreach (var product in products)
//                {
//                    Console.WriteLine($"{product.Key}) {product.Value.Name} - {product.Value.Quantity}");
//                }
//            }
//            break;
//        case 3:
//            {
//                Dictionary<int, Product> products = client.GetAllProducts();
//                foreach (var product in products)
//                {
//                    Console.WriteLine($"{product.Key}) {product.Value.Name} - {product.Value.Quantity}");
//                }
//                Console.WriteLine("Choose product number");
//                int productNumber = Convert.ToInt32(Console.ReadLine());

//                bool productPresent = products.TryGetValue(productNumber, out _);
//                if (!productPresent)
//                {
//                    Console.WriteLine("Product doesn't exist");
//                    break;
//                }

//                Console.WriteLine("Enter quantity to produce");
//                double quantity = Convert.ToDouble(Console.ReadLine());
//                client.ProduceProduct(productNumber, quantity);
//            }
//            break;
//        default:
//            Console.WriteLine("Invalid input");
//            break;
//    }
//}


//public class ProductsServiceCallbackHandler : IProductsServiceCallback
//{
//    public void Notify(Product product)
//    {
//        Console.WriteLine($"Product {product.Name} is now available in quantity {product.Quantity}");
//    }
//}

#endregion

#region AUCTION

AuctionServiceClient client = new AuctionServiceClient();

Console.WriteLine("Hello there! Let's register first");
Console.WriteLine("Enter your id, name and surname in separate lines");
int id = Convert.ToInt32(Console.ReadLine());
string name = Console.ReadLine();
string surname = Console.ReadLine();

client.Register(id, name, surname);

int input;

while (true)
{
    Console.WriteLine("Choose one of the options:\n1) Get Current Exponat\n2) Bid On Current Exponat\n3) Give Up On Current Exponat");
    input = Convert.ToInt32(Console.ReadLine());

    switch (input)
    {
        case 1:
            {
                Exponat exponat = client.GetCurrentExponat();
                Console.WriteLine($"Current exponat: {exponat.Name} priceL {exponat.Price} hbid: {exponat.HighestBidderId}");
            }
            break;
        case 2:
            {
                Console.WriteLine("Enter amount to bid");
                double amount = Convert.ToDouble(Console.ReadLine());
                client.BidOnCurrentExponat(id, amount);
            }
            break;
        case 3:
            {
                client.GiveUpOnCurrentExponat(id);
            }
            break;
        default:
            Console.WriteLine("Invalid input");
            break;
    }
}

#endregion AUCTION