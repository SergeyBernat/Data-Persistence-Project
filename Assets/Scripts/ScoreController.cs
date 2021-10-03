using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TMP_InputField enterName;
    [SerializeField] Button start;
    [SerializeField] Button quit;
    public PlayerData data;
    [SerializeField] public string playerName;

    [SerializeField] public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        GetData();
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        score.text += $"{Instance.data.playerName} : {Instance.data.highScore}";
    }
    public void GetData()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
        Instance.data = JsonUtility.FromJson<PlayerData>(json);
    }
    public void ChangeText()
    {
        playerName = enterName.text;
    }

    public void Load()
    {

        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
