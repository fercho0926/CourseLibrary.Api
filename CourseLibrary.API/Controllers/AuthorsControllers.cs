using AutoMapper;
using CourseLibrary.API.Helpers;
using CourseLibrary.API.Models;
using CourseLibrary.API.ResourceParameters;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseLibrary.API.Controllers
{

    [ApiController]
    [Route("api/authors")]
    public class AuthorsControllers : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorsControllers(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ?? 
                throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors(
            [FromQuery] AuthorsResourceParameters authorsResourceParameters)
        {


            var authorsFronRepo = _courseLibraryRepository.GetAuthors(authorsResourceParameters);

            //var authors = new List<AuthorDto>();
            //foreach (var author in authorsFronRepo) ----- HANGED BY AUTOMAPPER
            //{
            //    authors.Add(new AuthorDto()
            //    {
            //        Id = author.Id,
            //        Name = $"{author.FirstName} {author.LastName}",
            //        MainCategory = author.MainCategory,
            //        age = author.DateOfBirth.GetCurrentAge()
            //    }); ;
            //}


            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFronRepo));
    }

    [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
    {


        var authorResult = _courseLibraryRepository.GetAuthor(authorId);

        if (authorResult == null)
        {
            return NotFound();
        }

       // return Ok(authorResult);
            return Ok(_mapper.Map<AuthorDto>(authorResult));

        }




    }
}
