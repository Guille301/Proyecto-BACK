using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Atleta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public Pais Pais { get; set; }

        public List<Disciplina> Disciplinas { get; set; }

        public Atleta()
        {
            Disciplinas = new List<Disciplina>(); 
        }

        public Atleta(string nombre, string apellido, string sexo, Pais pais)
        {
            Nombre = nombre;
            Apellido = apellido;
            Sexo = sexo;
            Pais = pais;
            Disciplinas = new List<Disciplina>(); 
        }

        // Método para agregar
        public void AsignarDisciplina(Disciplina d)
        {
            Disciplinas.Add(d);
        }

        // Obtener lista
        public List<Disciplina> GetAsignarDisciplina()
        {
            return Disciplinas;
        }
    }

}
