using moduloTodo;

class Program
    {
        static void Main()
        {
            // Ejemplo de uso
            Empleado empleado = Empleado.CrearEmpleado(5);
            Console.WriteLine("Empleado: " + empleado.Nombre + " " + empleado.Apellido);
            Console.WriteLine("Tareas pendientes:");
            foreach (var tarea in empleado.TareaPendiente)
            {
                Console.WriteLine(tarea.Descripcion);
            }

            // Mover tarea pendiente a realizada
            Console.WriteLine("Ingrese el ID de la tarea a mover a realizadas:");
            int idTarea = Convert.ToInt32(Console.ReadLine());
            empleado.MoverTareaPendienteARealizada(idTarea);

            Console.WriteLine("Tareas pendientes actualizadas:");
            foreach (var tarea in empleado.TareaPendiente)
            {
                Console.WriteLine(tarea.Descripcion);
            }

            Console.WriteLine("Tareas realizadas:");
            foreach (var tarea in empleado.TareaRealizadas)
            {
                Console.WriteLine(tarea.Descripcion);
            }

            // Buscar tareas pendientes por descripción
            Console.WriteLine("Ingrese la descripción a buscar:");
            string descripcionBusqueda = Console.ReadLine();
            List<Tarea> tareasEncontradas = empleado.BuscarTareasPendientesPorDescripcion(descripcionBusqueda);

            Console.WriteLine("Tareas encontradas:");
            foreach (var tarea in tareasEncontradas)
            {
                Console.WriteLine(tarea.Descripcion);
            }

            // Guardar sumario de horas trabajadas
            empleado.GuardarSumarioHorasTrabajadas();

            Console.WriteLine("Sumario de horas trabajadas guardado en archivo.");

            Console.ReadLine();
        }
    }