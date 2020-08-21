using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class BadgeRepo
    {
        //C
        Dictionary<int, List<string>> _badgeNumbers = new Dictionary<int, List<string>>();
        public void SeedMethod()
        {

            _badgeNumbers.Add(1, new List<string> { "A1", "A2" });
            _badgeNumbers.Add(2, new List<string> { "A2", "A3" });
            _badgeNumbers.Add(3, new List<string> { "A3", "B1" });
        }
        public void AddBadge(int badgeID, List<string>doors)
        {
            _badgeNumbers.Add(badgeID, doors);
        }

        //R
        public Dictionary<int, List<string>>ViewAllBadges()
        {
            return _badgeNumbers;
        }

        public Badge GetBadgeByID(int id)
        {
            foreach (var item in _badgeNumbers)
            {
                if (item.Key == id)
                {
                    return new Badge(item.Key, item.Value);
                   
                }
            }
            return null;
        }

        //U
        public bool UpdateBadge(Badge newBadge, int oldID)
        {       

            if (_badgeNumbers.ContainsKey(oldID))
            {

                // item.Key = newBadge.ID;
                _badgeNumbers[oldID] = newBadge.Access;

                _badgeNumbers[newBadge.ID] = newBadge.Access;

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasKey(int key)
        {
            bool validKey = _badgeNumbers.ContainsKey(key);
            if (validKey)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //D
        public void DeleteBadge(int badgeID)
        {
            _badgeNumbers[badgeID].Clear();
        }

    }
}


