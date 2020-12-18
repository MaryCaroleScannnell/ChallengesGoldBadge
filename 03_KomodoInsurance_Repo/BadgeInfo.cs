using System;
using System.Collections.Generic;

namespace _03_KomodoInsurance_Repo
{
    public class BadgeInfo
    {
        public int BadgeID { get; set; }
        public List<string> ListOfDoorNames { get; set; }

        public BadgeInfo() { }
        public BadgeInfo(int badgeID, List<string> listOfDoorNames)
        {
            BadgeID = badgeID;
            ListOfDoorNames = listOfDoorNames;

        }
    }
}
