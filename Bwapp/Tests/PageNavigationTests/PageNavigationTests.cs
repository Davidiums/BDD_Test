﻿using BugzillaWebDriver.BaseClasses;
using BugzillaWebDriver.ComponentHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugzillaWebDriver.Tests.PageNavigationTests
{
    [TestClass]
    public class PageNavigationTests
    {
        [TestMethod]
        public void OpenPageFromDriver()
        {
            ObjectRepository.Driver.Navigate().GoToUrl(ObjectRepository.Config.GetWebsite());
        }

        [TestMethod]
        public void OpenPageFromObjectRepository()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
        }

        [TestMethod]
        public void OpenPageFromObjectRepositoryAndGetTitle()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            Console.WriteLine(ObjectRepository.Driver.Title);
        }

        [TestMethod]
        public void OpenPageFromObjectRepositoryAndGetTitleFromPageHelper()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            Console.WriteLine(PageHelper.GetPageTitle());
        }

        [TestMethod]
        public void ClickOnLoginFromButtonHelperAndCheckPageTitleTest()
        {
            NavigationHelper.NavigateToHomePage();
            TextBoxHelper.TypeInTextBox(By.Id("login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("password"), ObjectRepository.Config.GetPassword());
            ButtonHelper.ClickButton(By.Name("form"));
            Assert.AreEqual("bWAPP - Portal", PageHelper.GetPageTitle());
            NavigationHelper.NavigateToUrl("http://127.0.0.1/logout.php");
        }

        [TestMethod]
        public void ClickOnLoginFromButtonHelperAndCheckPageUrlTest()
        {
            NavigationHelper.NavigateToHomePage();
            TextBoxHelper.TypeInTextBox(By.Id("login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("password"), ObjectRepository.Config.GetPassword());
            ButtonHelper.ClickButton(By.Name("form"));
            Assert.AreEqual("http://127.0.0.1/portal.php", PageHelper.GetPageUrl());
            NavigationHelper.NavigateToUrl("http://127.0.0.1/logout.php");
        }

        [TestMethod]
        public void OpenNewTabAndCheckNulberOfTabs() {
            int tabsBefore = ObjectRepository.Driver.WindowHandles.Count;
            NavigationHelper.OpenNewTab();
            int tabsAfter = ObjectRepository.Driver.WindowHandles.Count;
            Assert.AreEqual(tabsBefore + 1, tabsAfter);
        }

        [TestMethod]
        public void CloseTabAndCheckNulberOfTabs()
        {
            NavigationHelper.OpenNewTab();
            int tabsBefore = ObjectRepository.Driver.WindowHandles.Count;
            NavigationHelper.CloseTab();
            int tabsAfter = ObjectRepository.Driver.WindowHandles.Count;
            Assert.AreEqual(tabsBefore - 1, tabsAfter);
        }

        [TestMethod]
        public void SwitchToTabAndCheckTitle()
        {
            int tabsBefore = ObjectRepository.Driver.WindowHandles.Count - 1;
            NavigationHelper.NavigateToUrl("Https://www.google.com");
            NavigationHelper.OpenNewTab();
            NavigationHelper.NavigateToHomePage();
            NavigationHelper.SwitchToTab(tabsBefore);
            Assert.AreEqual("Google", PageHelper.GetPageTitle());
        }
    }
}
