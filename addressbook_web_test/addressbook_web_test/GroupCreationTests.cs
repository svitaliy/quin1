﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupCreationTests : BaseClassTest
    {

        [Test]
        public void GroupCreation()
        {
            OpenPage();
            Login(new AccountData("admin", "secret"));
            OpenGroupPage();
            InitCreateGroup();

            GroupData group = new GroupData("test");
            group.Header = "test_header";
            group.Footer = "test_footer";

            FillGroupForm(group);
            OpenGroupPage();
        }
    }
}

