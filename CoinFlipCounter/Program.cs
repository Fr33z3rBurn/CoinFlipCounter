using System;
using System.Collections.Generic;

namespace CoinFlipCounter
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(GetCoinFlipStreaks(100000));
			Console.ReadLine();
		}

		public static string GetCoinFlipStreaks(int numberOfFlips)
		{
			int longestHeadsStreak = 0;
			int longestTailsStreak = 0;

			int currentHeadsStreak = 0;
			int currentTailsStreak = 0;

			int? previousFlip = null;

			List<int> flipList = new List<int>();

			for (int i = 0; i < numberOfFlips; i++)
			{
				var random = new Random();
				flipList.Add(random.Next(0, 2));
			}

			foreach (var flip in flipList)
			{
				if(flip == previousFlip)
				{
					if(flip == 1)
					{
						currentHeadsStreak++;
						previousFlip = flip;
					}
					else
					{
						currentTailsStreak++;
						previousFlip = flip;
					}
				}
				else
				{
					if(currentHeadsStreak > longestHeadsStreak)
					{
						longestHeadsStreak = currentHeadsStreak;
					}
					else if(currentTailsStreak > longestTailsStreak)
					{
						longestTailsStreak = currentTailsStreak;
					}

					currentHeadsStreak = 0;
					currentTailsStreak = 0;

					if (flip == 1)
					{
						currentHeadsStreak++;
						previousFlip = flip;
					}
					else
					{
						currentTailsStreak++;
						previousFlip = flip;
					}
				}
			}

			return $"The longest heads streak was {longestHeadsStreak}.  The longest tails streak was {longestTailsStreak}.";
		}
	}
}
