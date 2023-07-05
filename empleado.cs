namespace moduloTodo
{
    public enum listaNombres
    {
        Juan,
        Maria,
        Carlos,
        Sofia,
        Alejandro,
        Ana,
        Luis,
        Laura,
        Diego,
        Marta
    }

    public enum listaApellidos
    {
        Gomez,
        Lopez,
        Rodriguez,
        Fernandez,
        Torres,
        Sanchez,
        Ramirez,
        Garcia,
        Morales,
        Castro
    }

    enum listaTareas
    {
        diseñoLogo,
        cargarDatos,
        atencionCliente,
        crearAppAndroid,
        crearAppIos,
        copiarBD,
        clonarBD,
        resetearHost,
        hostearWeb
    }

    class Tarea
    {
        private int id;
        private string descripcion;
        private int duracion;//10-100

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Duracion { get => duracion; set => duracion = value; }

        public static Tarea Aleatoria()
        {
            Random rand = new Random();
            Tarea nuevaTarea = new Tarea();
            nuevaTarea.Id = rand.Next(10000, 99999);
            nuevaTarea.Descripcion = Enum.GetName(typeof(listaTareas), rand.Next(1, Enum.GetNames(typeof(listaTareas)).Length));
            nuevaTarea.Duracion = rand.Next(10, 100);
            return nuevaTarea;
        }
    }

    class Empleado
    {
        private string nombre;
        private string apellido;
        private List<Tarea> tareaPendiente;
        private List<Tarea> tareaRealizadas;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public List<Tarea> TareaPendiente { get => tareaPendiente; set => tareaPendiente = value; }
        public List<Tarea> TareaRealizadas { get => tareaRealizadas; set => tareaRealizadas = value; }

        public static Empleado CrearEmpleado(int N)
        {
            Empleado empleado = new Empleado();
            List<Tarea> tareasRand = new List<Tarea>();
            Random rand = new Random();

            empleado.Nombre = Enum.GetName(typeof(listaNombres), rand.Next(1, Enum.GetNames(typeof(listaNombres)).Length));
            empleado.Apellido = Enum.GetName(typeof(listaApellidos), rand.Next(1, Enum.GetNames(typeof(listaApellidos)).Length));

            for (int i = 0; i < N; i++)
            {
                tareasRand.Add(Tarea.Aleatoria());
            }
            empleado.TareaPendiente = tareasRand;
            empleado.TareaRealizadas = new List<Tarea>();
            return empleado;
        }

        public void MoverTareaPendienteARealizada(int idTarea)
        {
            Tarea tarea = TareaPendiente.Find(t => t.Id == idTarea);
            if (tarea != null)
            {
                TareaPendiente.Remove(tarea);
                TareaRealizadas.Add(tarea);
            }
        }

        public List<Tarea> BuscarTareasPendientesPorDescripcion(string descripcion)
        {
            return TareaPendiente.FindAll(t => t.Descripcion.Contains(descripcion));
        }

        public void GuardarSumarioHorasTrabajadas()
        {
            int sumatoriaDuracion = TareaRealizadas.Sum(t => t.Duracion);
            string nombreArchivo = $"{Nombre}_{Apellido}_SumarioHorasTrabajadas.txt";
            string contenido = $"Empleado: {Nombre} {Apellido}\nSumario de horas trabajadas: {sumatoriaDuracion} horas";
            
            File.WriteAllText(nombreArchivo,contenido);
        }
    }

    
}
