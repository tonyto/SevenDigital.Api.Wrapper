﻿using NUnit.Framework;
using SevenDigital.Api.Wrapper.EndpointResolution;
using SevenDigital.Api.Wrapper.Schema.ReleaseEndpoint;
using SevenDigital.Api.Wrapper.Utility.Http;

namespace SevenDigital.Api.Wrapper.Integration.Tests.EndpointTests.ReleaseEndpoint
{
	[TestFixture]
	[Category("Integration")]
	public class ReleaseDetailsTests
	{
		[Test]
		public void Can_hit_endpoint()
		{
			var httpGetResolver = new EndpointResolver(new HttpGetResolver());

			Release release = new FluentApi<Release>(httpGetResolver)
				.WithParameter("releaseId", "155408")
				.WithParameter("country", "GB")
				.Resolve();

			Assert.That(release, Is.Not.Null);
			Assert.That(release.Title, Is.EqualTo("Dreams"));
			Assert.That(release.Artist.Name, Is.EqualTo("The Whitest Boy Alive"));
		}
	}
}