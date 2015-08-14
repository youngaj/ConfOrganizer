using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using System.Data.Entity;
using EntityFramework.Testing;
using System.Web.Http.Results;

namespace ConfOrganizer.Web.Tests.Controllers.API
{
    public class AttendeesControllerTest
    {
        //[Fact]
        //public void Get()
        //{
        //    //Arrange
        //    var data = new List<AttendeeModel>()
        //    {
        //        new AttendeeModel() { Id = 1, Code = "408", emailAddress="andre.j.young@nasa.gov", JobTitle="developer", Name="andre young"}
        //    };
        //    var set = new Mock<DbSet<AttendeeModel>>();
        //    set.SetupData(data);

        //    var context = new Mock<ConfOrganizerDataContext>();
        //    context.Setup(x => x.AttendeeSet).Returns(set.Object);
        //    var controller = new AttendeesController(context.Object);

        //    //Act
        //    var response = controller.GetAttendeeSet();

        //    //Assert
        //    Assert.NotNull(response);
        //}

        //[Fact]
        //public void AttendeesController_WhenPostingWithDuplicate_ReturnsBadRequest()
        //{
        //    //Arrange
        //    var andre = new AttendeeModel() { Id = 1, Code = "408", emailAddress = "andre.j.young@nasa.gov", JobTitle = "developer", Name = "andre young" };
        //    var data = new List<AttendeeModel>()
        //    {
        //        andre
        //    };
        //    var set = new Mock<DbSet<AttendeeModel>>();
        //    set.SetupData(data);

        //    var context = new Mock<ConfOrganizerDataContext>();
        //    context.Setup(x => x.AttendeeSet).Returns(set.Object);
        //    var controller = new AttendeesController(context.Object);

        //    //Act
        //    var response = controller.PostAttendee(andre);

        //    //Assert
        //    Assert.NotNull(response);
        //    var result = Assert.IsType<BadRequestResult>(response);
        //}

    }
}
