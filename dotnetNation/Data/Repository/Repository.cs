﻿using dotnetNation.Models;

namespace dotnetNation.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Post> GetAllPosts(int id)
        {
            return _ctx.Posts.ToList();
        }

        public Post GetPost(int id)
        {
            return _ctx.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);
        }

        public void RemovePost(int id)
        {
            _ctx.Posts.Remove(GetPost(id));
        }

        public void UpdatePost(Post post)
        {
            _ctx.Posts.Update(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
                return true;

            return false;
        }
    }
}
