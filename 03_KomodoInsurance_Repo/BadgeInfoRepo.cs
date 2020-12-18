using System;
using System.Collections.Generic;
using System.Text;

namespace _03_KomodoInsurance_Repo
{
    public class BadgeInfoRepo
    {
        public Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        private List<string> _listDoors = new List<string>();

        //Create
        public void AddABadge(BadgeInfo badge)
        {
            _badgeDictionary.Add(badge.BadgeID, badge.ListOfDoorNames);
        }

        //Read
        public Dictionary<int, List<string>> GetBadgeList()
        {
            return _badgeDictionary;
        }


        //Update
        public bool UpdateDoors(int badgeNumb, List<string> listDoors)

        {
            if (_badgeDictionary.ContainsKey(badgeNumb))
            {
                _badgeDictionary[badgeNumb] = listDoors;
                return true;
            }
            return false;

        }

        //Delete
        public bool RemoveDoorFromList(int badgeNumb)
        {

            _badgeDictionary.Remove(badgeNumb);

            int intialCount = _badgeDictionary.Count;
            _badgeDictionary.Remove(badgeNumb);

            if (intialCount > _badgeDictionary.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
