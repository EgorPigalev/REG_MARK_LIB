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
        // Тест, на проверку, что метод который выдаёт следующий номер корректен
        [TestMethod]
        public void GetNextMarkAfter_Correctly()
        {
            string exception = "B001BA152";
            string mark = "A999BX152";
            string actual = Calculation.GetNextMarkAfter(mark);
            Assert.AreEqual(exception, actual);
        }
        // Тест, на проверку, что метод который выдаёт следующий номерной знак, выводит результат значение которого не равно не правильному
        [TestMethod]
        public void GetNextMarkAfter_NotCorrectly()
        {
            string exception = "A006AA152";
            string mark = "A004AA152";
            string actual = Calculation.GetNextMarkAfter(mark);
            Assert.IsFalse(exception == actual);
        }
        // Тест, на проверку, что метод который выдаёт следующий номер корректен
        [TestMethod]
        public void GetNextMarkAfter_NotNull()
        {
            string mark = "A210XT152";
            string actual = Calculation.GetNextMarkAfter(mark);
            Assert.IsNotNull(actual);
        }
        // Тест, на проверку, что метод для определения следующего номера в диапозоне высчитывает корректно
        [TestMethod]
        public void GetNextMarkAfterInRange_Correctly()
        {
            string exception = "A006AA152";
            string prevMark = "A005AA152";
            string rangeStart = "A001AA152";
            string rangeEnd = "A800AB152";
            string actual = Calculation.GetNextMarkAfterInRange(prevMark, rangeStart, rangeEnd);
            Assert.IsTrue(exception == actual);
        }
        // Тест, на проверку, что метод для определения следующего номера в диапозоне высчитывает корректно и выводит результат с правильным типом данных
        [TestMethod]
        public void GetNextMarkAfterInRange_CorrectlyType()
        {
            string prevMark = "A005AA152";
            string rangeStart = "A001AA152";
            string rangeEnd = "A800AB152";
            string actual = Calculation.GetNextMarkAfterInRange(prevMark, rangeStart, rangeEnd);
            Assert.IsInstanceOfType(actual, typeof(string));
        }
        // Тест, на проверку, что метод который выдаёт количество возможных номеров в диапозоне
        [TestMethod]
        public void GetCombinationsCountInRange_Correctly()
        {
            int exception = 1009;
            string mark1 = "A001AA152";
            string mark2 = "A010AB152";
            int actual = Calculation.GetCombinationsCountInRange(mark1, mark2);
            Assert.AreEqual(exception, actual);
        }
        // Тест, на проверку, что метод который выдаёт количество возможных номеров в диапозоне, выводит результат значение которого не равно не правильному
        [TestMethod]
        public void GetCombinationsCountInRange_NotCorrectly()
        {
            int exception = 150;
            string mark1 = "A001AA152";
            string mark2 = "A010AA152";
            int actual = Calculation.GetCombinationsCountInRange(mark1, mark2);
            Assert.IsTrue(exception != actual);
        }
        // Тест, на проверку, что метод который выдаёт количество возможных номеров в диапозоне возвращает результат с верным типом
        [TestMethod]
        public void GetCombinationsCountInRange_TypeCorrectly()
        {
            string mark1 = "A001AA152";
            string mark2 = "A010AB152";
            int actual = Calculation.GetCombinationsCountInRange(mark1, mark2);
            Assert.IsInstanceOfType(actual, typeof(int));
        }


        // Методы высокой сложности
        // Тест, на проверку, что метод для определения корректности номера выдёт корректное значение если передано не правильное значение
        [TestMethod]
        public void CheckMark_CorrectlyType()
        {
            string mark = "A000AA152";
            bool actual = Calculation.CheckMark(mark);
            Assert.IsInstanceOfType(actual, typeof(bool));
        }
        // Тест, на проверку, что метод который выдаёт следующий номер корректно выводит результат, если все регистрационные знаки закончились
        [TestMethod]
        public void GetNextMarkAfter_Border()
        {
            string exception = "error";
            string mark = "X999XX152";
            string actual = Calculation.GetNextMarkAfter(mark);
            Assert.IsTrue(exception == actual);
        }
        // Тест, на проверку, что метод для определения следующего номера в диапозоне выводит сообщение, что следующий номер не найден если разные регионы
        [TestMethod]
        public void GetNextMarkAfterInRange_NotCorrectlyRegion()
        {
            string exception = "out of stock";
            string prevMark = "A005AA777";
            string rangeStart = "A001AA155";
            string rangeEnd = "A800AB155";
            string actual = Calculation.GetNextMarkAfterInRange(prevMark, rangeStart, rangeEnd);
            Assert.AreEqual(exception, actual);
        }
        // Тест, на проверку, что метод для определения следующего номера в диапозоне выводит сообщение, если предыдущий номер не входит в диапозон
        [TestMethod]
        public void GetNextMarkAfterInRange_NotCorrectly()
        {
            string exception = "out of stock";
            string prevMark = "A990AB152";
            string rangeStart = "A001AA152";
            string rangeEnd = "A800AB152";
            string actual = Calculation.GetNextMarkAfterInRange(prevMark, rangeStart, rangeEnd);
            Assert.IsTrue(exception == actual);
        }
        // Тест, на проверку, что метод для определения корректности номера не выдаёт ошибку если неправильный регион
        [TestMethod]
        public void CheckMark_NotCorrectlyRegion()
        {
            bool exception = false;
            string mark = "X345AT000";
            bool actual = Calculation.CheckMark(mark);
            Assert.AreEqual(exception, actual);
        }
    }
}
