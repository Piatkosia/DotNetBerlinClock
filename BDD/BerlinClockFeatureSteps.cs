using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Autofac;
using BerlinClock.Classes;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private Bootstrapper bootstrapper = new Bootstrapper();
        private ITimeConverter berlinClock;
        private String theTime;

        public TheBerlinClockSteps()
        {
            IContainer container = bootstrapper.Bootstrap();
            berlinClock = container.Resolve<ITimeConverter>();
        }
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(berlinClock.convertTime(theTime), theExpectedBerlinClockOutput);
        }

    }
}
