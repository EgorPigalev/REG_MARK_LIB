using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using REG_MARK_LIB;

namespace UnitTestRegMarkLib
{
    [TestClass]
    public class UnitTests
    {
        // Тестовые методы низкой сложности
        // Тест, на проверку, что метод для определения корректности номера выдаёт верный результат
        [TestMethod]
        public void CheckMark_Correctly()
        {
            string mark = "X345AT152";
            bool actual = Calculation.CheckMark(mark);
            Assert.IsTrue(actual);
        }
        // Тест, на проверку, что метод для определения корректности номера не считает не правильный результат верным
        [TestMethod]
        public void CheckMark_NotCorrectly()
        {
            string mark = "X345AT000";
            bool actual = Calculation.CheckMark(mark);
            Assert.IsFalse(actual);
        }
    }
}
