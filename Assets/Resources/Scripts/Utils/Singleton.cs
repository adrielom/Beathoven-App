namespace Beathoven.Utils
{
    class Singleton<T>
    {

        public static Singleton<T> instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton<T>();
                }
                return instance;
            }

            set { instance = value; }
        }
    }
}
