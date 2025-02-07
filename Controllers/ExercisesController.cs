using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using VorgrakTARpe23.Model;
using static VorgrakTARpe23.Model.Exercise;

namespace VorgrakTARpe23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly DataContext _context;

        public ExercisesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetExercises([FromQuery] ExerciseIntensity? intensity)
        {
            if (intensity.HasValue)
            {
                return Ok(_context.ExerciseList?.Where(x => x.Intensity == Intensity.Value));
            }
            return Ok(_context.ExerciseList);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetails (int? id )
        {
            var exercise = _context.ExerciseList?.FirstOrDefault(e => e.Id == id);
            {
                return NotFound();
            }
            return Ok(exercise);
        }
        
        [HttpGet("{id}")]
        public IActionResult Create([FromBody] Exercise exercise)
        {
            var dbExercise = _context.ExerciseList?.First(exercise.Id);
            if (dbExercise == null)
            {
                _context.Add(exercise);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetDetails), new { Id = exercise.Id }, exercise); 
            }
            else
            {
                return Conflict();  
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult Update(int? id, [FromBody] Exercise exercise)
        {
            
            if (id != exercise.Id || !_context.ExerciseList!.Any(e => e.Id == id))
            {

                return NotFound();
            }
            _context.Add(exercise);
            _context.SaveChanges();

            return NoContent();
           
        }   

        
    }
}
