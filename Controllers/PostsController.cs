using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private static List<Post> _posts = new List<Post>();

    // GET: api/posts
    [HttpGet]
    public ActionResult<IEnumerable<Post>> Get()
    {
        return _posts;
    }

    // GET api/posts/{id}
    [HttpGet("{id}")]
    public ActionResult<Post> Get(int id)
    {
        var post = _posts.Find(p => p.Id == id);
        if (post == null)
        {
            return NotFound();
        }
        return post;
    }

    // POST api/posts
    [HttpPost]
    public ActionResult<Post> Post([FromBody] Post post)
    {
        post.Id = _posts.Count + 1;
        post.PostedAt = DateTime.Now;
        _posts.Add(post);
        return CreatedAtAction(nameof(Get), new { id = post.Id }, post);
    }
}
