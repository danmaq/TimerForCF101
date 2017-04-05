using System;
using System.Diagnostics;
using System.Media;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace CountdownForCashflow.Pages
{
	/// <summary>
	/// CountDown.xaml の相互作用ロジック
	/// </summary>
	public partial class CountDown : UserControl
	{
		private readonly DispatcherTimer timer = new DispatcherTimer();
		private AgeManager.AgeManager age;

		public CountDown()
		{
			InitializeComponent();
			timer.Interval = new TimeSpan(TimeSpan.TicksPerSecond);
			timer.Tick += (sender, e) => Tick();
		}

		protected override void OnVisualParentChanged(DependencyObject oldParent)
		{
			if (oldParent == null)
			{
				age = AgeManager.AgeManager.First;
				timer.Start();
			}
			else
			{
				Stop();
			}
			base.OnVisualParentChanged(oldParent);
		}

		private void Tick()
		{
			if (age.AmountNextAge == TimeSpan.Zero)
			{
				var check = age.CurrentAge % 10 == 0;
				var sound = check ? SystemSounds.Question : SystemSounds.Asterisk;
				sound.Play();
			}
			if (age.Amount == TimeSpan.Zero)
			{
				Stop();
			}
			else
			{
				try
				{
					age = age.Tick();
					DataContext = age.Rasterize();
					Debug.WriteLine(age.Rasterize());
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex);
				}
			}

		}

		private void Stop()
		{
			timer.Stop();
			SystemSounds.Hand.Play();
		}
	}
}
