namespace GrpcServer
{
    public class AccDB
    {
        public int Acc;
        private static AccDB? instance;
        private static object lockObj = new object();

        private AccDB() { 
            Acc = 1;
        }

        public static AccDB Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new AccDB();
                    }
                    return instance;
                }
            }
        }
    }
}
