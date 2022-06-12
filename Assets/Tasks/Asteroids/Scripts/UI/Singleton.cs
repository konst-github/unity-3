using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    #region Private Variables

    private static T instance;

    #endregion

    #region Public Properties

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    #endregion

    #region Unity Callbacks

    protected void Awake()
    {
        instance = this as T;
        DontDestroyOnLoad(instance.gameObject);
        Debug.Log($"{typeof(T)} created.");
    }

    #endregion
}
