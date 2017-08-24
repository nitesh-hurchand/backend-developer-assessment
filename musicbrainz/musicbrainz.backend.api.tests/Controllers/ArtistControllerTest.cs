using System;
using System.Collections.Generic;
using System.Linq;
using musicbrainz.backend.api.Controllers;
using musicbrainz.backend.api.Models;
using musicbrainz.backend.api.Providers;
using musicbrainz.infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Telerik.JustMock.EntityFramework;

namespace musicbrainz.backend.api.tests.Controllers
{
    [TestClass]
    public class ArtistControllerTest
    {
        [TestMethod]
        public void SearchArtist()
        {
            var dbContext = Mock.Create<MusicBrainzDbContext>().PrepareMock();
            var remoteServiceProvider = Mock.Create<IRemoteServiceProvider>();
            // Arrange
            ArtistController controller = new ArtistController(dbContext, remoteServiceProvider);

            // Act
            var responseDefaultPaging = controller.Get("");
            var responseSpecificPaging = controller.Get("", 1, 2);
            var responseSpecificPagingWithCriteria = controller.Get("asd", 1, 2);

            // Assert
            Assert.IsNotNull(responseDefaultPaging);
            Assert.IsNotNull(responseDefaultPaging.Results);
            Assert.AreEqual(0, responseDefaultPaging.Results.Count());
            Assert.AreEqual("0", responseDefaultPaging.NumberOfPages);
            Assert.AreEqual(0, responseDefaultPaging.NumberOfSearchResults);
            Assert.AreEqual("0", responseDefaultPaging.Page);
            Assert.AreEqual("30", responseDefaultPaging.PageSize);


            Assert.IsNotNull(responseSpecificPaging);
            Assert.IsNotNull(responseSpecificPaging.Results);
            Assert.AreEqual(0, responseSpecificPaging.Results.Count());
            Assert.AreEqual("0", responseDefaultPaging.NumberOfPages);
            Assert.AreEqual(0, responseDefaultPaging.NumberOfSearchResults);
            Assert.AreEqual("1", responseSpecificPaging.Page);
            Assert.AreEqual("2", responseSpecificPaging.PageSize);


            Assert.IsNotNull(responseSpecificPagingWithCriteria);
            Assert.IsNotNull(responseSpecificPagingWithCriteria.Results);
            Assert.AreEqual(0, responseSpecificPagingWithCriteria.Results.Count());
            Assert.AreEqual("0", responseSpecificPagingWithCriteria.NumberOfPages);
            Assert.AreEqual(0, responseSpecificPagingWithCriteria.NumberOfSearchResults);
            Assert.AreEqual("1", responseSpecificPaging.Page);
            Assert.AreEqual("2", responseSpecificPaging.PageSize);
        }

        [TestMethod]
        public void SearchRelease()
        {
            var dbContext = Mock.Create<MusicBrainzDbContext>().PrepareMock();
            var remoteServiceProvider = Mock.Create<IRemoteServiceProvider>();
            Mock.Arrange(() => remoteServiceProvider.SearchReleases(Arg.AnyGuid))
                .Returns(new List<ReleaseModel>());
            // Arrange
            ArtistController controller = new ArtistController(dbContext, remoteServiceProvider);

            // Act
            var response = controller.Get(Guid.NewGuid());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Results);
            Assert.AreEqual(0, response.Results.Count());
        }
    }
}
