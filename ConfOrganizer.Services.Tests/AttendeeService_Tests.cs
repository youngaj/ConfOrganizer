using ConfOrganizer.Entities;
using Moq;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConfOrganizer.Services.Tests
{
    public class AttendeeService_Tests
    {

        [Fact]
        [Trait("Category", "SmokeTest")]
        public void AttendeeService_ExistanceTest()
        {
			//arrange
            var sut = new AttendeeService_Builder()
							.Build();

			//Act

			//Assert
            Assert.NotNull(sut);
        }

    }
    public class AttendeeService_Builder
    {
        private IRepositoryAsync<Attendee> _repo;
        public AttendeeService_Builder()
        {

        }

        public AttendeeService Build()
        {
            if (_repo == null)
            {
				//-- create a mock
                var repoMock = new Mock<IRepositoryAsync<Attendee>>();
                _repo = repoMock.Object;

            }

			var service = new AttendeeService(_repo);
            return service;
        }
    }
}
