using UnityEngine;
using System.Collections;

public static class Score {

	private static int currentScore;

	public static void increaseScore(int amount) {
		currentScore += amount;
	}

	public static int getScore() {
		return currentScore;
	}
}
