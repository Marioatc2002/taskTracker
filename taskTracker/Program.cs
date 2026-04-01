using taskTracker.Services;
bool exit = false;
do
{
    Header();
    Console.WriteLine("--------------------------------------------------");

    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. Update Task");
    Console.WriteLine("3. Delete Task");
    Console.WriteLine("4. Show Tasks");
    Console.WriteLine("5. Exit Tasks");
    try
    {
        TaskService taskService = new TaskService();
        int resultado;
        if (int.TryParse(Console.ReadLine(), out resultado))
        { 
            switch (resultado) 
            {
                case 1:
                    
                    Console.WriteLine("Ingresa el nombre de la tarea");
                    Console.Write("Tarea:");
                    string? Description = Console.ReadLine();                    
                    string result = taskService.Add(Description);
                    Console.WriteLine($"{result}");
                    Thread.Sleep(3000);
                    break;

                case 2:

                    Console.WriteLine("Ingresa la nueva desc");
                    string des = Console.ReadLine();
                    Console.WriteLine("Ingresa su nuevo estatus \n 1-To Do \n 2-In progress \n 3-Done");
                    int status = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el Id");
                    int id = int.Parse(Console.ReadLine());
                    string r = taskService.Update(id, des, status);
                    Console.WriteLine(r);
                    Thread.Sleep(3000);

                    break;
                    

                case 3:

                    Console.WriteLine("Ingresa el Id que deseas borrar");
                    int Id = int.Parse(Console.ReadLine());
                    Console.WriteLine(taskService.Delete(Id));
                    Thread.Sleep(3000);

                    break;

                case 4:
                    Console.WriteLine(taskService.ShowTasks());
                    Thread.Sleep(8000);
                    break;

                case 5:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, ingresa un número del 1 al 5.");
                    Thread.Sleep(3000);
                    break;

            }

        }
    
    }catch (Exception ex)
    {
        Console.WriteLine("Valor no valido, ingresa uno correcto");
        
    }

    Console.Clear();
} while (exit != true);


void Header()
{
    Console.WriteLine(@"


$$$$$$$$\                  $$\                                                                                                                $$\     
\__$$  __|                 $$ |                                                                                                               $$ |    
   $$ | $$$$$$\   $$$$$$$\ $$ |  $$\       $$$$$$\$$$$\   $$$$$$\  $$$$$$$\   $$$$$$\   $$$$$$\   $$$$$$\  $$$$$$\$$$$\   $$$$$$\  $$$$$$$\ $$$$$$\   
   $$ | \____$$\ $$  _____|$$ | $$  |      $$  _$$  _$$\  \____$$\ $$  __$$\  \____$$\ $$  __$$\ $$  __$$\ $$  _$$  _$$\ $$  __$$\ $$  __$$\\_$$  _|  
   $$ | $$$$$$$ |\$$$$$$\  $$$$$$  /       $$ / $$ / $$ | $$$$$$$ |$$ |  $$ | $$$$$$$ |$$ /  $$ |$$$$$$$$ |$$ / $$ / $$ |$$$$$$$$ |$$ |  $$ | $$ |    
   $$ |$$  __$$ | \____$$\ $$  _$$<        $$ | $$ | $$ |$$  __$$ |$$ |  $$ |$$  __$$ |$$ |  $$ |$$   ____|$$ | $$ | $$ |$$   ____|$$ |  $$ | $$ |$$\ 
   $$ |\$$$$$$$ |$$$$$$$  |$$ | \$$\       $$ | $$ | $$ |\$$$$$$$ |$$ |  $$ |\$$$$$$$ |\$$$$$$$ |\$$$$$$$\ $$ | $$ | $$ |\$$$$$$$\ $$ |  $$ | \$$$$  |
   \__| \_______|\_______/ \__|  \__|      \__| \__| \__| \_______|\__|  \__| \_______| \____$$ | \_______|\__| \__| \__| \_______|\__|  \__|  \____/ 
                                                                                       $$\   $$ |                                                     
                                                                                       \$$$$$$  |                                                     
                                                                                        \______/                                                      
");
    

}