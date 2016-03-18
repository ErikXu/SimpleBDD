using System;
using NUnit.Framework;
using SimpleBDD.Client;
using TechTalk.SpecFlow;

namespace SimpleBDD.UnitTests
{
    public class DesCryptoUtilTests
    {
        protected DesCryptoUtil DesCryptoUtil;

        public DesCryptoUtilTests()
        {
            DesCryptoUtil = new DesCryptoUtil();
        }
    }

    [Binding]
    [Scope(Scenario = "Encrypt valid text")]
    public class EncryptValidText : DesCryptoUtilTests
    {
        private string _plainText;
        private string _encryptedText;
        private string _expectedText;

        [Given(@"明文")]
        public void GivenPlainText()
        {
            _plainText = "123456";
        }

        [When(@"执行Des加密")]
        public void WhenCallEncrypt()
        {
            _encryptedText = DesCryptoUtil.Encrypt(_plainText);
        }

        [Then(@"得到密文，且无异常抛出")]
        public void ThenGetTheEncryptedText()
        {
            _expectedText = "WAQSvabZH4U=";
            Assert.AreEqual(_expectedText, _encryptedText);
        }
    }

    [Binding]
    [Scope(Scenario = "Encrypt empty text")]
    public class EncryptEmptyText : DesCryptoUtilTests
    {
        private string _emptyText;
        private string _encryptedText;
        private string _expectedText;

        [Given(@"空字符串")]
        public void GivenEmptyText()
        {
            _emptyText = string.Empty;
        }

        [When(@"执行Des加密")]
        public void WhenCallEncrypt()
        {
            _encryptedText = DesCryptoUtil.Encrypt(_emptyText);
        }

        [Then(@"得到空字符串，且无异常抛出")]
        public void ThenGetTheEmptyText()
        {
            _expectedText = string.Empty;
            Assert.AreEqual(_expectedText, _encryptedText);
        }
    }

    [Binding]
    [Scope(Scenario = "Encrypt null text")]
    public class EncyptNullText : DesCryptoUtilTests
    {
        private string _nullText;
        private TestDelegate _delegate;
        private Type _expectedException;

        [Given(@"null")]
        public void GivenEmptyText()
        {
            _nullText = null;
        }

        [When(@"执行Des加密")]
        public void WhenCallEncrypt()
        {
            _delegate = () => DesCryptoUtil.Encrypt(_nullText);
        }

        [Then(@"抛出ArgumentNullException异常")]
        public void ThenThrowArgumentNullException()
        {
            _expectedException = typeof(ArgumentNullException);
            Assert.That(_delegate, Throws.TypeOf(_expectedException));
        }
    }

    [Binding]
    [Scope(Scenario = "Decrypt valid text")]
    public class DecryptValidText : DesCryptoUtilTests
    {
        private string _encryptedText;
        private string _plainText;
        private string _expectedText;

        [Given(@"密文")]
        public void GivenEncryptedText()
        {
            _encryptedText = "WAQSvabZH4U=";
        }

        [When(@"执行Des解密")]
        public void WhenCallDecrypt()
        {
            _plainText = DesCryptoUtil.Decrypt(_encryptedText);
        }

        [Then(@"得到明文，且无异常抛出")]
        public void ThenGetThePlainText()
        {
            _expectedText = "123456";
            Assert.AreEqual(_expectedText, _plainText);
        }
    }
}