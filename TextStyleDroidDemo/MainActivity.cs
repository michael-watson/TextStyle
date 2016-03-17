using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using TextStyles.Droid;
using Android.Content.PM;
using TextStyles.Core;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace TextStyleDroidDemo
{
	[Activity (Theme = "@android:style/Theme.Holo.Light", Label = "TextStyleDroidDemo", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		const string headingOne = @"The difference between";
		const string headingTwo = @"Ordinary & Extraordinary";
		const string headingThree = @"Is that little <spot>extra</spot>";
		const string textBody = @"Geometry can produce legible letters but <i>art alone</i> makes them beautiful.<p>Art begins where geometry ends, and imparts to letters a character trascending mere measurement.</p>";

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			string style;
			using (var sr = new StreamReader (Assets.Open ("StyleOne.css"))) {
				style = sr.ReadToEnd ();
			}

			TextStyle.Instance.SetCSS (style);
			TextStyle.Instance.AddFont ("Archistico", "Archistico_Simple.ttf");
			TextStyle.Instance.AddFont ("Avenir-Medium", "Avenir-Medium.ttf");
			TextStyle.Instance.AddFont ("Avenir-Book", "Avenir-Book.ttf");
			TextStyle.Instance.AddFont ("Avenir-Heavy", "Avenir-Heavy.ttf");

			// TEMP
			var stopwatch = Stopwatch.StartNew ();

			var viewHeadingOne = FindViewById<TextView> (Resource.Id.labelOne);
			TextStyle.Style<TextView> (viewHeadingOne, "h2", headingOne);

			var viewHeadingTwo = FindViewById<TextView> (Resource.Id.labelTwo);
			TextStyle.Style<TextView> (viewHeadingTwo, "h1", headingTwo);

			var viewHeadingThree = FindViewById<TextView> (Resource.Id.labelThree);
			TextStyle.Style<TextView> (viewHeadingThree, "h2", headingThree, new List<CssTagStyle> {
				new CssTagStyle ("spot"){ CSS = "spot{color:#ff6b00;}" }
			});

			var viewBody = FindViewById<TextView> (Resource.Id.body);
			TextStyle.Style<TextView> (viewBody, "body", textBody);

			// TEMP
			Console.WriteLine ("Elapsed time {0}", stopwatch.ElapsedMilliseconds);
		}
	}
}


