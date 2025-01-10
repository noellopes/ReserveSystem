﻿namespace ReserveSystem.Models
{
    public class TQePrecosPageInfo
    {
            public int TotalRoomTypes { get; set; }

            public int PageSize { get; set; } = 10;
            public int CurrentPage { get; set; } = 1;
            public int MaxPagesShowBeforeAfter { get; set; } = 4;

            public int TotalPages => (int)Math.Ceiling((double)TotalRoomTypes / PageSize);

            public int FirstPageShow => Math.Max(1, CurrentPage - MaxPagesShowBeforeAfter);

            public int LastPageShow => Math.Min(TotalPages, CurrentPage + MaxPagesShowBeforeAfter);
        
    }
}
