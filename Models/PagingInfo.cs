namespace ReserveSystem.Models {

    public class PagingInfo {
        public int TotalItems { get; set; }
        
        // Default page size is 10 items per page
        public int PageSize { get; set; } = 10;
        
        // Default current page is 1
        public int CurrentPage { get; set; } = 1;

        // Use the Ceiling method from the Math class to round up to the nearest whole number so as to avoid partial pages
        public int TotalPages => (int) Math.Ceiling((double)TotalItems / PageSize);

        // Max pages to display in the pagination bar
        public int MaxPagesBeforeAndAfter { get; set; } = 4;

        // Calculate the start page and end page
        public int StartPage => Math.Max(1, CurrentPage - MaxPagesBeforeAndAfter);

        public int EndPage => Math.Min(TotalPages, CurrentPage + MaxPagesBeforeAndAfter);
    }
}