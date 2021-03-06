﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupCreationTests : AuthBaseClassTest
    {
        public static IEnumerable<DataGroup> RandomGroupDataProvider()
        {
            List<DataGroup> groups = new List<DataGroup>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new DataGroup(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }



        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreation(DataGroup group)
        {

            List<DataGroup> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<DataGroup> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }


        [Test]
        public void BadNameGroupCreation()
        {
            DataGroup group = new DataGroup("a'a");
            group.Header = "";
            group.Footer = "";

            List<DataGroup> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<DataGroup> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

