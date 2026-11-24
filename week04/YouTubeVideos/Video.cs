using System.Collections.Generic;

class Video
{
    private readonly List<Comment> _comments = new List<Comment>();

    public string Title { get; }
    public string Author { get; }
    public int LengthSeconds { get; }
    public IReadOnlyList<Comment> Comments => _comments;

    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }
}
