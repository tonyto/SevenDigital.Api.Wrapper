﻿using System;
using System.Configuration;
using System.Net;
using NUnit.Framework;
using SevenDigital.Api.Wrapper.Utility.Http;

namespace SevenDigital.Api.Wrapper.Unit.Tests.Utility.Http
{
	[TestFixture]
	public class HttpGetResolverTests
	{
		[Test]
		[Category("Integration")]
		public void Can_resolve_uri()
		{
			string apiUrl = ConfigurationManager.AppSettings["Wrapper.BaseUrl"];
			string consumerKey = ConfigurationManager.AppSettings["Wrapper.ConsumerKey"];
			string resolve = new HttpGetResolver().Resolve(new Uri(string.Format("{0}/status?oauth_consumer_key={1}", apiUrl, consumerKey)), "GET",
			                                               new WebHeaderCollection());
			Assert.That(resolve, Is.Not.Empty);
		}
	}
}
