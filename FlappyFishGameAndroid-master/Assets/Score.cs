using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int score = 0;
	public static int highScore = 0;
	static bool isContinue=false;
	public TextMeshProUGUI GameOverScoreText;
    public TextMeshProUGUI GameOverHighScoreText;

    static Score instance;

	static public void AddPoint() {
		if(instance.fish.dead)
			return;

		score++;

		//if(score > highScore) {
		//	highScore = score;
		//}
	}

	Fish fish;

	void Start() {
		instance = this;
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		if(player_go == null) {
			Debug.LogError("Could not find an object with tag 'Player'.");
		}

		fish = player_go.GetComponent<Fish>();
		if(isContinue==false)
		{
            score = 0;
        }
		else if (isContinue == true)
		{
			isContinue = false;
		}
		highScore = PlayerPrefs.GetInt("highScore", 0);
	}

	void OnDestroy() {
		instance = null;
		PlayerPrefs.SetInt("highScore", highScore);
	}

	void Update () {

		transform.GetComponentInChildren<Text>().text = "当前得分: " + score;//+ "\n最高分: " + highScore;
		GameOverScoreText.text = score.ToString();
		GameOverHighScoreText.text = highScore.ToString();


	}
	public void Continue()
	{
		isContinue = true;
		SceneManager.LoadScene(0);
	}
	public void ReLoad()
	{
        SceneManager.LoadScene(0);
    }
}


