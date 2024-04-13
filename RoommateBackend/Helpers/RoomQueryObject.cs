using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoommateBackend.Helpers
{
    public class RoomQueryObject
    {
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinRoomCount { get; set; }
        public int? MaxRoomCount { get; set; }
        public int? MinBathCount { get; set; }
        public int? MaxBathCount { get; set; }
        public double? MinSize { get; set; }
        public double? MaxSize { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 15;
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Town { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Distance { get; set; }
        public SortByProperty? SortBy { get; set; }
        public SortDirection SortDirection { get; set; } = SortDirection.Asc;
        public DateRange? DateRange { get; set; }
    }

    public enum SortByProperty
    {
        Price,
        RoomCount,
        BathCount,
        Size
    } 

    public enum SortDirection
    {
        Asc,
        Desc
    }

    public enum DateRange
    {
        Today,
        ThisWeek,
        ThisMonth,
        ThisYear
    }

}