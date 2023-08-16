﻿using AutoMapper;
using BookStore.DbOperations;
using BookStore.Entities;
using System;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Name == Model.Name);
            if(author is not null)
            {
                throw new InvalidOperationException("Boy bir yazar mevcut");
            }
            author = _mapper.Map<Author>(author);
            _context.Authors.Add(author);
            _context.SaveChanges();

        }

        public class CreateAuthorModel{
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
        }
    }
}
