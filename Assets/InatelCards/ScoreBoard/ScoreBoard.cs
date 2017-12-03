namespace InatelCards.ScoreBoard
{
	using System;
	using System.Text;
	using UnityEngine;
	using UnityEngine.UI;

	public class ScoreBoard : MonoBehaviour
	{
		private void Awake()
		{
			ScoreReaderWriter scoreboard = new ScoreReaderWriter();
			PlayerScore[] scores = scoreboard.HighScores;
			StringBuilder builder = new StringBuilder(Environment.NewLine);
			builder.AppendLine("High Scores:");

			for (int i = 0; i < scores.Length; i++)
			{
				builder.AppendFormat(
					"{0}. {1} - {2}",
					i + 1,
					scores[i].Name,
					scores[i].Score);
				builder.AppendLine();
			}

			GameObject.Find("Text").GetComponent<Text>().text = builder.ToString();
		}
	}
}
