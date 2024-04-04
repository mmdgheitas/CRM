using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Implement;
using Infrastructure.Service.Interface;
using Interface.Models;
using Interface.Models.Access;
using Interface.Models.Factor;
using Interface.Models.Plaid;
using Interface.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

public static class Utility
{
	public class JsonData
	{
		public string Script { get; set; }
		public string html { get; set; }
		public bool success { get; set; }
		public object? Data { get; set; }
	}

	public static string TimeAgo(this DateTime dt, DateTime now)
	{
		if (dt > now)
			return dt.ToString("MM/dd/yyyy");
		TimeSpan span = now - dt;

		if (span.Days > 10)
		{
			return dt.ToString("MM/dd/yyyy");
		}

		//if (span.Days > 365)
		//{
		//    int years = (span.Days / 365);
		//    if (span.Days % 365 != 0)
		//        years += 1;
		//    return String.Format("about {0} {1} ago", years, years == 1 ? "year" : "years");
		//}

		//if (span.Days > 30)
		//{
		//    int months = (span.Days / 30);
		//    if (span.Days % 31 != 0)
		//        months += 1;
		//    return String.Format("about {0} {1} ago", months, months == 1 ? "month" : "months");
		//}

		if (span.Days > 0)
			return String.Format("about {0} {1} ago", span.Days, span.Days == 1 ? "day" : "days");

		if (span.Hours > 0)
			return String.Format("about {0} {1} ago", span.Hours, span.Hours == 1 ? "hour" : "hours");

		if (span.Minutes > 0)
			return String.Format("about {0} {1} ago", span.Minutes, span.Minutes == 1 ? "minute" : "minutes");

		if (span.Seconds > 5)
			return String.Format("about {0} seconds ago", span.Seconds);

		if (span.Seconds <= 5)
			return "just now";

		return string.Empty;
	}

	public static string TimeAgoShort(this DateTime dt, DateTime now)
	{
		if (dt > now)
			return dt.ToString("MM/dd/yyyy");
		TimeSpan span = now - dt;

		if (span.Days > 10)
		{
			return dt.ToString("MM/dd/yyyy");
		}

		//if (span.Days > 365)
		//{
		//    int years = (span.Days / 365);
		//    if (span.Days % 365 != 0)
		//        years += 1;
		//    return String.Format("about {0} {1} ago", years, years == 1 ? "year" : "years");
		//}

		//if (span.Days > 30)
		//{
		//    int months = (span.Days / 30);
		//    if (span.Days % 31 != 0)
		//        months += 1;
		//    return String.Format("about {0} {1} ago", months, months == 1 ? "month" : "months");
		//}

		if (span.Days > 0)
			return String.Format("{0} {1} ago", span.Days, span.Days == 1 ? "day" : "days");

		if (span.Hours > 0)//
			return String.Format("{0} {1} ago {2}", span.Hours, span.Hours == 1 ? "hour" : "hours", "<i class='fa fa-star color-yellow'> </i>");

		if (span.Minutes > 0)
			return String.Format("{0} {1} ago {2}", span.Minutes, span.Minutes == 1 ? "minute" : "minutes", "<i class='fa fa-star color-yellow'> </i>");

		if (span.Seconds > 5)
			return String.Format("{0} seconds ago {1}", span.Seconds, "<i class='fa fa-star color-yellow'> </i>");

		if (span.Seconds <= 5)
			return "just now " + "<i class='fa fa-star color-yellow'> </i>";

		return string.Empty;
	}

	public static string TimeLeft(this DateTime dt, DateTime now)
	{
		var totalDay = (new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0) - new DateTime(now.Year, now.Month, now.Day, 0, 0, 0)).TotalDays;
		totalDay = totalDay > 0 ? Math.Floor(totalDay) : Math.Ceiling(totalDay);

		if (totalDay > 1)
			return $"<span class='color-green'>{totalDay + " days left"} </span>";
		else if (totalDay == 1)
			return $"<span class='color-green'>{totalDay + " day left"} </span>";
		else if (totalDay == -1)
			return $"<span class='color-red'>{"1 day ago"} </span>";
		else if (totalDay == 0)
			return "<span class='color-green'>Today </span>";
		else
			return $"<span class='color-red'>{(totalDay * -1) + " days ago"} </span>";
	}

	public static string TimeLeftUserPayment(this DateTime dt, DateTime now)
	{
		var totalDay = (new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0) - new DateTime(now.Year, now.Month, now.Day, 0, 0, 0)).TotalDays;
		totalDay = totalDay > 0 ? Math.Floor(totalDay) : Math.Ceiling(totalDay);

		if (totalDay > 1)
			return $"<span class='color-green'>{totalDay + " days left"} </span>";
		else if (totalDay == 1)
			return $"<span class='color-green'>{totalDay + " day left"} </span>";
		else if (totalDay == -1)
			return $"<span class='color-red'>Past Due </span>";
		else if (totalDay == 0)
			return "<span class='color-green'>Today </span>";
		else
			return $"<span class='color-red'>Past Due </span>";
	}

	public static string TimeAgoShortApp(this DateTime dt, DateTime now)
	{
		if (dt > now)
			return dt.ToString("MM/dd/yyyy");
		TimeSpan span = now - dt;

		if (span.Days > 10)
		{
			return dt.ToString("MM/dd/yyyy");
		}

		//if (span.Days > 365)
		//{
		//    int years = (span.Days / 365);
		//    if (span.Days % 365 != 0)
		//        years += 1;
		//    return String.Format("about {0} {1} ago", years, years == 1 ? "year" : "years");
		//}

		//if (span.Days > 30)
		//{
		//    int months = (span.Days / 30);
		//    if (span.Days % 31 != 0)
		//        months += 1;
		//    return String.Format("about {0} {1} ago", months, months == 1 ? "month" : "months");
		//}

		if (span.Days > 0)
			return String.Format("{0} {1} ago", span.Days, span.Days == 1 ? "day" : "days");

		if (span.Hours > 0)//
			return String.Format("{0} {1} ago", span.Hours, span.Hours == 1 ? "hour" : "hours");

		if (span.Minutes > 0)
			return String.Format("{0} {1} ago", span.Minutes, span.Minutes == 1 ? "minute" : "minutes");

		if (span.Seconds > 5)
			return String.Format("{0} seconds ago", span.Seconds);

		if (span.Seconds <= 5)
			return "just now ";

		return string.Empty;
	}

	//تبدیل اعداد فارسی به انگلیسی

	public static string CalculatDiffrentTime(this DateTime secound, DateTime first)
	{
		if (first > secound)
			return "The first time is longer than the second time";
		TimeSpan span = secound - first;

		if (span.Days > 10)
		{
			return first.ToString("MM/dd/yyyy");
		}
		if (span.Days > 0)
			return String.Format("{0} {1} ", span.Days, span.Days == 1 ? "day" : "days");

		if (span.Hours > 0)
		{
			var str = String.Format("{0} {1} ", span.Hours, span.Hours == 1 ? "hour" : "hours");
			var min = span.Minutes % 60;
			if (min > 0)
				str += " " + min + " minutes";

			return str;
		}

		if (span.Minutes > 0)
			return String.Format("{0} {1} ", span.Minutes, span.Minutes == 1 ? "minute" : "minutes");

		if (span.Seconds > 5)
			return String.Format("{0} seconds", span.Seconds);

		if (span.Seconds <= 5)
			return "just now " + "<i class='fa fa-star color-yellow'> </i>";

		return string.Empty;
	}

	public static string NullDateToString(this DateTime? dt, string format)
	{
		try
		{
			if (dt == null) return "--";

			return Convert.ToDateTime(dt).ToString(format);
		}
		catch (Exception ex)
		{
			return "--";
		}
	}

	public static double CalculatePercentByAnotherValue(this double value1, double value2)
	{
		try
		{
			double Result = 0;
			var Total = value1 + value2;
			if (value1 > 0) Result = (value1 / Total) * 100;
			if (Result > 100) Result = 100;

			return Result.RoundDecimal();
		}
		catch (Exception ex)
		{
			return 0;
		}
	}

	public static string ToFontAwesomeDateTime(this DateTime dt, string date = " MM/dd/yyyy ", string time = " hh:mm:tt ")
	{
		try
		{
			var result = "<i class='fa fa-calendar'> </i> " + dt.ToString(date) + "<br /><i class='fa fa-clock-o'> </i> " + dt.ToString(time);
			return result;
		}
		catch (Exception ex)
		{
			return "--";
		}
	}

	public static string ToFontAwesomeDateAndTime(this DateTime dt, string date = "MM/dd/yyyy ", string time = "hh:mm:tt")
	{
		try
		{
			var result = "<i class='fa fa-calendar'> </i> " + dt.ToString(date) + "<br /><i class='fa fa-clock-o'> </i> " + dt.ToString(time);
			return result;
		}
		catch (Exception ex)
		{
			return "--";
		}
	}

	public static string ToFontAwesomeDate(this DateTime dt, string date = "MM/dd/yyyy")
	{
		try
		{
			var result = "<i class='fa fa-calendar'> </i> " + dt.ToString(date);
			return result;
		}
		catch (Exception ex)
		{
			return "--";
		}
	}

	public static string ToFontAwesomeTime(this DateTime dt, string time = " hh:mm:tt ")
	{
		try
		{
			var result = "<i class='fa fa-clock-o'> </i> " + dt.ToString(time);
			return result;
		}
		catch (Exception ex)
		{
			return "--";
		}
	}

	public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
	{
		int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
		return dt.AddDays(-1 * diff).Date;
	}

	public static bool IsAjaxRequest(this HttpRequest request)
	{
		if (request == null)
			throw new ArgumentNullException(nameof(request));

		if (request.Headers != null)
			return request.Headers["X-Requested-With"] == "XMLHttpRequest";
		return false;
	}

	public static string TimeForTimeLine(this DateTime dateTime, DateTime now)
	{
		try
		{
			var DifrentDate = (dateTime - now).TotalDays.ToInt();
			if (DifrentDate < 0)
				DifrentDate = DifrentDate * -1;

			if (dateTime.Date == now.Date)
			{
				return "Today At : " + dateTime.ToString("HH:mm");
			}
			else if ((dateTime - now).TotalDays.ToInt() == 1)
			{
				return "Tomorrow At : " + dateTime.ToString("HH:mm");
			}
			else if (DifrentDate < 30)
			{
				return dateTime.ToString("dd MMM") + dateTime.ToString(", HH:mm"); ;
			}
			else
			{
				return dateTime.ToString("yyyy-MM-dd HH:mm");
			}
		}//.ToString("dddd, dd MMMM yyyy")
		catch (Exception ex)
		{
			return "--";
		}
	}

	public static string TimeForTimeLineApp(this DateTime dateTime, DateTime now)
	{
		try
		{
			var DifrentDate = (dateTime - now).TotalDays.ToInt();
			if (DifrentDate < 0)
				DifrentDate = DifrentDate * -1;

			if (dateTime.DayOfYear == now.DayOfYear)
			{
				return "Today";
			}
			else if ((dateTime.DayOfYear - now.DayOfYear).ToInt() == 1)
			{
				return "Tomorrow";
			}
			else if (DifrentDate < 30)
			{
				return dateTime.ToString("ddd, dd MMM");
			}
			else
			{
				return dateTime.ToString("yyyy-MM-dd");
			}
		}//.ToString("dddd, dd MMMM yyyy")
		catch (Exception ex)
		{
			return "--";
		}
	}

	public static DateTime ConverPersina2Miladi(this string Persian)
	{
		Persian = Persian.Fa2En();

		var Date = new DateTime();

		if (Persian != "" && Persian.IsPersianDate()) { }
		//Date = Persian.Calendar.ConvertToGregorian(Persian.JodaKonDate()[0], Persian.JodaKonDate()[1], Persian.JodaKonDate()[2], 0);
		else
			Date = DateTime.Now;
		return Date;
	}

	public static string FindTextAfterCharacter(this string fullText, char character)
	{
		var characterIndex = fullText.LastIndexOf(character);
		return fullText.Substring(characterIndex + 1, fullText.Length - characterIndex - 1);
	}

	public static string GetUntilOrEmpty(this string text, string stopAt = "-")
	{
		if (!String.IsNullOrWhiteSpace(text))
		{
			if (!text.Contains(stopAt))
				return text;
			int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

			if (charLocation > 0)
			{
				return text.Substring(0, charLocation);
			}
		}

		return String.Empty;
	}

	public static string ToHtmlTextMessage(this string TextMessage)
	{
		foreach (Match match in Regex.Matches(TextMessage.Replace("#", " #") + " ", @"\#(.+?)\w{6}"))
		{
			string value = "#" + GetNumbers(match.Value);
			if (value != "#")
			{
				TextMessage = TextMessage.Replace(value, "<span style=\"color:#1a9fc4;\"><a target='_blank' href='/Factor/Update/" + value.TrimStart("#") + "'> <b>" + value.ToString() + "</b> </a> </span>");
			}
		}

		foreach (Match match in Regex.Matches(TextMessage + " ", @"\@(.+?) "))
		{
			TextMessage = TextMessage.Replace(match.Value, "<span style=\"color:#ed5163;\"> <b>" + match.Value.ToString() + "</b></span>");
			//
		}

		TextMessage = TextMessage.Replace("\r\n", "\n");
		TextMessage = "<p>" + TextMessage.Replace("\n", "<br>") + "</p>";
		return TextMessage;
	}

	private static string GetNumbers(string input)
	{
		return new string(input.Where(c => char.IsDigit(c)).ToArray());
	}

	public static string FindTextStartWith(this string TextMessage, char startCharacter)
	{
		var listText = "";
		TextMessage += " ";
		foreach (Match match in Regex.Matches(TextMessage, startCharacter + @"(.+?) "))
		{
			listText += match.Value + " ,";
		}
		return listText.TrimEnd(',').TrimEnd(' ');
	}

	public static string CreateLinkForProject(this string TextMessage)
	{
		try
		{
			foreach (Match match in Regex.Matches(TextMessage, '#' + @"(.+?) "))
			{
				TextMessage = TextMessage.Replace(match.Value, "<a href='/Factor/Update/'" + match.Value.TrimStart('#') + "> " + match.Value + "</a>");
			}
			return TextMessage;
		}
		catch (Exception ex)
		{
			return TextMessage;
		}
	}

	public static string TimeSpamToHoureMinite(this TimeSpan span)
	{
		try
		{
			return String.Format("{0}:{1}:{2}", span.Hours, span.Minutes, span.Seconds);
		}
		catch (Exception)
		{
			return "--";
		}
	}

	public static string TimeSpamToHoureMiniteShort(this TimeSpan span, int maxMinitsAlert = 0)
	{
		try
		{
			var time = span.TotalMinutes >= 60 ? String.Format("{0}h, {1}m", Math.Floor(span.TotalHours), span.Minutes)
											   : String.Format("{0}m", span.Minutes);

			if (maxMinitsAlert != 0)//only for break time that has max mininum
				if ((int)span.TotalMinutes > maxMinitsAlert)
					time += " <i class='fa fa-warning color-yellow'>";

			return time;
		}
		catch (Exception)
		{
			return "--";
		}
	}

	public static DateTime ConverPersina2Miladi(this string Persian, int hour, int min)
	{
		Persian = Persian.Fa2En();

		var Date = new DateTime();

		if (Persian != "" && Persian.IsPersianDate()) { }
		// i changed it
		//Date = Persia.Calendar.ConvertToGregorian(Persian.JodaKonDate()[0], Persian.JodaKonDate()[1], Persian.JodaKonDate()[2], hour, min, 0, 0);
		else
			Date = DateTime.Now;
		return Date;
	}

	public static bool isFillDateText(this string dateText)
	{
		if (dateText.Replace("/", "").Length == 8)
			return true;
		else
			return false;
	}

	public static DateTime SystemTime(this DateTime time)
	{
		try
		{
			//America/Los_Angeles
			TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
			return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeInfo);
		}
		catch (Exception ex)
		{
			return DateTime.Now;
		}
	}

	public static DateTime FirstOfMonth(this DateTime time)
	{
		try
		{
			return new DateTime(time.Year, time.Month, 1, 0, 0, 0, 0);
		}
		catch (Exception ex)
		{
			return time;
		}
	}

	public static DateTime LastOfMonth(this DateTime time)
	{
		try
		{
			return new DateTime(time.Year, time.Month + 1, 1, 0, 0, 0, 0).AddDays(-1);
		}
		catch (Exception ex)
		{
			return time;
		}
	}

	public static DateTime SystemTimeConvert(this DateTime time)
	{
		try
		{
			//America/Los_Angeles
			TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById(System.Configuration.ConfigurationManager.AppSettings["TimeZone"]);
			return TimeZoneInfo.ConvertTimeFromUtc(time, timeInfo);
		}
		catch (Exception ex)
		{
			return DateTime.Now;
		}
	}

	public enum ImageComperssion
	{
		Maximum = 50,
		Good = 60,
		Normal = 70,
		Fast = 80,
		Minimum = 90,
	}

	public static Stream ToStream(this System.Drawing.Image image, ImageFormat format)
	{
		var stream = new System.IO.MemoryStream();
		image.Save(stream, format);
		stream.Position = 0;
		return stream;
	}

	public static void ResizeImage(this Stream inputStream, int width, int height, string savePath, ImageComperssion ic = ImageComperssion.Normal)
	{
		System.Drawing.Image img = new Bitmap(inputStream);
		System.Drawing.Image result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
		using (Graphics g = Graphics.FromImage(result))
		{
			g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			g.DrawImage(img, 0, 0, width, height);
		}
		result.CompressImage(savePath, ic);
	}

	public static void ResizeImage(this System.Drawing.Image img, int width, int height, string savePath, ImageComperssion ic = ImageComperssion.Normal)
	{
		System.Drawing.Image result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
		using (Graphics g = Graphics.FromImage(result))
		{
			g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			g.DrawImage(img, 0, 0, width, height);
		}
		result.CompressImage(savePath, ic);
	}

	public static void ResizeImageByWidth(this Stream inputStream, int width, string savePath, ImageComperssion ic = ImageComperssion.Normal)
	{
		System.Drawing.Image img = new Bitmap(inputStream);
		int height = img.Height * width / img.Width;
		System.Drawing.Image result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
		using (Graphics g = Graphics.FromImage(result))
		{
			g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			g.DrawImage(img, 0, 0, width, height);
		}
		result.CompressImage(savePath, ic);
	}

	public static void ResizeImageByWidth(this System.Drawing.Image img, int width, string savePath, ImageComperssion ic = ImageComperssion.Normal)
	{
		int height = img.Height * width / img.Width;
		System.Drawing.Image result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
		using (Graphics g = Graphics.FromImage(result))
		{
			g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			g.DrawImage(img, 0, 0, width, height);
		}
		result.CompressImage(savePath, ic);
	}

	public static void ResizeImageByHeight(this Stream inputStream, int height, string savePath, ImageComperssion ic = ImageComperssion.Normal)
	{
		System.Drawing.Image img = new Bitmap(inputStream);
		int width = img.Width * height / img.Height;
		System.Drawing.Image result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
		using (Graphics g = Graphics.FromImage(result))
		{
			g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			g.DrawImage(img, 0, 0, width, height);
		}
		result.CompressImage(savePath, ic);
	}

	public static void ResizeImageByHeight(this System.Drawing.Image img, int height, string savePath, ImageComperssion ic = ImageComperssion.Normal)
	{
		int width = img.Width * height / img.Height;
		System.Drawing.Image result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
		using (Graphics g = Graphics.FromImage(result))
		{
			g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			g.DrawImage(img, 0, 0, width, height);
		}
		result.CompressImage(savePath, ic);
	}

	public static void CompressImage(this System.Drawing.Image img, string path, ImageComperssion ic)
	{
		System.Drawing.Imaging.EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Convert.ToInt32(ic));
		ImageFormat format = img.RawFormat;
		ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == format.Guid);
		string mimeType = codec == null ? "image/jpeg" : codec.MimeType;
		ImageCodecInfo jpegCodec = null;
		ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
		for (int i = 0; i < codecs.Length; i++)
		{
			if (codecs[i].MimeType == mimeType)
			{
				jpegCodec = codecs[i];
				break;
			}
		}
		EncoderParameters encoderParams = new EncoderParameters(1);
		encoderParams.Param[0] = qualityParam;
		img.Save(path, jpegCodec, encoderParams);
	}

	public static string GetErrors(this ModelStateDictionary modelState)
	{
		return string.Join("<br />", (from item in modelState
									  where item.Value.Errors.Any()
									  select item.Value.Errors[0].ErrorMessage).ToList());
	}

	public static string ToLowerFirst(this string str)
	{
		return str.Substring(0, 1).ToLower() + str.Substring(1);
	}

	public static bool Like(this string s, string pattern)
	{
		//Find the pattern anywhere in the string
		pattern = ".*" + pattern + ".*";

		return Regex.IsMatch(s, pattern, RegexOptions.IgnoreCase);
	}

	public static DataTable ToDataTable<T>(this IEnumerable<T> data, string TableName = "myData")
	{
		PropertyDescriptorCollection props =
		 TypeDescriptor.GetProperties(typeof(T));
		DataTable table = new DataTable();
		for (int i = 0; i < props.Count; i++)
		{
			PropertyDescriptor prop = props[i];
			if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
				table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
			else
				table.Columns.Add(prop.Name, prop.PropertyType);
		}
		object[] values = new object[props.Count];
		foreach (T item in data)
		{
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = props[i].GetValue(item);
			}
			table.Rows.Add(values);
		}
		return table;
	}

	public static string RemoveJsonProperty(this string jsonDate, string property)
	{
		try
		{
			JObject temp = JObject.Parse(jsonDate);
			temp.Descendants()
				.OfType<JProperty>()
				.Where(attr => attr.Name.Contains(property))
				.ToList() // you should call ToList because you're about to changing the result, which is not possible if it is IEnumerable
				.ForEach(attr => attr.Remove()); // removing unwanted attributes
			jsonDate = temp.ToString();
			return jsonDate;
		}
		catch (Exception ex)
		{
			return jsonDate;
		}
	}

	public static string ResponsiveMode(this string text, int length)
	{
		try
		{
			char[] charArr = text.ToCharArray();

			int breaknumber = text.Count() / length;
			bool setBreak = false;
			for (int i = 0; i < charArr.Count(); i++)
			{
				if (i == 0)
					continue;

				if (i % length == 0)
					setBreak = true;

				if (text[i] == ',' & setBreak)
				{
					charArr[i] = '\r';
					setBreak = false;
				}
			}
			var finalText = new string(charArr).Replace("\r", ",\r\n");

			return finalText;
		}
		catch (Exception ex)
		{
			return text;
		}
	}

	public static object GetPropValue(object src, string propName)
	{
		return src.GetType().GetProperty(propName).GetValue(src, null);
	}

	public static List<long> ConvertListStr2Int64(this string[] List)
	{
		try
		{
			List<long> LongList = new List<long>();
			foreach (var item in List)
			{
				try
				{
					LongList.Add(Int64.Parse(item));
				}
				catch { }
			}
			return LongList;
		}
		catch (Exception ex)
		{
			return new List<long>();
		}
	}

	public static List<int> ConvertListStr2Int32(this string[] List)
	{
		try
		{
			List<int> LongList = new List<int>();
			foreach (var item in List)
			{
				try
				{
					LongList.Add(Int32.Parse(item));
				}
				catch { }
			}
			return LongList;
		}
		catch (Exception ex)
		{
			return new List<int>();
		}
	}

	public static string ToPersianDateTime(this DateTime dt, string format = null)
	{
		try
		{
			PersianCalendar pc = new PersianCalendar();
			int Year = pc.GetYear(dt);
			int Month = pc.GetMonth(dt);
			int Day = pc.GetDayOfMonth(dt);
			int Hour = pc.GetHour(dt);
			int Minute = pc.GetMinute(dt);
			DateTime PDT = new DateTime(Year, Month, Day, Hour, Minute, 0);
			if (format == null)
				return PDT.ToString("MM/dd/yyyy hh:mm:tt");
			else
				return PDT.ToString(format);
		}
		catch (Exception ex)
		{
			// i changed it
			//return Persia.Calendar.ConvertToPersian(dt).ToString();
			return "Error!!!";
		}
	}

	public static string ToPersianDate(this DateTime dt)
	{
		try
		{
			PersianCalendar pc = new PersianCalendar();
			int Year = pc.GetYear(dt);
			int Month = pc.GetMonth(dt);
			int Day = pc.GetDayOfMonth(dt);
			int Hour = pc.GetHour(dt);
			int Minute = pc.GetMinute(dt);
			DateTime PDT = new DateTime(Year, Month, Day, 0, 0, 0);

			return PDT.ToString("MM/dd/yyyy");
		}
		catch (Exception ex)
		{
			// i changed it
			//return Persia.Calendar.ConvertToPersian(dt).ToString("D");
			return "Error!!!";
		}
	}

	public static List<int> ConvertCharacterListStr2Int32(this string List)
	{
		try
		{
			List<int> LongList = new List<int>();
			foreach (var item in List.Split(','))
			{
				try
				{
					LongList.Add(Int32.Parse(item));
				}
				catch { }
			}
			return LongList;
		}
		catch (Exception ex)
		{
			return new List<int>();
		}
	}

	public static List<long> ConvertCharacterListStr2Int64(this string List)
	{
		try
		{
			List<long> LongList = new List<long>();
			foreach (var item in List.Split(','))
			{
				try
				{
					LongList.Add(Int64.Parse(item));
				}
				catch { }
			}
			return LongList;
		}
		catch (Exception ex)
		{
			return new List<long>();
		}
	}

	public static string ConverTosmsPanelDateTime(this string dateTime, bool Value)//value=True=>StartDate,Value=False=>EndDate
	{
		dateTime = dateTime.Fa2En();
		if (dateTime != "" && dateTime.IsPersianDate())
		{
			// i changed it
			//var Date = Persia.Calendar.ConvertToGregorian(dateTime.JodaKonDate()[0], dateTime.JodaKonDate()[1], dateTime.JodaKonDate()[2], 0);
			var Date = "";
			string GregorianDate = Date.ToString();
			DateTime d = DateTime.Parse(GregorianDate);
			PersianCalendar pc = new PersianCalendar();
			dateTime = (string.Format("{0}/{1}/{2} {3}:{4}:{5}", pc.GetYear(d).FixFormat(4), pc.GetMonth(d).FixFormat(2), pc.GetDayOfMonth(d).FixFormat(2), "01", "01", "01"));
		}
		else
		{
			dateTime = Value ? "1350/01/01 00:01:01" : "1500/01/01 23:59:59";
		}
		return dateTime;
	}

	public static DateTime ToDatePersian(this DateTime dt)
	{
		PersianCalendar pc = new PersianCalendar();
		int Year = pc.GetYear(dt);
		int Month = pc.GetMonth(dt);
		int Day = pc.GetDayOfMonth(dt);
		int Hour = pc.GetHour(dt);
		int Minute = pc.GetMinute(dt);
		DateTime PDT = new DateTime(Year, Month, Day);
		return PDT;
	}

	public static bool IsProjectShowPlaceOrderButton(this DateTime PlaceOrderDate, DateTime ProjectDate, double PaidPrice, double minPercent, double secoundPercent)
	{
		try
		{
			var res = PlaceOrderDate == ProjectDate & PaidPrice == 0 & minPercent == 0 & secoundPercent == 100;

			return res;
		}
		catch (Exception ex)
		{
			return false;
		}
	}

	public static bool IsProjectHasPaymentOrPlaceOrder(this DateTime PlaceOrderDate, DateTime ProjectDate, double PaidPrice)
	{
		try
		{
			var res = PlaceOrderDate > ProjectDate || PaidPrice > 0;

			return res;
		}
		catch (Exception ex)
		{
			return false;
		}
	}

	public static bool IsProjectShowPlaceOrderButton(this FactorEnt Project)
	{
		return Project.PlaceOrderDate.IsProjectShowPlaceOrderButton(Project.Date, Project.PaidPrice, Project.MinimumPaymentPercent, Project.SecondPaymentPercent);
	}

	public static bool IsProjectHasPaymentOrPlaceOrder(this FactorEnt Project)
	{
		return Project.PlaceOrderDate.IsProjectHasPaymentOrPlaceOrder(Project.Date, Project.PaidPrice);
	}

	public static DateTime ToDateMiladi(this DateTime dt)
	{
		PersianCalendar pc = new PersianCalendar();
		return pc.ToDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0, 0);
	}

	public static T CastTo<T>(this object obj)
	{
		return (T)obj;
	}

	#region Validation

	//آیا ایمیل است؟
	public static bool IsEmail(this string str)
	{
		return Regex.IsMatch(str, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
	}

	public static bool isIranianPhoneNumber(this string str)
	{
		if (str == null)
			return false;

		return Regex.IsMatch(str, @"(0|\+98)?([ ]|,|-|[()]){0,2}9[0|1|2|3|4]([ ]|,|-|[()]){0,2}(?:[0-9]([ ]|,|-|[()]){0,2}){8}");
	}

	//آیا آدرس است؟
	public static bool IsUrl(this string str)
	{
		return Regex.IsMatch(str, @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
		//return Regex.IsMatch(str, @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?");
	}

	//آیا موبایل است؟
	public static bool IsMobile(this string str)
	{
		return Regex.IsMatch(str, @"^(((\+|00)98)|0)?9[123]\d{8}$");
	}

	//آیا زمان 12 ساعته است؟
	public static bool IsTimeSpan12(this string str)
	{
		return Regex.IsMatch(str, @"^(1[012]|[1-9]):([0-5]?[0-9]) (AM|am|PM|pm)$");
	}

	//آیا زمان 12 ساعته فارسی است؟
	public static bool IsTimeSpan12P(this string str)
	{
		return Regex.IsMatch(str, @"^(1[012]|[1-9]):([0-5]?[0-9]) (ق ظ|ق.ظ|ب ظ|ب.ظ)$");
	}

	//آیا زمان 24 ساعته است؟
	//01:24
	public static bool IsTimeSpan24hhm(this string str)
	{
		return Regex.IsMatch(str, @"^([01][0-9]|2[0-3]):([0-5]?[0-9])$");
	}

	//آیا زمان 24 ساعته است؟
	//1:24
	public static bool IsTimeSpan24hm(this string str)
	{
		return Regex.IsMatch(str, @"^(2[0-3]|[01]?\d):([0-5]?[0-9])$");
	}

	//آیا تاریخ شمسی و ساعت است؟
	//مثال
	// 1394/01/01 01:01
	// 94/01/01 01:01
	// 94/1/01 01:01
	// 94/1/1 01:01
	// 94/1/1 1:01
	// 94/1/1 1:1
	public static bool IsPersianDateTime(this string str)
	{
		return Regex.IsMatch(str, @"^(13\d{2}|[1-9]\d)/(1[012]|0?[1-9])/([12]\d|3[01]|0?[1-9]) ([01][0-9]|2[0-3]):([0-5]?[0-9])$");
	}

	//زمان صحیح است؟
	public static bool IsTime(this string str)
	{
		return Regex.IsMatch(str, @"^([01][0-9]|2[0-3]):([0-5]?[0-9])$");
	}

	//تاریخ شمسی کامل است؟
	public static bool IsPersianDate(this string str)
	{
		return Regex.IsMatch(str.Fa2En(), @"^(13\d{2}|[1-9]\d)/(1[012]|0?[1-9])/([12]\d|3[01]|0?[1-9])$");
	}

	//تاریخ شمسی کامل است؟
	public static bool IsPersianDate2(this string str)
	{
		return Regex.IsMatch(str, @"^(13\d{2})/(1[012]|0?[1-9])/([12]\d|3[01]|0?[1-9])$");
	}

	//آیا تاریخ ماه شمسی است؟
	public static bool IsPersianMonthDate(this string str)
	{
		return Regex.IsMatch(str, @"^(13\d{2}|[1-9]\d)/(1[012]|0?[1-9])$");
	}

	//آیا Unicode است؟
	public static bool IsUnicode(this string str)
	{
		return str.Any(ch => (int)ch > 255);
	}

	//آیا عددی است؟ (تعداد کاراکتر نا محدود)
	public static bool IsDigit(this string str)
	{
		try
		{
			return str.All(char.IsDigit);
		}
		catch
		{
			return false;
		}
	}

	//آیا Int است؟
	public static bool IsInt(this string str)
	{
		try
		{
			Convert.ToInt32(str.Replace(",", ""));
			return true;
		}
		catch
		{
			return false;
		}
	}

	//آیا Byte است؟
	public static bool IsByte(this string str)
	{
		try
		{
			Convert.ToByte(str);
			return true;
		}
		catch
		{
			return false;
		}
	}

	//آیا Decimal است؟
	public static bool IsDecimal(this string str)
	{
		try
		{
			Convert.ToDecimal(str.Replace('/', '.'));
			return true;
		}
		catch
		{
			return false;
		}
	}

	//آیا ساعت زمان است؟
	public static bool IsTimeSpan(this string str)
	{
		TimeSpan ts;
		return System.TimeSpan.TryParse(str, out ts);
	}

	//آیا کد ملی است؟
	public static bool IsNationalCode(this string nationalcode)
	{
		if (string.IsNullOrEmpty(nationalcode)) return false;
		if (!new Regex(@"\d{10}").IsMatch(nationalcode)) return false;
		var array = nationalcode.ToCharArray();
		var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
		if (allDigitEqual.Contains(nationalcode)) return false;
		var j = 10;
		var sum = 0;
		for (var i = 0; i < array.Length - 1; i++)
		{
			sum += Int32.Parse(array[i].ToString(CultureInfo.InvariantCulture)) * j;
			j--;
		}
		var div = sum / 11;
		var r = div * 11;
		var diff = Math.Abs(sum - r);
		if (diff <= 2)
		{
			return diff == Int32.Parse(array[9].ToString(CultureInfo.InvariantCulture));
		}
		var temp = Math.Abs(diff - 11);
		return temp == Int32.Parse(array[9].ToString(CultureInfo.InvariantCulture));
	}

	//آیا کدملی است؟ + نمایش خروجی
	public static bool IsNationalCode(this string nationalcode, out string msg)
	{
		try
		{
			var chArray = nationalcode.Trim().ToCharArray();
			var numArray = new int[chArray.Length];
			for (var i = 0; i < chArray.Length; i++)
			{
				numArray[i] = (int)char.GetNumericValue(chArray[i]);
			}
			var num2 = numArray[9];
			switch (nationalcode.Trim())
			{
				case "0000000000":
				case "1111111111":
				case "22222222222":
				case "33333333333":
				case "4444444444":
				case "5555555555":
				case "6666666666":
				case "7777777777":
				case "8888888888":
				case "9999999999":
					msg = "کد ملی وارد شده صحیح نمی باشد";
					return false;
			}
			var num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
			var num4 = num3 - ((num3 / 11) * 11);
			if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs(num4 - 11))))
			{
				msg = "کد ملی صحیح می باشد";
				return true;
			}
			else
			{
				msg = "کد ملی نامعتبر است";
				return false;
			}
		}
		catch (Exception)
		{
			msg = "لطفا یک عدد 10 رقمی وارد کنید";
			return false;
		}
	}

	//آیا پسورد قوی است؟
	public static bool IsStrongPassword(this string str)
	{
		var isStrong = Regex.IsMatch(str, @"[\d]");
		if (isStrong) isStrong = Regex.IsMatch(str, @"[a-z]");
		if (isStrong) isStrong = Regex.IsMatch(str, @"[A-Z]");
		if (isStrong) isStrong = Regex.IsMatch(str, @"[\s~!@#\$%\^&\*\(\)\{\}\|\[\]\\:;'?,.`+=<>\/]");
		if (isStrong) isStrong = str.Length >= 6;
		return isStrong;
	}

	//آیا پسورد قوی است؟ + نمایش پیام خروجی
	public static bool IsStrongPassword(this string str, out string message)
	{
		message = "رمز عبور دارای امنیت بالایی می باشد";
		if (!Regex.IsMatch(str, @"[\d]"))
		{
			message = "رمز عبور باید شامل عدد باشد";
			return false;
		}
		if (!Regex.IsMatch(str, @"[aA-zZ]"))
		{
			message = "رمز عبور باید شامل حروف انگلیسی باشد";
			return false;
		}
		if (str.Length < 6)
		{
			message = "رمز عبور باید 6 کاراکتر به بالا باشد";
			return false;
		}
		return true;

		//message = "پسورد دارای امنیت بالایی می باشد";
		//if (!Regex.IsMatch(str, @"[\d]"))
		//{
		//    message = "رمز عبور باید شامل عدد باشد";
		//    return false;
		//}
		//if (!Regex.IsMatch(str, @"[a-z]"))
		//{
		//    message = "رمز عبور باید شامل حروف انگلیسی کوچک باشد";
		//    return false;
		//}
		//if (!Regex.IsMatch(str, @"[A-Z]"))
		//{
		//    message = "رمز عبور باید شامل حروف انگلیسی بزرگ باشد";
		//    return false;
		//}
		//if (!Regex.IsMatch(str, @"[\s~!@#\$%\^&\*\(\)\{\}\|\[\]\\:;'?,.`+=<>\/]"))
		//{
		//    message = "رمز عبور باید شامل کاراکتر های خاص ( ~ ? ! @ # $ % ^ & * , ... ) باشد";
		//    return false;
		//}
		//if (str.Length < 6)
		//{
		//    message = "رمز عبور باید 6 کاراکتر به بالا باشد";
		//    return false;
		//}
		//return true;
	}

	//آیا متن فارسی است؟
	public static bool IsFarsi(this string Str)
	{
		//char[] AllowChr = new char[47] { 'آ', 'ا', 'ب', 'پ', 'ت', 'ث', 'ج', 'چ', 'ح', 'خ', 'د', 'ذ', 'ر', 'ز', 'ژ', 'س', 'ش', 'ص', 'ض', 'ط', 'ظ', 'ع', 'غ', 'ف', 'ق', 'ک', 'گ', 'ل', 'ا', 'ن', 'و', 'ه', 'ی', 'ة', 'ي', 'ؤ', 'إ', 'أ', 'ء', 'ئ', 'ۀ', ' ', 'ك', 'ﮎ', 'ﮏ', 'ﮐ', 'ﮑ' };
		var AllowChar = new[] { 1590, 1589, 1579, 1602, 1601, 1594, 1593, 1607, 1582, 1581, 1580, 1670, 1662, 1588, 1587, 1740, 1576, 1604, 1575, 1578, 1606, 1605, 1705, 1711, 1592, 1591, 1586, 1585, 1584, 1583, 1574, 1608, 1577, 1610, 1688, 1572, 1573, 1571, 1569, 1570, 1728, 32, 1603, 64398, 64399, 64400, 64401 };
		return Str.Select(item => (int)item).All(AllowChar.Contains);
	}

	//آیا پسوند فایل تصویر است؟
	public static bool IsImageExt(this string fileName)
	{
		var exts = new[] { ".jpeg", ".jpg", ".png", ".bmp", ".gif", ".tif", ".tiff" };
		var ext = Path.GetExtension(fileName).ToLower();
		return Array.IndexOf(exts, ext) != -1;
	}

	//public static void ToFile(this FileResult fileResult, string fileName)
	//{
	//    if (fileResult is FileContentResult)
	//    {
	//        File.WriteAllBytes(fileName, ((FileContentResult)fileResult).FileContents);
	//    }
	//    else if (fileResult is FilePathResult)
	//    {
	//        File.Copy(((FilePathResult)fileResult).FileName, fileName, true); //overwrite file if it already exists
	//    }
	//    else if (fileResult is FileStreamResult)
	//    {
	//        //from http://stackoverflow.com/questions/411592/how-do-i-save-a-stream-to-a-file-in-c
	//        using (var fileStream = File.Create(fileName))
	//        {
	//            var fileStreamResult = (FileStreamResult)fileResult;
	//            fileStreamResult.FileStream.Seek(0, SeekOrigin.Begin);
	//            fileStreamResult.FileStream.CopyTo(fileStream);
	//            fileStreamResult.FileStream.Seek(0, SeekOrigin.Begin); //reset position to beginning. If there's any chance the FileResult will be used by a future method, this will ensure it gets left in a usable state - Suggestion by Steven Liekens
	//        }
	//    }
	//    else
	//    {
	//        throw new ArgumentException("Unsupported FileResult type");
	//    }
	//}

	#endregion Validation

	#region DateTime

	//تصحیح تاریخ به نوع استاندارد
	public static string FixDateTime(this string text)
	{
		string result;
		string year;
		string month;
		var day = "00";
		string hour;
		string min;
		var sec = "00";
		var arr = text.Split(' ');

		if (arr.Length == 1)
		{
			if (arr[0].Contains('/'))
			{
				//only date
				var arr2 = arr[0].Split('/');
				if (arr2.Length == 2)
				{
					//has year
					if (arr2[0].Length == 2)//92
						year = "13" + arr2[0];
					else if (arr2[0].Length == 4)//1392
						year = arr2[0];
					else
						throw new FormatException();

					//has month
					if (arr2[1].Length == 1)//9
						month = "0" + arr2[1];
					else if (arr2[1].Length == 2)//09
						month = arr2[1];
					else
						throw new FormatException();
				}
				else if (arr2.Length == 3)
				{
					//has year
					if (arr2[0].Length == 2)//92
						year = "13" + arr2[0];
					else if (arr2[0].Length == 4)//1392
						year = arr2[0];
					else
						throw new FormatException();

					//has month
					if (arr2[1].Length == 1)//9
						month = "0" + arr2[1];
					else if (arr2[1].Length == 2)//09
						month = arr2[1];
					else
						throw new FormatException();

					//has day
					if (arr2[2].Length == 1)//5
						day = "0" + arr2[2];
					else if (arr2[2].Length == 2)//05
						day = arr2[2];
					else
						throw new FormatException();
				}
				else
				{
					throw new FormatException();
				}
				result = year + "/" + month + "/" + day;
			}
			else if (arr[0].Contains(':'))
			{
				//only time
				var arr3 = arr[0].Split(':');
				if (arr3.Length == 2)
				{
					//has hour
					if (arr3[0].Length == 1)//2
						hour = "0" + arr3[0];
					else if (arr3[0].Length == 2)//02
						hour = arr3[0];
					else
						throw new FormatException();

					//has min
					if (arr3[1].Length == 1)//8
						min = "0" + arr3[1];
					else if (arr3[1].Length == 2)//08
						min = arr3[1];
					else
						throw new FormatException();
				}
				else if (arr3.Length == 3)
				{
					//has hour
					if (arr3[0].Length == 1)//2
						hour = "0" + arr3[0];
					else if (arr3[0].Length == 2)//02
						hour = arr3[0];
					else
						throw new FormatException();

					//has min
					if (arr3[1].Length == 1)//8
						min = "0" + arr3[1];
					else if (arr3[1].Length == 2)//08
						min = arr3[1];
					else
						throw new FormatException();

					//has sec
					if (arr3[2].Length == 1)//1
						sec = "0" + arr3[2];
					else if (arr3[2].Length == 2)//01
						sec = arr3[2];
					else
						throw new FormatException();
				}
				else
				{
					throw new FormatException();
				}
				result = hour + ":" + min + ":" + sec;
			}
			else
			{
				throw new FormatException();
			}
		}
		else if (arr.Length == 2)
		{
			//has date
			var arr2 = arr[0].Split('/');
			if (arr2.Length == 2)
			{
				//has year
				if (arr2[0].Length == 2)//92
					year = "13" + arr2[0];
				else if (arr2[0].Length == 4)//1392
					year = arr2[0];
				else
					throw new FormatException();

				//has month
				if (arr2[1].Length == 1)//9
					month = "0" + arr2[1];
				else if (arr2[1].Length == 2)//09
					month = arr2[1];
				else
					throw new FormatException();
			}
			else if (arr2.Length == 3)
			{
				//has year
				if (arr2[0].Length == 2)//92
					year = "13" + arr2[0];
				else if (arr2[0].Length == 4)//1392
					year = arr2[0];
				else
					throw new FormatException();

				//has month
				if (arr2[1].Length == 1)//9
					month = "0" + arr2[1];
				else if (arr2[1].Length == 2)//09
					month = arr2[1];
				else
					throw new FormatException();

				//has day
				if (arr2[2].Length == 1)//5
					day = "0" + arr2[2];
				else if (arr2[2].Length == 2)//05
					day = arr2[2];
				else
					throw new FormatException();
			}
			else
			{
				throw new FormatException();
			}

			//has time
			var arr3 = arr[1].Split(':');
			if (arr3.Length == 2)
			{
				//has hour
				if (arr3[0].Length == 1)//2
					hour = "0" + arr3[0];
				else if (arr3[0].Length == 2)//02
					hour = arr3[0];
				else
					throw new FormatException();

				//has min
				if (arr3[1].Length == 1)//8
					min = "0" + arr3[1];
				else if (arr3[1].Length == 2)//08
					min = arr3[1];
				else
					throw new FormatException();
			}
			else if (arr3.Length == 3)
			{
				//has hour
				if (arr3[0].Length == 1)//2
					hour = "0" + arr3[0];
				else if (arr3[0].Length == 2)//02
					hour = arr3[0];
				else
					throw new FormatException();

				//has min
				if (arr3[1].Length == 1)//8
					min = "0" + arr3[1];
				else if (arr3[1].Length == 2)//08
					min = arr3[1];
				else
					throw new FormatException();

				//has sec
				if (arr3[2].Length == 1)//1
					sec = "0" + arr3[2];
				else if (arr3[2].Length == 2)//01
					sec = arr3[2];
				else
					throw new FormatException();
			}
			else
			{
				throw new FormatException();
			}
			result = year + "/" + month + "/" + day + " " + hour + ":" + min + ":" + sec;
		}
		else
		{
			throw new FormatException();
		}
		return result;
	}

	//نمایش تاریخ : 1394/01/01 3:30 PM
	public static string ToStringDateTime12(this DateTime DT)
	{
		return DT.ToString("MM/dd/yyyy hh:mm tt");
	}

	//نمایش تاریخ : 1394/01/01 15:30
	public static string ToStringDateTime24(this DateTime DT)
	{
		return DT.ToString("MM/dd/yyyy HH:mm");
	}

	//نمایش تاریخ : 1394/01/01
	public static string ToStringDate(this DateTime DT)
	{
		return DT.ToString("MM/dd/yyyy");
	}

	//نمایش تاریخ : 1394/01/01 3:30 ب.ظ
	public static string ToStringDateTime12P(this DateTime DT)
	{
		//return DT.ToString("MM/dd/yyyy hh:mm tt").Replace("AM", "ق.ظ").Replace("PM", "ب.ظ");
		var hh = DT.ToString("HH");
		var tt = hh.ToInt() < 12 ? "ق.ظ" : "ب.ظ";
		return DT.ToString("yyyy/M/d h:mm " + tt);
	}

	//نمایش تاریخ : 1 فروردین 1394
	public static string ToStringShamsiDate(this DateTime dt)
	{
		var PC = new PersianCalendar();
		var intYear = PC.GetYear(dt);
		var intMonth = PC.GetMonth(dt);
		var intDayOfMonth = PC.GetDayOfMonth(dt);
		string strMonthName;
		var strDayName = "";
		switch (intMonth)
		{
			case 1:
				strMonthName = "فروردین";
				break;

			case 2:
				strMonthName = "اردیبهشت";
				break;

			case 3:
				strMonthName = "خرداد";
				break;

			case 4:
				strMonthName = "تیر";
				break;

			case 5:
				strMonthName = "مرداد";
				break;

			case 6:
				strMonthName = "شهریور";
				break;

			case 7:
				strMonthName = "مهر";
				break;

			case 8:
				strMonthName = "آبان";
				break;

			case 9:
				strMonthName = "آذر";
				break;

			case 10:
				strMonthName = "دی";
				break;

			case 11:
				strMonthName = "بهمن";
				break;

			case 12:
				strMonthName = "اسفند";
				break;

			default:
				strMonthName = "";
				break;
		}

		//switch (enDayOfWeek)
		//{
		//    case DayOfWeek.Friday:
		//        strDayName = "جمعه";
		//        break;
		//    case DayOfWeek.Monday:
		//        strDayName = "دوشنبه";
		//        break;
		//    case DayOfWeek.Saturday:
		//        strDayName = "شنبه";
		//        break;
		//    case DayOfWeek.Sunday:
		//        strDayName = "یکشنبه";
		//        break;
		//    case DayOfWeek.Thursday:
		//        strDayName = "پنجشنبه";
		//        break;
		//    case DayOfWeek.Tuesday:
		//        strDayName = "سه شنبه";
		//        break;
		//    case DayOfWeek.Wednesday:
		//        strDayName = "چهارشنبه";
		//        break;
		//    default:
		//        strDayName = "";
		//        break;
		//}

		return (string.Format("{0} {1} {2} {3}", strDayName, intDayOfMonth, strMonthName, intYear));
	}

	public static List<int> JodaKonDate(this string p)
	{
		p = p + "/";
		List<int> l = new List<int>();
		for (int i = 0; i < p.Count() - 1; i++)
		{
			int j = i;
			while (p[j] != '/') { j++; }
			l.Add(Int32.Parse(p.Substring(i, j - i)));
			i = j;
		}
		return l;
	}

	public static List<int> JodaKonDateTime(this string p)
	{
		p = p + "/";
		p = p.Replace(' ', '/');
		p = p.Replace(':', '/');
		List<int> l = new List<int>();
		for (int i = 0; i < p.Count() - 1; i++)
		{
			int j = i;
			while (p[j] != '/')
				j++;
			if (j > i)
				l.Add(Int32.Parse(p.Substring(i, j - i)));
			i = j;
		}
		return l;
	}

	#endregion DateTime

	#region Security

	//تبدیل متن به هش کد md5
	public static string ToMd5Hash(this string str)
	{
		if (string.IsNullOrEmpty(str)) return str;
		using (MD5 md5 = new MD5CryptoServiceProvider())
		{
			var originalBytes = ASCIIEncoding.Default.GetBytes(str);
			var encodedBytes = md5.ComputeHash(originalBytes);
			return BitConverter.ToString(encodedBytes).Replace("-", string.Empty);
		}
	}

	//تبدیل متن به هش کد mdf از نوع byte[]
	public static byte[] ToMd5HashByte(this string str)
	{
		using (MD5 md5 = new MD5CryptoServiceProvider())
		{
			var hashData = md5.ComputeHash(new UTF8Encoding().GetBytes(str));
			return hashData;
		}
	}

	//رمزنگاری متن
	public static string Encrypt(this string str)
	{
		var encData_byte = Encoding.UTF8.GetBytes(str);
		return Convert.ToBase64String(encData_byte);
	}

	//رمز گشایی متن رمز نگاری شده
	public static string Decrypt(this string str)
	{
		var encoder = new UTF8Encoding();
		var utf8Decode = encoder.GetDecoder();
		var todecode_byte = Convert.FromBase64String(str);
		var charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
		var decoded_char = new char[charCount];
		utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
		return new string(decoded_char);
	}

	#endregion Security

	#region Converter

	//جدا سازی اعداد به صورت سه کاراکتری جهت نمایش قیمت
	public static string ToPrice(this object dec, int showDecimal = 2)
	{
		if (dec == null)
			return "";
		var Src = dec.ToString();
		Src = Src.Replace(".0000", "");
		if (!Src.Contains("."))
		{
			Src = Src + ".00";
		}
		var price = Src.Split('.');
		if (price[1].Length >= 2)
		{
			price[1] = price[1].Substring(0, 2);
			price[1] = price[1].Replace("00", "");
		}

		string Temp = null;
		int i;
		if ((price[0].Length % 3) >= 1)
		{
			Temp = price[0].Substring(0, (price[0].Length % 3));
			for (i = 0; i <= (price[0].Length / 3) - 1; i++)
			{
				Temp += "," + price[0].Substring((price[0].Length % 3) + (i * 3), 3);
			}
		}
		else
		{
			for (i = 0; i <= (price[0].Length / 3) - 1; i++)
			{
				Temp += price[0].Substring((price[0].Length % 3) + (i * 3), 3) + ",";
			}
			Temp = Temp.Substring(0, Temp.Length - 1);
			// Temp = price(0)
			//If price(1).Length > 0 Then
			//    Return price(0) + "." + price(1)
			//End If
		}

		//show decimal number
		var decimalNumber = price[1].Length > 0 ? price[1] : "";
		for (int k = decimalNumber.Length; k < showDecimal; k++)
		{
			decimalNumber = decimalNumber + "0";
		}

		if (showDecimal == -1)
		{
			Temp = (Temp + "." + decimalNumber).Trim('.');
		}
		if (showDecimal > 0)
		{
			Temp = Temp + "." + decimalNumber.Substring(0, showDecimal);
		}
		return Temp;
	}

	//تبدیل اعداد انگلیسی به فارسی
	public static string En2Fa(this string str)
	{
		if (string.IsNullOrWhiteSpace(str)) return "";
		return str.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹").Replace("/", "/");
	}

	//تبدیل اعداد فارسی به انگلیسی
	public static string Fa2En(this string str)
	{
		if (string.IsNullOrWhiteSpace(str)) return "";
		return str.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9").Replace("/", "/")
			.Replace('\u06f0', '0').Replace('\u06f1', '1').Replace('\u06f2', '2').Replace('\u06f3', '3').Replace('\u06f4', '4').Replace('\u06f5', '5').Replace('\u06f6', '6').Replace('\u06f7', '7').Replace('\u06f8', '8').Replace('\u06f9', '9');
	}

	//تبدیل حروف عربی به فارسی
	public static string FixPersianChars(this string str)
	{
		return str.Replace("ﮎ", "ک").Replace("ﮏ", "ک").Replace("ﮐ", "ک").Replace("ﮑ", "ک").Replace("ك", "ک").Replace("ي", "ی");
	}

	//تبدیل عدد به متن فارسی
	public static string ToText(this int digit)
	{
		var txt = digit.ToString();
		var length = txt.Length;

		var a1 = new[] { "-", "یک", "دو", "سه", "چهار", "پنح", "شش", "هفت", "هشت", "نه" };
		var a2 = new[] { "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" };
		var a3 = new[] { "-", "ده", "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };
		var a4 = new[] { "-", "یک صد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفصد", "هشصد", "نهصد" };

		var result = "";
		var isDahegan = false;

		for (var i = 0; i < length; i++)
		{
			var character = txt[i].ToString();
			switch (length - i)
			{
				case 7://میلیون
					if (character != "0")
					{
						result += a1[Convert.ToInt32(character)] + " میلیون و ";
					}
					else
					{
						result = result.TrimEnd('و', ' ');
					}
					break;

				case 6://صدهزار
					if (character != "0")
					{
						result += a4[Convert.ToInt32(character)] + " و ";
					}
					else
					{
						result = result.TrimEnd('و', ' ');
					}
					break;

				case 5://ده هزار
					if (character == "1")
					{
						isDahegan = true;
					}
					else if (character != "0")
					{
						result += a3[Convert.ToInt32(character)] + " و ";
					}
					break;

				case 4://هزار
					if (isDahegan)
					{
						result += a2[Convert.ToInt32(character)] + " هزار و ";
						isDahegan = false;
					}
					else
					{
						if (character != "0")
						{
							result += a1[Convert.ToInt32(character)] + " هزار و ";
						}
						else
						{
							result = result.TrimEnd('و', ' ');
						}
					}
					break;

				case 3://صد
					if (character != "0")
					{
						result += a4[Convert.ToInt32(character)] + " و ";
					}
					break;

				case 2://ده
					if (character == "1")
					{
						isDahegan = true;
					}
					else if (character != "0")
					{
						result += a3[Convert.ToInt32(character)] + " و ";
					}
					break;

				case 1://یک
					if (isDahegan)
					{
						result += a2[Convert.ToInt32(character)];
						isDahegan = false;
					}
					else
					{
						if (character != "0") result += a1[Convert.ToInt32(character)];
						else result = result.TrimEnd('و', ' ');
					}
					break;
			}
		}
		return result;
	}

	public static string ToPaymentTermStr(this PaymentTerms term)
	{
		try
		{
			var str = "";

			switch (term)
			{
				case PaymentTerms.PP:
					str = "Partial Payment";
					break;

				case PaymentTerms.DOC:
					str = "Due on completion";
					break;

				case PaymentTerms.COD:
					str = "Cash on delivery";
					break;

				case PaymentTerms.EOM:
					str = "End of month";
					break;

				case PaymentTerms.PIA:
					str = "Payment in advance";
					break;

				case PaymentTerms.Net7:
					str = "Net 7";
					break;

				case PaymentTerms.Net10:
					str = "Net 10";
					break;

				case PaymentTerms.Net15:
					str = "Net 15";
					break;

				case PaymentTerms.Net30:
					str = "Net 30";
					break;

				case PaymentTerms.Net45:
					str = "Net 45";
					break;

				default:
					str = "None";
					break;
			}

			return str;
		}
		catch (Exception ex)
		{
			return "--";
		}
	}

	//تبدیل هر چیزی به نوع عددی int
	public static int ToInt(this object obj)
	{
		try
		{
			return Convert.ToInt32(obj.ToString().Replace(",", ""));
		}
		catch
		{
			return Convert.ToInt32(obj);
		}
	}

	public static PayType ToPayType(this string type)
	{
		try
		{
			if (type == "0" || type == "1")
				return PayType.ByCreadit;
			if (type == "2")
				return PayType.ACH;

			if (type == "3")
				return PayType.ByCHeck;
			if (type == "4")
				return PayType.Cach;
			if (type == "5")
				return PayType.ByAdmin;
			else
				return PayType.ByCreadit;
		}
		catch
		{
			return PayType.ByCreadit;
		}
	}

	public static string TaskTypeToString(this Infrastructure.Entity.FactorTaskType type)
	{
		try
		{
			switch (type)
			{
				case FactorTaskType.Task:
					return "Task";

				case FactorTaskType.Installation:
					return "Install";

				case FactorTaskType.Estimation:
					return "Estimat";

				case FactorTaskType.Other:
					return "Task";

				default:
					return "Task";
			}
		}
		catch
		{
			return "Task";
		}
	}

	public static AppoitmentType ToAppoitmentType(this string type)
	{
		if (string.IsNullOrEmpty(type))
			return AppoitmentType.Task;
		if (type.ToLower().Contains("estim"))
			return AppoitmentType.Estimation;
		else if (type.ToLower().Contains("install"))
			return AppoitmentType.Installation;
		else
			return AppoitmentType.Task;
	}

	public static string LinebreakToNewLine(this string str)
	{
		if (string.IsNullOrEmpty(str)) return str;
		return str.Replace("\r\n", "<br />");
	}

	public static string ShowFileType(this string url, string type)
	{
		try
		{
			if (url.Contains("jpg") || url.Contains("jpeg") || url.Contains("png"))
				return url;

			return url;
		}
		catch (Exception ex)
		{
			return url;
		}
	}

	//public static HttpResponseMessage ToHttpResponseMessage(this ApiJsonResult result, HttpRequestMessage request)
	//{
	//    try
	//    {
	//        var response = request.CreateResponse(result.code);
	//        if (result.developer_message == null & result.user_message != null) result.developer_message = result.user_message;

	//        response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json");
	//        return response;
	//    }
	//    catch (Exception ex)
	//    {
	//        var response = request.CreateResponse(HttpStatusCode.NoContent);
	//        var res = new ApiJsonResult()
	//        {
	//            code = 0,
	//            developer_message = ex.ToString(),
	//            user_message = "Error Please try again later",
	//            results = null
	//        };
	//        response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(res), Encoding.UTF8, "application/json");

	//        return response;
	//    }
	//}
	public static HttpResponseMessage ToHttpResponseMessageNotNull(this ApiJsonResult result, HttpRequestMessage request)
	{
		try
		{
			var response = new HttpResponseMessage
			{
				StatusCode = result.code,
				RequestMessage = request
			};

			if (result.developer_message == null & result.user_message != null) result.developer_message = result.user_message;
			if (result.results == null)
			{
				var newResult = new ApiJsonResultNotNull();
				newResult.code = result.code;
				newResult.developer_message = result.developer_message;
				newResult.user_message = result.user_message;
				response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(newResult), Encoding.UTF8, "application/json");
			}
			else
			{
				response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json");
			}

			return response;
		}
		catch (Exception ex)
		{
			var response = request.CreateResponse(HttpStatusCode.NoContent);
			var res = new ApiJsonResult()
			{
				code = 0,
				developer_message = ex.ToString(),
				user_message = "Error Please try again later",
				results = null
			};
			response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(res), Encoding.UTF8, "application/json");

			return response;
		}
	}

	public static HttpResponseMessage ToHttpResponseMessageNotNull(this ApiJsonResult result)
	{
		try
		{
			var response = new HttpResponseMessage();
			if (result.developer_message == null & result.user_message != null) result.developer_message = result.user_message;
			if (result.results == null)
			{
				var newResult = new ApiJsonResultNotNull();
				newResult.code = result.code;
				newResult.developer_message = result.developer_message;
				newResult.user_message = result.user_message;
				response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(newResult), Encoding.UTF8, "application/json");
			}
			else
			{
				response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json");
			}

			return response;
		}
		catch (Exception ex)
		{
			var response = new HttpResponseMessage();
			var res = new ApiJsonResult()
			{
				code = 0,
				developer_message = ex.ToString(),
				user_message = "Error Please try again later",
				results = null
			};
			response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(res), Encoding.UTF8, "application/json");

			return response;
		}
	}

	public static object ToJsonNotNull(this ApiJsonResult result)
	{
		try
		{
			if (result.developer_message == null & result.user_message != null) result.developer_message = result.user_message;
			if (result.results == null)
			{
				var newResult = new ApiJsonResultNotNull();
				newResult.code = result.code;
				newResult.developer_message = result.developer_message;
				newResult.user_message = result.user_message;

				return newResult;
			}
			else
			{
				return result;
			}

			//  return result;
		}
		catch (Exception ex)
		{
			var res = new ApiJsonResult()
			{
				code = 0,
				developer_message = ex.ToString(),
				user_message = "Error Please try again later",
				results = null
			};
			return res;
		}
	}

	public static bool ToBollian(this byte number)
	{
		try
		{
			if (number > 0)
				return true;
			else
				return false;
		}
		catch
		{
			return false;
		}
	}

	public static int TryToInt(this object obj)
	{
		try
		{
			return Convert.ToInt32(obj.ToString().Replace(",", ""));
		}
		catch
		{
			return 0;
		}
	}

	public static string ToTransactionStr(this TransactionType type)
	{
		try
		{
			var title = "";
			switch (type)
			{
				case TransactionType.Expense:
					title = "Expense";
					break;

				case TransactionType.Income:
					title = "Income";
					break;

				case TransactionType.Transfer:
					title = "Transfer";
					break;

				default:
					title = "--";
					break;
			}
			return title;
		}
		catch
		{
			return "--";
		}
	}

	public static string ToTransactionStrColory(this TransactionType type)
	{
		try
		{
			var title = "";
			switch (type)
			{
				case TransactionType.Expense:
					title = "<a href = 'javascript:;' class='btn btn-danger btn-xs float-right color-white'>Expense </a>";
					break;

				case TransactionType.Income:
					title = "<a href = 'javascript:;' class='btn btn-success btn-xs float-right color-white'>Income </a>";
					break;

				case TransactionType.Transfer:
					title = "<a href = 'javascript:;' class='btn btn-warning btn-xs float-right color-white'>Transfer </a>";
					break;

				default:
					title = "--";
					break;
			}
			return title;
		}
		catch
		{
			return "--";
		}
	}

	public static bool MobileMenuActive(this string Controller, string Action)
	{
		var disableMobileMenu = false;// Controller == "Factor" & Action == "Update"

		if (!disableMobileMenu) { disableMobileMenu = Controller == "Time" & Action == "MyTimeCards"; }
		//  if (!disableMobileMenu) { disableMobileMenu = Controller == "Report" & Action == "Reports"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Price" & Action == "Index"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Factor" & Action == "Add"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Factor" & Action == "EditShipping"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Report" & Action == "ReportExcel"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Admin" & Action == "TimeLine"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Plaid" & Action == "BankAccounts"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Item" & Action == "AddModifire"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Item" & Action == "ShowRequestAnswer"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Item" & Action == "ShowModifire"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Base" & Action == "Default"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Base" & Action == "EmailSetting"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Base" & Action == "PageViews"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Base" & Action == "SortedProject"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Base" & Action == "State"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Base" & Action == "Cities"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Base" & Action == "Vendors"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Base" & Action == "Shipping"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Base" & Action == "Status"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Base" & Action == "JobTypes"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "User" & Action == "EditProfile"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "User" & Action == "OperatorResetPassword"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Home" & Action == "PublicChat"; }
		//if (!disableMobileMenu) { disableMobileMenu = Controller == "Home" & Action == "Notification"; }

		return !disableMobileMenu;
	}

	public static string HideZero(this string text)
	{
		try
		{
			if (text == "0")
				return "";
			else
				return text;
		}
		catch
		{
			return text;
		}
	}

	public static string TrimStart(this string target, string trimString)
	{
		if (string.IsNullOrEmpty(trimString)) return target;

		string result = target;
		while (result.StartsWith(trimString))
		{
			result = result.Substring(trimString.Length);
		}

		return result;
	}

	public static JqGridData ToJqGridData(this object objList, int listCount, string page, string rowNumber)
	{
		try
		{
			return new JqGridData()
			{
				page = page,
				total = Math.Ceiling((double)listCount / rowNumber.ToInt()).ToString(),
				records = listCount.ToString(),
				rows = objList,
			};
		}
		catch
		{
			return new JqGridData()
			{
				rows = objList
			};
		}
	}

	public static double ZeroIfNegetive(this double number)
	{
		try
		{
			if (number >= 0)
				return number;
			else
				return 0;
		}
		catch
		{
			return 0;
		}
	}

	public static string ToGoogleMapURL(this string address)
	{
		try
		{
			if (address == null)
				return "";
			return "https://www.google.com/maps/search/?api=1&query=" + address.Replace(" ", "+").Replace(",", "%2C").Replace("|", "%7C");
		}
		catch
		{
			return address;
		}
	}

	public static string ToGoogleMap(this string address)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(address) || address.Trim(' ') == ",")
				return "";
			return "https://www.google.com/maps/search/?api=1&query=" + address;
		}
		catch
		{
			return address;
		}
	}

	public static string ToCodeColorLight(this string userColor)
	{
		try
		{
			switch (userColor)
			{
				case "bg-success":
					return "#85ca85";

				case "bg-info":
					return "#84d0e6";

				case "bg-warning":
					return "#f0ad4e";

				case "bg-primary2":
					return "#cdcdce";

				case "bg-info2":
					return "#0893ac";

				case "bg-warning2":
					return "#f7bc02";

				case "bg-success2":
					return "#34EE37";

				case "bg-primary3":
					return "#e310e0";

				case "bg-primary":
					return "#666666";

				default://bg-info
					return "#85ca85";
			}
		}
		catch
		{
			return "#85ca85";
		}
	}

	public static string ToCodeColor(this string userColor)
	{
		try
		{
			switch (userColor)
			{
				case "bg-success":
					return "#2f6a2f";

				case "bg-info":
					return "#1e7b94";

				case "bg-warning":
					return "#bc7410";

				case "bg-primary2":
					return "#98989a";

				case "bg-info2":
					return "#0893ac";

				case "bg-warning2":
					return "#f7bc02";

				case "bg-success2":
					return "#34EE37";

				case "bg-primary3":
					return "#a70ca4";

				case "bg-primary":
					return "#666666";

				default://bg-info
					return "#1f471f";
			}
		}
		catch
		{
			return "#85ca85";
		}
	}

	public static string ToProgress(this FactorStatus status)
	{
		try
		{
			int percent = 0;
			string progressColor = "default";
			if ((int)status == 1 | status == FactorStatus.OnlineOrder)
			{
				percent = 25;
				progressColor = "danger";
			}
			if ((int)status > 1 & (int)status < 16)
			{
				percent = 50;
				progressColor = "warning";
			}
			if ((int)status >= 16 & (int)status < 18)
			{
				percent = 75;
				progressColor = "info";
			}
			if ((int)status >= 18 & (int)status <= 30)
			{
				percent = 100;
				progressColor = "success";
			}
			if ((int)status == 32)
			{
				percent = 100;
				progressColor = "success";
			}
			if ((int)status >= 31 & (int)status <= 33)
			{
				percent = 100;
				progressColor = "success";
			}
			if ((int)status == 35)
			{
				percent = 50;
				progressColor = "warning";
			}

			var str = "<div class='progress progress-xxs margin-bottom-0'><div class='progress-bar progress-bar-" + progressColor + "' role='progressbar' aria-valuenow='" + percent + "' aria-valuemin='0' aria-valuemax='100' style='width: " + percent + "%; min-width: 2em;'><span class='sr-only'>" + percent + "% Complete</span></div></div>";
			return str;
		}
		catch
		{
			return "";
		}
	}

	public static string ToStatusCategoryProgress(this FactorStatus status)
	{
		try
		{
			var progressStatus = status.ToProgressStatus();
			string progressColor = progressStatus.ToColorClassName();
			var percent = 0;
			if (progressStatus == FactorProgressStatus.Lead)
				percent = 30;
			if (progressStatus == FactorProgressStatus.Job)
				percent = 60;
			if (progressStatus == FactorProgressStatus.Invoice)
				percent = 100;
			return "<div class='progress progress-xxs margin-bottom-0'><div class='progress-bar progress-bar-" + progressColor + "' role='progressbar' aria-valuenow='" + percent + "' aria-valuemin='0' aria-valuemax='100' style='width: " + percent + "%; min-width: 2em;'><span class='sr-only'>" + percent + "% Complete</span></div></div>";
		}
		catch
		{
			return "";
		}
	}

	public static FactorProgressStatus ToProgressStatus(this FactorStatus status)
	{
		if (status == FactorStatus.PreEstimation |
			status == FactorStatus.Estimation |
			status == FactorStatus.Estimate_Sent |
			status == FactorStatus.Measuring_Scheduled |
			status == FactorStatus.Quoted)
		{
			return FactorProgressStatus.Lead;
		}
		else if (status == FactorStatus.Recieved_deposit |
		  status == FactorStatus.Order_in_process |
		  status == FactorStatus.Order_Pending |
		   status == FactorStatus.Order_Confirmation |
		  status == FactorStatus.installation_delivery_Scheduled)
		{
			return FactorProgressStatus.Job;
		}
		else if (status == FactorStatus.Invoice_sent |
		status == FactorStatus.Paid_in_full |
		 status == FactorStatus.Close |
		status == FactorStatus.OnlineOrder)
		{
			return FactorProgressStatus.Invoice;
		}
		else
		{
			if ((int)status >= 0 & (int)status <= 9)
			{
				return FactorProgressStatus.Lead;
			}
			if ((int)status > 9 & (int)status < 20)
			{
				return FactorProgressStatus.Job;
			}

			if ((int)status >= 20 & (int)status <= 30)
			{
				return FactorProgressStatus.Invoice;
			}
		}
		return FactorProgressStatus.Unkhonw;
	}

	public static string ToColorClassName(this FactorProgressStatus status)
	{
		switch (status)
		{
			case FactorProgressStatus.Lead:
				return "danger";

			case FactorProgressStatus.Job:
				return "warning";

			case FactorProgressStatus.Invoice:
				return "success";

			case FactorProgressStatus.Unkhonw:
				return "default";

			default:
				return "default";
		}
	}

	public static string ToColorCode(this FactorProgressStatus status)
	{
		switch (status)
		{
			case FactorProgressStatus.Lead:
				return "#f1416c";

			case FactorProgressStatus.Job:
				return "#ffc700";

			case FactorProgressStatus.Invoice:
				return "#04c8c8";

			case FactorProgressStatus.Unkhonw:
				return "";

			default:
				return "default";
		}
	}

	public static string LeadColor(this FactorStatus sts)
	{
		if (sts.ToProgressStatus() == FactorProgressStatus.Lead) return sts.ToProgressStatus().ToColorClassName();
		else return "step-inactive";
	}

	public static string LeadColorCode(this FactorStatus sts)
	{
		if (sts.ToProgressStatus() == FactorProgressStatus.Lead) return sts.ToProgressStatus().ToColorCode();
		else return "step-inactive";
	}

	public static string JobColor(this FactorStatus sts)
	{
		if (sts.ToProgressStatus() == FactorProgressStatus.Job) return sts.ToProgressStatus().ToColorClassName();
		else return "step-inactive";
	}

	public static string JobColorCode(this FactorStatus sts)
	{
		if (sts.ToProgressStatus() == FactorProgressStatus.Job) return sts.ToProgressStatus().ToColorCode();
		else return "step-inactive";
	}

	public static string InvoiceColor(this FactorStatus sts)
	{
		if (sts.ToProgressStatus() == FactorProgressStatus.Invoice) return sts.ToProgressStatus().ToColorClassName();
		else return "step-inactive";
	}

	public static string InvoiceColorCode(this FactorStatus sts)
	{
		if (sts.ToProgressStatus() == FactorProgressStatus.Invoice) return sts.ToProgressStatus().ToColorCode();
		else return "step-inactive";
	}

	public static string MiniteToHoure(this double min)
	{
		try
		{
			TimeSpan span = TimeSpan.FromMinutes(min);

			var time = min >= 60 ? String.Format("{0}h, {1}m", Math.Floor(span.TotalHours), span.Minutes)
											  : String.Format("{0}m", span.Minutes);

			return time;
		}
		catch
		{
			return "";
		}
	}

	public static string MiniteToHoure(this int min)
	{
		try
		{
			int hours = (int)(min % 1440) / 60;
			int minites = (int)min % 60;
			return hours + "h, " + minites + "m";
		}
		catch
		{
			return "";
		}
	}

	public static string SubstringBylength(this string text, int number, string lastCharacter = "")
	{
		try
		{
			if (string.IsNullOrEmpty(text))
				return "";
			else
			{
				if (text.Length > number)
					return text.Substring(0, number) + lastCharacter;
				else
					return text.Substring(0, text.Length) + lastCharacter;
			}
		}
		catch
		{
			return "";
		}
	}

	public static string ToPayTypeStr(this PayType sts)
	{
		try
		{
			switch (sts)
			{
				case PayType.ByCreadit:
					return "Credit";

				case PayType.ACH:
					return "ACH";

				case PayType.ByCHeck:
					return "Check";

				case PayType.Cach:
					return "Cach";

				case PayType.ByAdmin:
					return "Admin";

				case PayType.Refund:
					return "Refund";

				default:
					return "--";
			}
		}
		catch
		{
			return "--";
		}
	}

	public static string ToPayConfirm(this bool confirmed, PayType payType)
	{
		try
		{
			var ConfirmedStr = confirmed ? "Succeeded " : "Failed";

			if (!confirmed & payType != Infrastructure.Entity.PayType.ByCreadit)
			{
				ConfirmedStr = "Confirmation Pending";
			}
			if (confirmed & payType != Infrastructure.Entity.PayType.ByCreadit)
			{
				ConfirmedStr = "Confirmed";
			}
			if (payType == Infrastructure.Entity.PayType.Refund)
			{
				ConfirmedStr = "Refunded";
			}
			return ConfirmedStr;
		}
		catch
		{
			return "--";
		}
	}

	public static string ToPayConfirmWithColor(this bool confirmed, PayType payType)
	{
		try
		{
			var ConfirmedStr = confirmed ? "Succeeded".ToColorBox("success") : "Failed".ToColorBox("danger");

			if (!confirmed & payType != Infrastructure.Entity.PayType.ByCreadit)
			{
				ConfirmedStr = "Confirmation Pending".ToColorBox("warning");
			}
			if (confirmed & payType != Infrastructure.Entity.PayType.ByCreadit)
			{
				ConfirmedStr = "Confirmed".ToColorBox("success");
			}
			if (payType == Infrastructure.Entity.PayType.Refund)
			{
				ConfirmedStr = "Refunded".ToColorBox("info");
			}
			return ConfirmedStr;
		}
		catch
		{
			return "--";
		}
	}

	public static string ToColorBox(this string text, string className)
	{
		if (string.IsNullOrEmpty(text)) return "";
		else return "<a href='javascript:;'  class='btn btn-" + className + " btn-xs'>" + text + "</a>";
	}

	public static string ToPayTypeStrUser(this PayType sts)
	{
		try
		{
			switch (sts)
			{
				case PayType.ByCreadit:
					return "by Credit Card";

				case PayType.ACH:
					return "by ACH";

				case PayType.ByCHeck:
					return "by  Check";

				case PayType.Cach:
					return "by Cach";

				case PayType.ByAdmin:
					return "";

				case PayType.Refund:
					return "";

				default:
					return "";
			}
		}
		catch
		{
			return "--";
		}
	}

	public static string ToConfirmedtr(this ConfirmStatus sts)
	{
		try
		{
			switch (sts)
			{
				case ConfirmStatus.Pending:
					return "Pending  <i class='fa fa-spinner color-yellow'> </i>";

				case ConfirmStatus.accept:
					return "accept  <i class='fa fa-check color-green'> </i>";

				case ConfirmStatus.reject:
					return "reject  <i class='fa fa-close color-red'> </i>";

				default:
					return "--";
			}
		}
		catch
		{
			return "--";
		}
	}

	public static string ToItemtatus(this ItemStatus sts)
	{
		try
		{
			switch (sts)
			{
				case ItemStatus.Pending:
					return "Pending";

				case ItemStatus.Good_to_go:
					return "Good to go";

				case ItemStatus.Orderd:
					return "Orderd";

				case ItemStatus.Back_ordered:
					return "Back ordered";

				case ItemStatus.Delivered_in_house:
					return "Delivered_in_house";

				case ItemStatus.Load:
					return "Load";

				case ItemStatus.Item_Delivered:
					return "Item Delivered";

				case ItemStatus.Deleted:
					return "Item Deleted";

				default:
					return "--";
			}
		}
		catch
		{
			return "--";
		}
	}

	public static string ToPercentColor(this int number)
	{
		try
		{
			if (number < 75)
				return "#5CB85C";
			else if (number >= 75 & number < 90)
				return "#F8CB00";
			else
				return "#F86C6B";
		}
		catch
		{
			return "#5CB85C";
		}
	}

	public static string ConvertMinToTime(this int minite)

	{
		var str = "";
		if (minite >= 60)
			str = String.Format("{0} {1} ", minite / 60, (minite / 60) == 1 ? "H" : "H");
		var min = minite % 60;
		if (min > 0)
			str += " " + min + " min";

		return str;
	}

	public static string ConvertMinToShortTime(this int minite)
	{
		if (minite == 0) return "0";

		var str = "";
		if (minite >= 60)
			str = (minite / 60).ToString() + "h-";
		var min = minite % 60;
		if (min > 0)
			str += min + "m";

		return str;
	}

	public static string FixFormat(this int number, int MaxLength)
	{
		try
		{
			if (number.ToString().Count() >= MaxLength)
				return number.ToString();
			else
			{
				var Res = "";
				for (int i = 0; i < MaxLength - number.ToString().Count(); i++)
				{
					Res += "0";
				}
				return Res + number.ToString();
			}
		}
		catch
		{
			return "-------";
		}
	}

	public static bool IntToBoolean(this int b)
	{
		if (b == 1)
			return true;
		else
			return false;
	}

	public static string HideZero(this int number)
	{
		if (number == 0)
			return "";
		else
			return number.ToString();
	}

	public static string HideZeroPrice(this int number)
	{
		if (number == 0)
			return "";
		else
			return "$ " + number.ToString();
	}

	public static int GetInt(this string str)
	{
		try
		{
			if (str == "--")
				return 0;
			string Char = "";
			for (int i = 0; i < str.Length; i++)
			{
				if (str.Substring(i, 1).IsDigit())
					Char += str.Substring(i, 1);
			}
			if (Char.IsDigit())
				return Char.ToInt();
			else
				return 0;
		}
		catch
		{
			return 0;
		}
	}

	public static string Get10Or13Integer(this string str)
	{
		try
		{
			for (int i = 0; i < str.Count(); i++)
			{
				if (str.Count() - i >= 10)

				{
					if (str.Substring(i, 10).Fa2En().Trim().IsDigit())
					{
						return str.Substring(i, 10).Fa2En();
					}
				}
				else if (str.Count() - i >= 13)
				{
					if (str.Substring(i, 13).Fa2En().Trim().IsDigit())
					{
						return str.Substring(i, 13).Fa2En();
					}
				}
			}
			return "";
		}
		catch
		{
			return "";
		}
	}

	public static int StringToInt(this string obj)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(obj)) return 0;

			var character = "";
			foreach (var item in obj)
			{
				if (item.ToString().IsDigit())
					character += item;
			}

			return Convert.ToInt32(character);
		}
		catch
		{
			return 0;
		}
	}

	public static string SubstringText(this string str, int length)
	{
		try
		{
			if (string.IsNullOrEmpty(str))
				return "";
			if (str.Length <= length)
				return str;
			return str.Substring(0, length) + "...";
		}
		catch
		{
			return str;
		}
	}

	public static string SetRedMore(this string str, int index, bool active = false)
	{
		try
		{
			if (!active) return str;
			if (string.IsNullOrEmpty(str))
				return "";
			if (str.Length <= index | index == 0)
				return str;

			var text = str.Substring(0, index) + "<span class='dots'>...</span><span class='more'>" + str.Substring(index, str.Length - index - 1) + "</span>  <a href='javascript:;' onclick='ReadMoreFunction(this)'>Read more</a>";
			return text;
		}
		catch (Exception ex)
		{
			return str;
		}
	}

	public static string ShowAll(this string str, int index, bool active = false)
	{
		try
		{
			if (!active) return str;
			if (string.IsNullOrEmpty(str))
				return "";
			if (str.Length <= index | index == 0)
				return str;

			var text = str.Substring(0, index) + "<span class='dots'>***</span><span class='showall'>" + str.Substring(index, str.Length - index) + "</span>  <a href='javascript:;' onclick='showAllFunction(this)'>Show All</a>";
			return text;
		}
		catch (Exception ex)
		{
			return str;
		}
	}

	public static long StringToLong(this string obj)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(obj)) return 0;

			var character = "";
			foreach (var item in obj)
			{
				if (item.ToString().IsDigit())
					character += item;
			}
			return Convert.ToInt64(character);
		}
		catch
		{
			return 0;
		}
	}

	#endregion Converter

	public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
	{
		return listToClone.Select(item => (T)item.Clone()).ToList();
	}

	public static string ToUserTypeString(this UserType ut)
	{
		try
		{
			if (ut == UserType.Admin)
				return "Admin";
			else if (ut == UserType.Estimator)
				return "Estimator";
			else if (ut == UserType.Installer)
				return "Installer";
			else if (ut == UserType.User)
				return "Customer";
			else if (ut == UserType.Commerical)
				return "Commerical";
			else if (ut == UserType.Installer_Estimator)
				return "Estimator and Installer";
			else
				return "User";
		}
		catch (Exception ex)
		{
			return "User";
		}
	}

	public static string ToUserTypeApptString(this UserType ut)
	{
		try
		{
			if (ut == UserType.Admin)
				return "Admin";
			else if (ut == UserType.Estimator)
				return "Estimation";
			else if (ut == UserType.Installer)
				return "Installation";
			else if (ut == UserType.User)
				return "Customer";
			else if (ut == UserType.Commerical)
				return "Commerical";
			else if (ut == UserType.Installer_Estimator)
				return "Estimation and Installation";
			else
				return "User";
		}
		catch (Exception ex)
		{
			return "User";
		}
	}

	public static IEnumerable<TSource> DistinctBy<TSource, TKey>
	(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		HashSet<TKey> seenKeys = new HashSet<TKey>();
		foreach (TSource element in source)
		{
			if (seenKeys.Add(keySelector(element)))
			{
				yield return element;
			}
		}
	}

	public static string FixMonyText(this string St, string Char)
	{
		if (St.Count() == 0)
			return "0";
		string Mony = "";
		St = St + Char;
		List<string> data = new List<string>();
		int j = 0;
		for (int i = 0; i < St.Count(); i++)
		{
			if (St.Substring(i, 1) == Char)
			{
				Mony = Mony + St.Substring(j, i - j);

				j = i;
				j++;
			}
		}

		return Mony;
	}

	public static string MonyText(this string St, string Char)
	{
		if (St.Count() == 0)
			return "0";
		string Mony = "";
		List<string> data = new List<string>();
		int First = St.Count() % 3;
		for (int i = St.Count() - 1; i >= 0; i -= 3)
		{
			if (i >= 2)
				Mony = St.Substring(i - 2, 3) + Char + Mony;
		}
		if (St.Count() % 3 != 0)
			Mony = St.Substring(0, First) + Char + Mony;
		Mony = Mony.Substring(0, Mony.Count() - 1);

		return Mony;
	}

	public static string RemoveAllUrl_HtmlTag(this string Text)
	{
		Text = Regex.Replace(Text, @"<a\b[^>]+>([^<]*(?:(?!</a)<[^<]*)*)</a>", String.Empty);
		Text = Regex.Replace(Text, @"<img.*?src=""(?<url>.*?)"".*?>", String.Empty);

		Text = Regex.Replace(Text, @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", String.Empty);

		Text = Regex.Replace(Text, @"<[^>]*>", String.Empty);
		return Text;
	}

	public static string RemoveAllCharacter(this string Text)
	{
		return Text.Replace("-", "").Replace("_", "").Replace("(", "").Replace(")", "").Replace(" ", "").Replace(".", "");
	}

	public static string SafePersianString(this string Text)
	{
		try
		{
			if (Text == null)
				return Text;
			Text = Text.Replace('‌', ' ').Replace('ك', 'ک').Replace('ي', 'ی').Trim(' ');
			Regex _compiledUnicodeRegex = new Regex(@"[\u200B-\u200D\uFEFF\u202C\u202E]", RegexOptions.Compiled);
			return _compiledUnicodeRegex.Replace(Text, string.Empty);
		}
		catch (Exception ex)
		{
			return Text;
		}
	}

	public static bool ContainsArray(this string[] list, params string[] strings)
	{
		try
		{
			foreach (var item in strings)
			{
				if (list.Contains(item)) return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			return false;
		}
	}
}

public static class GenericPrincipalExtensions
{
	public static string FullName(this IPrincipal user)
	{
		if (user.Identity.IsAuthenticated)
		{
			ClaimsIdentity claimsIdentity = user.Identity as ClaimsIdentity;
			foreach (var claim in claimsIdentity.Claims)
			{
				if (claim.Type == "FullName")
				{
					if (claim.Value.Trim() != "")
						return claim.Value;
					else
						return user.Identity.Name;
				}
			}
			return "";
		}
		else
			return "";
	}

	public static string UserID(this IPrincipal user)
	{
		if (user.Identity.IsAuthenticated)
		{
			ClaimsIdentity claimsIdentity = user.Identity as ClaimsIdentity;
			foreach (var claim in claimsIdentity.Claims)
			{
				if (claim.Type == "UserID")
				{
					if (claim.Value.Trim() != "")
						return claim.Value;
					else
						return user.Identity.Name;
				}
			}
			return "";
		}
		else
			return "";
	}

	public static string ToFileTypeIcon(this string fileType)
	{
		try
		{
			if (fileType == null)
				return "fa-file-image-o";

			if (fileType.Contains("image") | fileType.Contains("jpg"))
				return "fa-file-image-o";
			else if (fileType.Contains("document"))
				return "fa-file-word-o";
			else if (fileType.Contains("pdf"))
				return "fa-file-pdf-o";
			else if (fileType.Contains("video"))
				return "fa-file-movie-o";
			else
				return "fa-file-archive-o";
		}
		catch (Exception ex)
		{
			return "fa-file-archive-o";
		}
	}

	public static bool isFileImage(this string fileType)
	{
		try
		{
			if (fileType == null)
				return false;

			if (fileType.Contains("image") | fileType.Contains("jpg"))
				return true;

			return false;
		}
		catch (Exception ex)
		{
			return false;
		}
	}

	public static string ToFileTypeName(this string fileType)
	{
		try
		{
			if (fileType.Contains("image") | fileType.Contains("jpg"))
				return "Photo";
			else if (fileType.Contains("document"))
				return "Document";
			else if (fileType.Contains("pdf"))
				return "PDF";
			else if (fileType.Contains("video"))
				return "Video";
			else
				return "File";
		}
		catch (Exception ex)
		{
			return "File";
		}
	}

	public static string ToFileTypeImage(this string fileType)
	{
		try
		{
			if (fileType.Contains("image") | fileType.Contains("jpg"))
				return "file-image.png";
			else if (fileType.Contains("document") | fileType.Contains("text"))
				return "word-image.png";
			else if (fileType.Contains("pdf"))
				return "pdf-image.png";
			else if (fileType.Contains("video"))
				return "file-image.png";
			else
				return "file-image.png";
		}
		catch (Exception ex)
		{
			return "fa-file-archive-o";
		}
	}

	public static string GetDefaultFileTypeImage(this string file, string fileType)
	{
		try
		{
			if (fileType == null) return file;
			string image = string.IsNullOrEmpty(file) ? "file-image.png" : file;
			if (fileType.Contains("image") | fileType.Contains("jpg"))
				image = image + "";
			else if (fileType.Contains("document") | fileType.Contains("text"))
				image = "/Content/Images/word-image.png";
			else if (fileType.Contains("pdf"))
				image = "/Content/Images/pdf-image.png";
			else if (fileType.Contains("video"))
				image = "/Content/Images/file-image.png";
			else
				image = "/Content/Images/file-image.png";

			return image;
		}
		catch (Exception ex)
		{
			return file;
		}
	}

	public static string ToFileTypeColor(this string fileType)
	{
		try
		{
			if (fileType == null)
				return "btn-yellow";

			if (fileType.Contains("image") | fileType.Contains("jpg"))
				return "btn-yellow";
			else if (fileType.Contains("document"))
				return "btn-blue";
			else if (fileType.Contains("pdf"))
				return "btn-red";
			else if (fileType.Contains("video"))
				return "btn-blue";
			else
				return "";
		}
		catch (Exception ex)
		{
			return "fa-file-archive-o";
		}
	}

	public static string magnificPopupClassForImage(this string fileType, string text = "")
	{
		try
		{
			if (fileType.Contains("image") | fileType.Contains("jpg"))
				return "image-popup-vertical-fit" + text;
			else
				return "";
		}
		catch (Exception ex)
		{
			return "";
		}
	}

	//public static HttpRequestBase GetHttpRequestBase(this HttpContext httpContext)
	//{
	//    if (httpContext == null)
	//    {
	//        throw new ArgumentException("Context is null.");
	//    }

	//    return httpContext.Request.ToHttpRequestBase();
	//}

	//public static HttpRequestBase ToHttpRequestBase(this HttpRequest httpRequest)
	//{
	//    if (httpRequest == null)
	//    {
	//        throw new ArgumentException("Request is null.");
	//    }

	//    return new HttpRequestWrapper(httpRequest);
	//}
	public static bool AddUpdateClaim(this IPrincipal currentPrincipal, string key, string value)
	{
		try
		{
			var identity = currentPrincipal.Identity as ClaimsIdentity;
			if (identity == null)
				return false;

			// check for existing claim and remove it
			var existingClaim = identity.FindFirst(key);
			if (existingClaim != null)
				identity.RemoveClaim(existingClaim);

			// add new claim
			identity.AddClaim(new Claim(key, value));
			//var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
			//authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(new ClaimsPrincipal(identity), new AuthenticationProperties() { IsPersistent = true });

			//Comment here in net core
			//var ctx = HttpContext.Current.GetOwinContext();
			//var authenticationManager = ctx.Authentication;
			//authenticationManager.SignIn(identity);
			return true;
		}
		catch (Exception ex)
		{
			return false;
		}
	}

	public static string GetClaimValue(this IPrincipal currentPrincipal, string key)
	{
		try
		{
			var identity = currentPrincipal.Identity as ClaimsIdentity;
			if (identity == null)
				return null;

			var claim = identity.Claims.First(c => c.Type == key);
			return claim.Value;
		}
		catch (Exception ex)
		{
			return "";
		}
	}
}