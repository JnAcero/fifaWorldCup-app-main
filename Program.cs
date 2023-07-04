using fifaWorldCup_app.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        Controller controller = new Controller();
        bool isRunApp = true;
        int opcion = 0;
        do
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1.Registro de equipos\n2.Ver equipos\n3.Registro Personas\n4.Mostrar Personas\n5.Salir");
            opcion = Convert.ToInt32(Console.ReadLine());
            bool continuar = true;
            switch (opcion)
            {
                case 1:
                    controller.CreateTeams();
                    break;
                case 2:
                    ImprimirValores(controller.AllCollection());
                    break;
                case 3:
                    do
                    {
                        Console.WriteLine("1.Registrar Jugadores\n2.Registrar equipo tecnico\n3.Registrar personal medico\n4.Salir");
                        int opcionn = Convert.ToInt32(Console.ReadLine());
                        if(opcion == 4) continuar = false;
                        Console.WriteLine("Ingrese el nombre del Equipo: ");
                        string nombre_equipo = (Console.ReadLine() ?? string.Empty).ToLower();
                        IEnumerable<Teams> objetosEquipo = controller.GetTeamByName(nombre_equipo);
                        if(objetosEquipo.Count() != 1){
                            Console.WriteLine("Este equipo no esta registrado");
                            continuar = false;
                        }
                        switch (opcionn)

                        {
                            case 1:

                                //Se ingresan los datos del jugador 
                                try
                                { 
                                    Player jugador = Player.RegistroPlayer();
                                    if (objetosEquipo.Count() == 1)
                                    {
                                        foreach (Teams equipo in objetosEquipo)
                                        {
                                            equipo.Players.Add(jugador);
                                        }
                                        controller.saveDataFile();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Este equipo no esta registrado");
                                    }
                                    break;
                                }
                                catch (Exception e)
                                {

                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case 2:
                            try{
                                if(objetosEquipo.Count() == 1){
                                    TeamTechnical tecnico = TeamTechnical.RegistroTechTeam();
                                foreach (Teams equipo in objetosEquipo)
                                {
                                    equipo.Technicals.Add(tecnico);
                                }
                                controller.saveDataFile();
                                }else{
                                    Console.WriteLine("Este equipo no esta registrado");
                                }
                                 break;
                                
                            }catch(Exception e){
                                Console.WriteLine(e.Message);    
                            }
                            break;
                            case 3:
                            try{
                                TeamMedical medico = TeamMedical.RegistroMedicalTeam();
                                foreach (Teams equipo in objetosEquipo)
                                {
                                    equipo.Medicals.Add(medico);

                                }
                                controller.saveDataFile();
                                break;

                            }catch(Exception e){
                                Console.WriteLine(e.Message);
                            }
                            break;

                            case 4:
                                continuar = false;
                                break;
                            default:
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error opcion no Valida");
                                break;
                        }

                    } while (continuar);
                    break;
                case 4:
                    controller.mostrarPersonas();
                    break;
                case 5:
                    isRunApp = false;
                    break;
                 default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error opcion no Valida");
                    break;

            }
        } while (isRunApp);

        // bool isAddTeam = true;
        // do{

        //     do{
        //         Console.Clear();
        //         Player player= new Player();
        //         team.Players.Add(player.RegistroPlayer());
        //         Console.WriteLine("Desea agregar un nuevo jugador: Enter(Si) y Escape(No)");
        //         if(Console.ReadKey().Key == ConsoleKey.Escape){
        //             isAddPerson=false;
        //         }
        //     }while(isAddPerson);
        //     do{
        //         Console.Clear();
        //         TeamMedical medico= new TeamMedical();
        //         team.Medicals.Add(medico.RegistroMedicalTeam());
        //         Console.WriteLine("Desea agregar un nuevo Especialista MD: Enter(Si) y Escape(No)");
        //         if(Console.ReadKey().Key == ConsoleKey.Escape){
        //             isAddPerson=false;
        //         }
        //     }while(isAddPerson);
        //     do{
        //         Console.Clear();
        //         TeamTechnical tecnico= new TeamTechnical();
        //         team.Technicals.Add(tecnico.RegistroTechTeam());
        //         Console.WriteLine("Desea agregar un nuevo Experto Tecnico: Enter(Si) y Escape(No)");
        //         if(Console.ReadKey().Key == ConsoleKey.Escape){
        //             isAddPerson=false;
        //         }
        //     }while(isAddPerson);
        //     Console.WriteLine("Desea agregar un nuevo Equipo: Enter(Si) y Escape(No)");
        //     if(Console.ReadKey().Key == ConsoleKey.Escape){
        //             isAddTeam=false;
        //     }
        //     teams.Add(team);
        // }while(isAddTeam);

        // // foreach(Teams team in teams){
        // //     foreach(Player player in team.Players){
        // //         Console.WriteLine(player.NamePlayer);
        // //     }
        // // }

        // teams.ForEach(team =>
        //     team.Players.ForEach(player => 
        //         Console.WriteLine(player.NamePlayer)
        //     )
        // );
    }
    private static void ImprimirValores(IEnumerable<Teams> teams)
    {
        Console.WriteLine(teams.Count());
        Console.ReadKey();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("{0,-20} {1,20}", "Cod. Equipo", "Nombre Equipo");
        foreach (Teams team in teams)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0,-20} {1,17}", team.IdTeam, team.NameTeam);

        }
        Console.ReadKey();
    }

}