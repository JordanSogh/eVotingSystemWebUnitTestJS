using NUnit.Framework;
using eVotingSystemWebJS.Models;
using eVotingSystemWebJS.Controllers;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Mvc;



namespace eVotingSystemWebUnitTestJS
{
    public class Tests
    {

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void LoginUser()
        {
            //Arrange
            User userDetailsInput = new User();
            userDetailsInput.UserName = "userVoter";
            userDetailsInput.Password = "password";

            //Act
            var controller = new HomeController(new NullLogger<HomeController>(), new VotingDBContext());
            var result = controller.LoginUser(userDetailsInput) as ViewResult;

            //Assert
            Assert.AreEqual("AlreadyVoted", result.ViewName);
           
        }

        [Test]
        public void Voting_Index()
        {
            //Arrange

            //Act
            var controller = new VotingController(new VotingDBContext());
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", result.ViewName);

        }

        [Test]
        public void Voting_Vote()
        {
            //Arrange
            int VoteOptions = 2;
            //Act
            var controller = new VotingController(new VotingDBContext());
            var result = controller.Vote(VoteOptions) as ViewResult;

            //Assert
            Assert.AreEqual("Voted", result.ViewName);

        }
    }
}