namespace GrpcServer
{
    public class UsersDB
    {
        public Dictionary<int, User> DB { get; set; } = new Dictionary<int, User>();
        private static UsersDB? instance;
        private static object lockObj = new object();

        private UsersDB()
        {
            DB.Add(1, new User
            {
                Id = "1",
                Name = "John",
                Surname = "Doe",
                Address = "123 Main St",
                PhoneNumbers =
                {
                    new User.Types.PhoneNumber { Number = "555-1234" },
                    new User.Types.PhoneNumber { Number = "555-5678" }
                }
            });
            DB.Add(2, new User
            {
                Id = "2",
                Name = "Jane",
                Surname = "Doe",
                Address = "123 Main",
                PhoneNumbers =
                {
                    new User.Types.PhoneNumber { Number = "555-1234" }
                }
            });
            DB.Add(3, new User
            {
                Id = "3",
                Name = "Alice",
                Surname = "Smith",
                PhoneNumbers =
                {
                    new User.Types.PhoneNumber { Number = "555-1234" }
                }
            });
        }

        public static UsersDB Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new UsersDB();
                    }
                    return instance;
                }
            }
        }
    }
}
