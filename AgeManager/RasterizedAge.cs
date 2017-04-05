
namespace AgeManager
{
	public class RasterizedAge
	{

		public string CurrentAge
		{
			get;
			set;
		}

		public string AmountTime
		{
			get;
			set;
		}

		public string AmountNextAge
		{
			get;
			set;
		}

		public override string ToString()
		{
			return
				string.Format(
					@"AgeManager.RasterizedAge [{0}({1}), {2}]",
					CurrentAge,
					AmountNextAge,
					AmountTime);
		}
	}
}
