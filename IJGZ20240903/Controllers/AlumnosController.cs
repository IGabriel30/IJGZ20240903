using Microsoft.AspNetCore.Mvc;

//agregar el using para usar la clase Alumno
using IJGZ20240903.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IJGZ20240903.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        //declaración de lista estatica de objetos  
        //Alumno para almacenar alumnos
        static List<Alumno> alumnos = new List<Alumno>();
        //definicion metodo HTTP GET que devuelve coleccion de alumnos
        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return alumnos;
        }

        //metodo get que recibe un id como parametro y devuelve un alumo especifico
        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            var alumno  = alumnos.FirstOrDefault(c => c.Id == id);
            return alumno;
        }

        // metodo post
        //para agregar nuevo alumno
        [HttpPost]
        public IActionResult Post([FromBody] Alumno alumno)
        {
            alumnos.Add(alumno);
            return Ok();
        }

        // metodo PUT para actualizar alumno existente por su id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Alumno alumno)
        {
            var existAlumno = alumnos.FirstOrDefault(c => c.Id == id);

            if (existAlumno != null) { 
                existAlumno.Nombe = alumno.Nombe;
                existAlumno.Apellido = alumno.Apellido;
                existAlumno.Direccion = alumno.Direccion;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // se define metodo HTTP Delete
        //para eliminar por id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingAlumno = alumnos.FirstOrDefault(c => c.Id == id);
            if (existingAlumno != null) 
            {
                alumnos.Remove(existingAlumno);
                return Ok();
            }
            else
            {
                return NotFound();
            }
          
        }
    }
}
