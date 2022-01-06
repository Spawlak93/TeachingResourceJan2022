namespace Repository.Library
{
    //Introduce Enums maybe?
    public enum MaturityRating
    {
        G,
        PG,
        PG_13,
        R,
        NC_17
    }
    public class StreamingContent
    {
        //Constructors
        public StreamingContent() { }
        public StreamingContent(string title, string description, double starRating, MaturityRating maturityRating/* bool isFamilyFriendly*/)
        {
            Title = title;
            Description = description;
            StarRating = starRating;
            MaturityRating = maturityRating;
            // IsFamilyFriendly = isFamilyFriendly;
        }

        //Property
        //AccessModifier Type Name Getter Setter
        public string Title { get; set; }
        public string Description { get; set; }
        public double StarRating { get; set; }
        public MaturityRating MaturityRating { get; set; }
        public bool IsFamilyFriendly { get; set; }
        // public bool IsFamilyFriendly
        // {
        //     get
        //     {
        //         return (int)MaturityRating < 3;
        //     }
        // }
    }
}