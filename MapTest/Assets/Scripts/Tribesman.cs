using System;
using UnityEngine;

[Serializable]
public class Tribesman
{
	public string Name;
	public int Age;

	public float FoodperDay;
	public float maxHealth;
	public float Health;

	public enum GenderType {Male, Female};

	public GenderType Gender;

	public Tribesman ()
	{
		Name = generateRandomName();


		maxHealth = UnityEngine.Random.Range (75, 125);
		Health = maxHealth;

		Age = UnityEngine.Random.Range (10, 50);

		FoodperDay = 2;

		int genderRoll = UnityEngine.Random.Range (1, 3);

		if (genderRoll == 1) {
			Gender = GenderType.Male;
		} else {
			Gender = GenderType.Female;
		}

	}

	string generateRandomName() {
		//consonant-vowel-consonant-vowel-consonant

		int nameLength = UnityEngine.Random.Range (3, 8);


		string consonantStr = "bcdfghjklmnpqrstvwxz";
		string vowelStr = "aeiouy";

		char[] consonants = consonantStr.ToCharArray ();
		char[] vowels = vowelStr.ToCharArray ();

		string resultName = "";

		bool nextLetterisVowel = false;

		for (int i = 0; i <= nameLength; i++) {
			if (nextLetterisVowel) {
				resultName += vowels [UnityEngine.Random.Range (0, vowels.Length)];
				nextLetterisVowel = false;
			} else {
				resultName += consonants [UnityEngine.Random.Range (0, consonants.Length)];
				nextLetterisVowel = true;
			}

			if (i == 0) {
				resultName = resultName.ToUpper ();
			}
		}

		return resultName;
	}

	public void decrementHealth(float decrementAmount) {
		Health -= decrementAmount;

	}
}


