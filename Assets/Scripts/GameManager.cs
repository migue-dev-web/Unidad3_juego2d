using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int totalCoins;
    private SQLiteDB db;

    void Awake()
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);}
            else {
                Destroy(gameObject); 
            return;
            }
    }
    void Start()
    {
        db = FindFirstObjectByType<SQLiteDB>();
        LoadCoins();
    }

     public void AddCoins(int amount)
    {
        
        db.SaveData(amount, 0, 0);

    }

    public void LoadCoins()
    {
        db.LoadData(); 
    }

    void Update()
    {
        
    }
}
