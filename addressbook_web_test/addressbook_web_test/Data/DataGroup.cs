﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTest
{
    public class DataGroup : IEquatable<DataGroup>, IComparable<DataGroup>
    {

        public DataGroup(string name)
        {
            Name = name;
        }

        public bool Equals(DataGroup other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name = " + Name + "\nheader = " + Header + "\nfooter = " + Footer;
        }

        public int CompareTo(DataGroup other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }


        public string Name { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }

        public string Id { get; set; }
    }
}
