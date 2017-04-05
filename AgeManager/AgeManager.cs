using System;

namespace AgeManager
{
	public struct AgeManager
	{
		public const long START_AGE = 15;
		public const long END_AGE = 60;
		public static readonly TimeSpan AgeSpan = new TimeSpan(2, 42, 0);
		public static readonly AgeManager First = new AgeManager(AgeSpan);

		public readonly long CurrentAge;
		public readonly TimeSpan Amount;
		public readonly TimeSpan AmountNextAge;

		public AgeManager(TimeSpan amount)
			: this()
		{
			const long ALL_AGE = END_AGE - START_AGE;
			Amount = amount;
			var tickYear = AgeSpan.Ticks / ALL_AGE;
			AmountNextAge = new TimeSpan(Amount.Ticks % tickYear);
			CurrentAge = START_AGE + (AgeSpan.Ticks - Amount.Ticks) / tickYear;
		}

		public bool NextAge
		{
			get
			{
				return AmountNextAge.TotalSeconds == 0;
			}
		}

		public bool Timeup
		{
			get
			{
				return Amount.TotalSeconds == 0;
			}
		}

		public RasterizedAge Rasterize()
		{
			return
				new RasterizedAge()
				{
					AmountNextAge = AmountNextAge.ToString(@"m\:ss"),
					AmountTime = string.Format(@"⏰ {0}", Amount),
					CurrentAge = string.Format(@"🙍 {0}", CurrentAge),
				};
		}

		public AgeManager Tick()
		{
			return new AgeManager(new TimeSpan(Amount.Ticks - TimeSpan.TicksPerSecond));
		}
	}
}
