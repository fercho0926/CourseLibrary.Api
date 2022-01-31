using AutoMapper;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Controllers
{
 [ApiController]
 [Route("api/authors/{authorId}/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseLibraryRepository courseLibraryRepository;
        private readonly IMapper mapper;

        public CoursesController(ICourseLibraryRepository _courseLibraryRepository, 
            IMapper _mapper)
        {
            courseLibraryRepository = _courseLibraryRepository;
            mapper = _mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetCoursesForAuthor(Guid authorId) {
            //Check if the author exist
            if (!courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }
            var coursesForAuthorFromRepo = courseLibraryRepository.GetCourses(authorId);
            return Ok(mapper.Map<IEnumerable<CourseDto>>(coursesForAuthorFromRepo));
        }

        [HttpGet("{courseId}")]
        public ActionResult<CourseDto> GetCourseForAuthor(Guid authorId, Guid courseId) {

            //Check if the author exist
            if (!courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var courseforAuthorFromRepo = courseLibraryRepository.GetCourse(authorId, courseId);

            if (courseforAuthorFromRepo == null) {
                return NotFound();
            }

            return Ok(mapper.Map<CourseDto>(courseforAuthorFromRepo));


           


        }




    }
}
