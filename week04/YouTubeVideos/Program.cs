using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>
        {
            new Video("A Guide to Home Gardening", "Green Thumb", 645),
            new Video("Five-Minute Pasta Dinner", "Kitchen Made Easy", 318),
            new Video("Beginner's Guide to Photography", "Frame by Frame", 812)
        };

        videos[0].AddComment(new Comment("Maya Chen", "The tips for growing herbs were very helpful."));
        videos[0].AddComment(new Comment("Jordan Lee", "I am going to try the tomato planters this weekend."));
        videos[0].AddComment(new Comment("Sam Rivera", "Great video for a first-time gardener."));

        videos[1].AddComment(new Comment("Alex Morgan", "This was quick and delicious."));
        videos[1].AddComment(new Comment("Taylor Brooks", "I added spinach and it turned out great."));
        videos[1].AddComment(new Comment("Casey Patel", "Perfect recipe for a busy weeknight."));

        videos[2].AddComment(new Comment("Riley Kim", "The explanation of aperture finally makes sense."));
        videos[2].AddComment(new Comment("Jamie Wilson", "Thanks for including examples with each setting."));
        videos[2].AddComment(new Comment("Avery Davis", "I learned a lot from this beginner guide."));

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Comments ({video.GetCommentCount()}):");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"  {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
