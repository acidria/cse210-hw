using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("A Guide to Home Gardening", "Green Thumb", 645);
        video1.AddComment(new Comment("Maya Chen", "The tips for growing herbs were very helpful."));
        video1.AddComment(new Comment("Jordan Lee", "I am going to try the tomato planters this weekend."));
        video1.AddComment(new Comment("Sam Rivera", "Great video for a first-time gardener."));

        Video video2 = new Video("Five-Minute Pasta Dinner", "Kitchen Made Easy", 318);
        video2.AddComment(new Comment("Alex Morgan", "This was quick and delicious."));
        video2.AddComment(new Comment("Taylor Brooks", "I added spinach and it turned out great."));
        video2.AddComment(new Comment("Casey Patel", "Perfect recipe for a busy weeknight."));

        Video video3 = new Video("Beginner's Guide to Photography", "Frame by Frame", 812);
        video3.AddComment(new Comment("Riley Kim", "The explanation of aperture finally makes sense."));
        video3.AddComment(new Comment("Jamie Wilson", "Thanks for including examples with each setting."));
        video3.AddComment(new Comment("Avery Davis", "I learned a lot from this beginner guide."));

        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length: " + video.LengthSeconds + " seconds");
            Console.WriteLine("Comments (" + video.GetCommentCount() + "):");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine("  " + comment.CommenterName + ": " + comment.Text);
            }

            Console.WriteLine();
        }
    }
}
