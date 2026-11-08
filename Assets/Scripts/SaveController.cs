using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{

    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;
    private static SaveController _instance;

    public string namePlayer;
    public string nameEnemy;

    public static SaveController Instance => _instance ??= FindAnyObjectByType<SaveController>() ?? CreateSingleton();

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }


    private static SaveController CreateSingleton()
    {
        return new GameObject(nameof(SaveController)).AddComponent<SaveController>();
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString("SavedWinner", winner);
    }
    public string GetLastWinner()
    {
        return PlayerPrefs.GetString("SavedWinner");
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
