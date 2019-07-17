using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.Core.Entities;
using GameStore.Core.ServiceInterfaces;
using GameStore.PL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpPost("Game/{gameId}/comments")]
        public async Task<IActionResult> AddComentToGame(CreateCommentViewModel commentViewModel)
        {
            var comment = _mapper.Map<Comment>(commentViewModel);
            return Ok(await _commentService.CreateAsync(comment));
        }

        [HttpGet("Game/{gameId}/comments")]
        public async Task<IActionResult> GetCommentsForGame(int gameId)
        {
            return Ok(await _commentService.GetGameCommentsAsync(gameId));
        }

        [HttpPost("{parentCommentId}/comments")]
        public async Task<IActionResult> ReplyOnComment(ReplyCommentViewModel replyComment)
        {
            var comment = _mapper.Map<Comment>(replyComment);
            return Ok(await _commentService.CreateAsync(comment));
        }
    }
}