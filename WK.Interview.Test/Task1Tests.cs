namespace WK.Interview.Test
{
    [TestFixture]
    public class Task1Tests
    {
        Task1 task1;
        [SetUp]
        public void Setup()
        {
            var employeeMock = new Mock<IEmployee>();
            employeeMock.Setup(x => x.Id).Returns(new Guid());

            var employeeFactoryMock = new Mock<IEmployeeFactory>();
            employeeFactoryMock.Setup(x => x.Create(It.IsAny<string>())).Returns(employeeMock.Object);

            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(x => x.Insert(It.IsAny<IEmployee>()));

            task1 = new Task1(employeeFactoryMock.Object, employeeRepositoryMock.Object);
        }

        [Test]
        [TestCase("a")]
        [TestCase("  .")]
        [TestCase("abc")]
        [TestCase("         a")]
        [TestCase("1")]
        public void WhenProvideNotEmptyString_ThenCompleteMethod(string lastName)
        {
            task1.CreateEmployee(lastName);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void WhenProvideEmptyStringOrNull_ThenThrowArgumentExceptionError(string lastName)
        {
            var ex = Assert.Throws<ArgumentException>(() => task1.CreateEmployee(lastName));
            Assert.That(ex.Message.Equals("Value cannot be null or empty (Parameter 'lastName')"));
        }

        [Test]
        [TestCase(" ")]
        [TestCase("  ")]
        public void WhenProvideWhiteSpaceString_ThenCompleteMethod(string lastName)
        {
            task1.CreateEmployee(lastName);
        }


    }
}