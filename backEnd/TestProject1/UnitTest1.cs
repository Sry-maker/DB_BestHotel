using System.Collections.Generic;
using System.Linq;
using backEnd;
using backEnd.Controllers;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            WeatherForecastController controller = new WeatherForecastController(null);//�޲Σ�����Ϊnull
            IEnumerable<WeatherForecast> result = controller.Get();
            //cookie
            Assert.AreEqual(result.ToList().Count, 5);//ע�����ﲻ�ܶԱ�JSON��ʽ�����ݣ�����5��
            Assert.Pass();
            Assert.Pass();
        }
    }
}