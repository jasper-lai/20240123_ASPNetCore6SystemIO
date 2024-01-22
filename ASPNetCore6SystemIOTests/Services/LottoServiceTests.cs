using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASPNetCore6SystemIO.Services;
using ASPNetCore6SystemIO.ViewModels;
using ExpectedObjects;
using ASPNetCore6SystemIO.Wrapper;
using Moq;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

namespace ASPNetCore6SystemIO.Services.Tests
{
    [TestClass()]
    public class LottoServiceTests
    {
        [TestMethod()]
        public void Test_Lottoing_今天是20240105_主辦人宣告開始_輸入亂數範圍_0_10_預期回傳_9_恭喜中獎()
        {
            // Arrange
            var expected = new LottoViewModel()
            { Sponsor = "傑士伯", YourNumber = 9, Message = "恭喜中獎" }
                        .ToExpectedObject();

            int fixedValue = 9;
            DateTime today = new(2024, 01, 05);
            var mockRandomGenerator = new Mock<IRandomGenerator>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            mockRandomGenerator.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(fixedValue);
            mockDateTimeProvider.Setup(d => d.GetCurrentTime()).Returns(today);
            //
            var mockFileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
                {
                    { @"Extras/startup.txt", new MockFileData("傑士伯") },
                }
            );


            // Act
            var target = new LottoService(mockRandomGenerator.Object, mockDateTimeProvider.Object, mockFileSystem);
            var actual = target.Lottoing(0, 10);

            // Assert
            expected.ShouldEqual(actual);
        }


        [TestMethod()]
        public void Test_Lottoing_今天是20240105_主辦人宣告開始_輸入亂數範圍_0_10_預期回傳_1_再接再厲()
        {
            // Arrange
            var expected = new LottoViewModel()
            { Sponsor="傑士伯", YourNumber = 1, Message = "再接再厲" }
                        .ToExpectedObject();

            int fixedValue = 1;
            DateTime today = new(2024, 01, 05);
            var mockRandomGenerator = new Mock<IRandomGenerator>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            mockRandomGenerator.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(fixedValue);
            mockDateTimeProvider.Setup(d => d.GetCurrentTime()).Returns(today);
            var mockFileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
                {
                    { @"Extras/startup.txt", new MockFileData("傑士伯") },
                }
            );

            // Act
            var target = new LottoService(mockRandomGenerator.Object, mockDateTimeProvider.Object, mockFileSystem);
            var actual = target.Lottoing(0, 10);

            // Assert
            expected.ShouldEqual(actual);
        }


        [TestMethod()]
        public void Test_Lottoing_今天是20240122_不論主辦人是否宣告開始_輸入亂數範圍_0_10_預期回傳_負1_非每個月5日_不開獎()
        {
            // Arrange
            var expected = new LottoViewModel()
            { Sponsor = "", YourNumber = -1, Message = "非每個月5日, 不開獎" }
                        .ToExpectedObject();

            int fixedValue = 9;
            DateTime today = new(2024, 01, 22);
            var mockRandomGenerator = new Mock<IRandomGenerator>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            mockRandomGenerator.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(fixedValue);
            mockDateTimeProvider.Setup(d => d.GetCurrentTime()).Returns(today);
            var mockFileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
                {
                    { @"Extras/startup.txt", new MockFileData("傑士伯") },
                }
            );

            // Act
            var target = new LottoService(mockRandomGenerator.Object, mockDateTimeProvider.Object, mockFileSystem);
            var actual = target.Lottoing(0, 10);

            // Assert
            expected.ShouldEqual(actual);
        }

        [TestMethod()]
        public void Test_Lottoing_今天是20240105_但主辦人常未宣告開始_輸入亂數範圍_0_10_預期回傳_負2_主辦人員尚未按下開始按鈕()
        {
            // Arrange
            var expected = new LottoViewModel()
            { Sponsor = "", YourNumber = -2, Message = "主辦人員尚未按下[開始]按鈕" }
                        .ToExpectedObject();

            int fixedValue = 1;
            DateTime today = new(2024, 01, 05);
            var mockRandomGenerator = new Mock<IRandomGenerator>();
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            mockRandomGenerator.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(fixedValue);
            mockDateTimeProvider.Setup(d => d.GetCurrentTime()).Returns(today);
            var mockFileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
                {
                    //只要不提供檔案路徑, 就會視為 FileNotFound Exception
                    //{ @"startup.txt", new MockFileData("傑士伯") },
                }
            );

            // Act
            var target = new LottoService(mockRandomGenerator.Object, mockDateTimeProvider.Object, mockFileSystem);
            var actual = target.Lottoing(0, 10);

            // Assert
            expected.ShouldEqual(actual);
        }

    }
}