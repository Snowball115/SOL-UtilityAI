/// <summary>
/// Singleton class
/// </summary>
public class Singleton<T> where T : class, new()
{
    private static T instance;

    // Make sure that only on instance of this class exists
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}