using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica8
{
    public class TESHDatos
    {
        long matricula;
        string nombre;
        string apellidos;
        string direccion;
        long telefono;
        string carrera;
        string semestre;
        string correo;
        string github;


        //json
        //[JsonProperty(PropertyName="id")]
        [PrimaryKey, Unique, MaxLength(10)]
        public long Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }
        [Column("Nombre"), MaxLength(20)]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        [Column("Apellidos"), MaxLength(40)]
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        [Column("Direccion"), MaxLength(40)]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        [Column("Telefono"), MaxLength(10)]
        public long Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        [Column("Carrera"), MaxLength(10)]
        public string Carrera
        {
            get { return carrera; }
            set { carrera = value; }
        }
        [Column("Semestre"), MaxLength(10)]
        public string Semestre
        {
            get { return semestre; }
            set { semestre = value; }
        }
        [Column("Correo"), MaxLength(10)]
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        [Column("GitHub"), MaxLength(10)]
        public string Github
        {
            get { return github; }
            set { github = value; }
        }
    }
}
