using System.Collections.Generic;

class Video
{
    private List<Comment> _comments;

    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }

    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }
}
