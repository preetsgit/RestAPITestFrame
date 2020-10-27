using System;
using NUnit.Framework;

namespace RestAPITest
{
    [TestFixture]
    public abstract class TestBase
    {    
        public Resources resources;

        [SetUp]
        public void Setup()
        {
            resources = new Resources();
        }

    }
}