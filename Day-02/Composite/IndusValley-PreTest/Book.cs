using System;

namespace IndusValley_PreTest
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PubDate { get; set; }
        public decimal Cost { get; set; }
        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}", this.Id, this.Title, this.PubDate, this.Cost);
        }
    }
}