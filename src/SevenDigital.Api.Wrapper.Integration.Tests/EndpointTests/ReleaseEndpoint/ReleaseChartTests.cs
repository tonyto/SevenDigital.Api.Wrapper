﻿using System;
using NUnit.Framework;
using SevenDigital.Api.Wrapper.EndpointResolution;
using SevenDigital.Api.Wrapper.Schema.Chart;
using SevenDigital.Api.Wrapper.Schema.ReleaseEndpoint;
using SevenDigital.Api.Wrapper.Utility.Http;

namespace SevenDigital.Api.Wrapper.Integration.Tests.EndpointTests.ReleaseEndpoint
{
	[TestFixture]
	[Category("Integration")]
	public class ReleaseChartTests
	{
		[Test]
		public void Can_hit_endpoint()
		{
			var httpGetResolver = new EndpointResolver(new HttpGetResolver());

			ReleaseChart release = new FluentApi<ReleaseChart>(httpGetResolver)
				.WithParameter("fromDate", "20110101")
				.WithParameter("toDate", "20110301")
				.WithParameter("country", "GB")
				.Resolve();

			Assert.That(release, Is.Not.Null);
			Assert.That(release.ChartItems.Count, Is.GreaterThan(0));
			Assert.That(release.FromDate, Is.GreaterThan(new DateTime(2011, 01, 01)));
			Assert.That(release.ToDate, Is.EqualTo(new DateTime(2011, 03, 01)));
			Assert.That(release.Type, Is.EqualTo(ChartType.album));
		}

		[Test]
		public void Can_hit_endpoint_with_paging()
		{
			var httpGetResolver = new EndpointResolver(new HttpGetResolver());

			ReleaseChart artistBrowse = new FluentApi<ReleaseChart>(httpGetResolver)
				.WithParameter("fromDate", "20090610")
				.WithParameter("toDate", "20110101")
				.WithParameter("page", "2")
				.WithParameter("pageSize", "20")
				.Resolve();

			Assert.That(artistBrowse, Is.Not.Null);
			Assert.That(artistBrowse.Page, Is.EqualTo(2));
			Assert.That(artistBrowse.PageSize, Is.EqualTo(20));
		}
	}
}