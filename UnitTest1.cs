using System;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayerMP3AndVideo;

namespace PlayerMP3AndVideoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetMd5Hash()
        {
            MD5 hash = MD5.Create();
            string pass = "Hello World!";

            string result = LogPanel.GetMd5Hash(hash, pass);

            string Expected = "ed076287532e86365e841e92bfc50d8c";
  
            Assert.AreEqual(Expected, result, "nie sa rowne");

        }
        [TestMethod]
        public void TestVerifyMd5Hash()
        {
            MD5 md5Hash = MD5.Create();
            string pass = "Hello World!";

            string hash = LogPanel.GetMd5Hash(md5Hash, pass);

            bool result = LogPanel.VerifyMd5Hash(md5Hash, pass, hash);

            bool Expected = true;

            Assert.AreEqual(Expected, result, "nie sa rowne");

        }
        
    }

}
