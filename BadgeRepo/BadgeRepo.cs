using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BadgeRepo
{
    private Dictionary<int, List<string>> _doorAccess = new Dictionary<int, List<string>>();

    public Dictionary<int, List<string>> GetAllDoors()
    {
        return _doorAccess;
    }

    public void AddBadgeToDictionary(BadgeData badge)
    {
        _doorAccess.Add(badge.BadgeID, badge.DoorAccess);
    }

    public void AddDoorToBadge(int badgeID, string doorAccess)
    {
        List<string> doors = _doorAccess[badgeID];
        doors.Add(doorAccess);
    }

    public void RemoveDoorFromBadge(int badgeID, string doorAccess)
    {
        List<string> doors = _doorAccess[badgeID];
        doors.Remove(doorAccess);
    }
}
