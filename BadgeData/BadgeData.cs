using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BadgeData
{
    public int BadgeID { get; set; }
    public List<string> DoorAccess { get; set; }
    public BadgeData(){}
    public BadgeData(int badgeID, List<string> doorAccess)
    {
        BadgeID = badgeID;
        DoorAccess = doorAccess;
    }
}
