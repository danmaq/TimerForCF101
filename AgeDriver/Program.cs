using System;
using System.Media;
using System.Threading;
using AgeManager;

namespace AgeDriver
{
	class Program
	{
		static void Main(string[] args)
		{
			var age = AgeManager.AgeManager.First;
			do
			{
				age = age.Tick();
				Console.WriteLine(age.Rasterize());
				Thread.Sleep(2);
				if (age.NextAge)
				{
					var check = age.CurrentAge % 10 == 0;
					var sound = check ? SystemSounds.Question : SystemSounds.Asterisk;
					sound.Play();
				}
			}
			while (!age.Timeup);
			Thread.Sleep(1000);
			SystemSounds.Hand.Play();
			Console.ReadKey();
		}
	}
}
