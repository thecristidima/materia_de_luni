using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CrossRef.Models;
using Newtonsoft.Json.Linq;

namespace CrossRef.Services
{
	public static class CrossRefService
	{
		private static readonly HttpClient HttpClient = new HttpClient();
		public static async Task<List<CrossRefArticle>> FetchArticles(string authorName, string affiliation)
		{
			var crossRefData = new List<CrossRefArticle>();

			var rows = 1000;
			var offset = 0;

			for (var iterations = 0; iterations <= 10; ++iterations) // We can only go to 11k articles
			{
				var crossRefUrl =
					$"https://api.crossref.org/works?query.author={authorName}&query.affiliation={affiliation}&rows={rows}&offset={offset}";

				try
				{
					var response = await HttpClient.GetStringAsync(crossRefUrl);

					var crossRefJson = JObject.Parse(response);
					var articleInfoList = crossRefJson["message"]["items"];

					crossRefData.AddRange(GetRelevantArticles(articleInfoList, authorName, affiliation));

					// Prepare for next request
					var totalRows = (int) crossRefJson["message"]["total-results"];

					offset += rows;
					if (offset >= totalRows) break;

					rows = Math.Min(totalRows - offset, 1000);
				}
				catch
				{
					break;
				}
			}

			return crossRefData;
		}

		private static List<CrossRefArticle> GetRelevantArticles(JToken articleList, string authorName,
			string affiliation)
		{
			var relevantArticles = new List<CrossRefArticle>();

			foreach (var articleInfo in articleList)
			{
				if (!IsEntryOk(articleInfo, authorName, affiliation))
				{
					continue;
				}

				// Get year of publication (somehow)
				int yearOfPublication;
				try
				{
					yearOfPublication = (int) articleInfo["published-print"]["date-parts"][0][0];
				}
				catch
				{
					yearOfPublication = (int) articleInfo["created"]["date-parts"][0][0];
				}

				// Attempt to get title (somehow)
				string title;
				try
				{
					title = (string) articleInfo["title"][0];
				}
				catch
				{
					continue;
				}

				// Attempt to get DOI
				string DOI;
				try
				{
					DOI = (string) articleInfo["DOI"];
				}
				catch
				{
					continue;
				}

				relevantArticles.Add(new CrossRefArticle
				{
					DOI = DOI,
					Title = title,
					YearOfPublication = yearOfPublication
				});
			}

			return relevantArticles;
		}

		private static bool IsEntryOk(JToken articleInfo, string authorName, string authorAffiliation)
		{
			foreach (var author in articleInfo["author"])
			{
				var firstName = (string) author["given"];
				var lastName = (string) author["family"];

				if (!authorName.Equals(firstName + " " + lastName, StringComparison.InvariantCultureIgnoreCase) &&
				    !authorName.Equals(lastName + " " + firstName, StringComparison.InvariantCultureIgnoreCase))
				{
					continue;
				}

				if (author["affiliation"].Select(affiliation => (string) affiliation["name"]).Any(affiliationString =>
					IsAffiliationValid(affiliationString, authorAffiliation)))
				{
					return true;
				}
			}

			return false;
		}

		private static bool IsAffiliationValid(string candidateAffiliation, string affiliation)
		{
			return affiliation.Split(" ").All(candidateAffiliation.Contains);
		}
	}
}