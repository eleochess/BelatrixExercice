using System;
using Belatrix.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Belatrix.UnitTests
{
    [TestClass]
    public class JobLoggerTest
    {
        [TestMethod]
        public void JobLoggerLogWithNullMessage()
        {
            bool result = false;

            result = JobLogger.LogMessage(null, false, false, false);
            result = JobLogger.LogWarning(null, false, false, false);
            result = JobLogger.LogError(null, false, false, false);

            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void JobLoggerLogWithEmptyMessage()
        {
            bool result = false;

            result = JobLogger.LogMessage(string.Empty, false, false, false);
            result = JobLogger.LogWarning(string.Empty, false, false, false);
            result = JobLogger.LogError(string.Empty, false, false, false);

            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void JobLoggerLogWithWhiteSpaceMessage()
        {
            bool result = false;

            result = JobLogger.LogMessage("   ", false, false, false);
            result = JobLogger.LogWarning("   ", false, false, false);
            result = JobLogger.LogError("   ", false, false, false);

            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void JobLoggerLogWithouthDestination()
        {
            bool result = false;

            result = JobLogger.LogMessage("Some message", false, false, false);
            result = JobLogger.LogWarning("Some message", false, false, false);
            result = JobLogger.LogError("Some message", false, false, false);

            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void JobLoggerLogToDatabase()
        {
            bool result = false;

            result = JobLogger.LogMessage("Some message", true, false, false);
            result = JobLogger.LogWarning("Some message", true, false, false);
            result = JobLogger.LogError("Some message", true, false, false);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void JobLoggerLogToFileText()
        {
            bool result = false;

            result = JobLogger.LogMessage("Some message", false, true, false);
            result = JobLogger.LogWarning("Some message", false, true, false);
            result = JobLogger.LogError("Some message", false, true, false);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void JobLoggerLogToConsole()
        {
            bool result = false;

            result = JobLogger.LogMessage("Some message", false, false, true);
            result = JobLogger.LogWarning("Some message", false, false, true);
            result = JobLogger.LogError("Some message", false, false, true);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void JobLoggerLogMessageToAllDestinations()
        {
            bool result = false;

            result = JobLogger.LogMessage("Some message", true, true, true);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void JobLoggerLogWarningToAllDestinations()
        {
            bool result = false;

            result = JobLogger.LogWarning("Some message", true, true, true);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void JobLoggerLogErrorToAllDestinations()
        {
            bool result = false;

            result = JobLogger.LogError("Some message", true, true, true);

            Assert.AreEqual(result, true);
        }
    }
}
