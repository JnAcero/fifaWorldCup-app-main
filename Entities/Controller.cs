using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace fifaWorldCup_app.Entities
{
    public class Controller
    {
        private List<Teams> lstTeams = new List<Teams>();
        public Controller(){
            if(!ExistsFile()){
                CrearFile();
            }else{
                using(StreamReader reader = new StreamReader("fifawc.json")){
                    string json = reader.ReadToEnd();
                    this.lstTeams = System.Text.Json.JsonSerializer
                    .Deserialize<List<Teams>>(json,new System.Text.Json.JsonSerializerOptions()
                     {PropertyNameCaseInsensitive = true}) ?? new List<Teams>();
                }  
            }
        }
        public bool ExistsFile(){
            bool isValid = true;
            if(File.Exists("fifawc.json")){
                isValid = true;
            }else{
                isValid = false;
            }
            return isValid;
        }
        public void CrearFile(){
            File.Create("fifawc.json");
        }

        public List<Teams> LstTeams { get => lstTeams; set => lstTeams = value; }

        public IEnumerable<Teams> AllCollection(){
            return LstTeams;
        }
        public void CreateTeams(){
            Teams team= new Teams();
            Console.WriteLine("Ingrese Codigo Equipo:");
            team.IdTeam = Console.ReadLine();
            Console.WriteLine("Ingrese Nombre Equipo:");
            team.NameTeam = (Console.ReadLine() ?? string.Empty).ToLower(); 
            LstTeams.Add(team);
            saveDataFile();
            Console.WriteLine(LstTeams.Count);
            Console.ReadKey(); 
        }
        public void mostrarPersonas(){
            bool active = true;

            while(active){
   
            Console.WriteLine("1.Ver Jugadores\n2.Ver Cuerpo Tecnico\n3.Ver Cuerpo medico\n4.Ver todo\n5.Salir");
            int opcion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre del Pais del que desea ver las personas:");
            string nombre = (Console.ReadLine() ?? string.Empty).ToLower();
            IEnumerable<Teams> equipoSelect = GetTeamByName(nombre);
             if(equipoSelect.Count() != 1){
                    Console.WriteLine("Este equipo no esta registrado, presione enter");
                    Console.ReadLine();
                    break;
                 }
            switch(opcion){
                case 1:
                    foreach(Teams equipo in equipoSelect){
                        if(equipo.Players.Count() == 0){
                            Console.Write("No hay jugadores registrados");
                            Console.ReadLine();
                            break;
                        }
                        foreach(Player jugador in equipo.Players){
                            Console.WriteLine(
                                "Nombre:............ {0}\n"+
                                "Numero dorsal:..... {1}\n"+
                                "Edad:.............. {2}\n"+
                                "Posicion de juego:. {3}\n"+
                                "----------***-------------",
                                jugador.NamePlayer,jugador.IdPlayer,jugador.AgePlayer,jugador.PositionPlayer
                            );
                        }
                    }
                    break;  
                case 2:
                    foreach(Teams equipo in equipoSelect){
                         if(equipo.Technicals.Count() == 0){
                            Console.Write("No hay equipo tecnico registrado.");
                            Console.ReadLine();
                            break;
                        } 
                        foreach(TeamTechnical tecnico in equipo.Technicals){
                            Console.WriteLine(
                                "Nombre:............ {0}\n"+
                                "Numero Id:......... {1}\n"+
                                "Edad:.............. {2}\n"+
                                "Cargo o posicion:.. {3}\n"+
                                 "----------***-------------",
                                tecnico.NameTeamTechnical,tecnico.IdTeamTechnical,tecnico.AgeTeamTechnical,tecnico.RolTeamTechnical
                                
                            );
                        }
                    }

                    break;
                case 3:
                    foreach(Teams equipo in equipoSelect){
                        if(equipo.Medicals.Count() == 0){
                            Console.Write("No hay equipo medico registrado.");
                            Console.ReadLine();
                            break;
                        } 
                        foreach(TeamMedical medico in equipo.Medicals){
                            Console.WriteLine(
                                "Nombre:............... {0}\n"+
                                "Numero Id:............ {1}\n"+
                                "Edad:................. {2}\n"+
                                "Especialidad medica:.. {3}\n"+
                                "----------***-------------",
                                medico.NameTeamMedical,medico.IdTeamMedical,medico.AgeTeamMedical,medico.RolTeamMedical
                                
                            );
                        }
                    }

                    break;
                case 4:
                    foreach( Teams equipo in equipoSelect){
                        Console.WriteLine("Equipo : {0}",equipo.NameTeam);
                    }
                    
                    Console.WriteLine("Lista de Jugadores");
                    foreach(Teams equipo in equipoSelect){
                        if(equipo.Players.Count() == 0){
                            Console.Write("No hay jugadores registrados");
                            Console.ReadLine();
                            break;
                        }
                        foreach(Player jugador in equipo.Players){
                            Console.WriteLine(
                                "Nombre:............ {0}\n"+
                                "Numero dorsal:..... {1}\n"+
                                "Edad:.............. {2}\n"+
                                "Posicion de juego:. {3}\n"+
                                "----------***-------------",
                                jugador.NamePlayer,jugador.IdPlayer,jugador.AgePlayer,jugador.PositionPlayer
                                
                            );
                        }
                    }
                    Console.WriteLine("Lista del cuerpo Tecnico");
                    foreach(Teams equipo in equipoSelect){
                        if(equipo.Technicals.Count() == 0){
                            Console.Write("No hay equipo tecnico registrado.");
                            Console.ReadLine();
                            break;
                        } 
                        foreach(TeamTechnical tecnico in equipo.Technicals){
                            Console.WriteLine(
                                "Nombre:............ {0}\n"+
                                "Numero Id:......... {1}\n"+
                                "Edad:.............. {2}\n"+
                                "Cargo o posicion:.. {3}\n"+
                                 "----------***-------------",
                                tecnico.NameTeamTechnical,tecnico.IdTeamTechnical,tecnico.AgeTeamTechnical,tecnico.RolTeamTechnical
                                
                            );
                        }
                    }
                    Console.WriteLine("Lista del cuerpo Medico");
                    foreach(Teams equipo in equipoSelect){
                        if(equipo.Medicals.Count() == 0){
                            Console.Write("No hay equipo medico registrado.");
                            Console.ReadLine();
                            break;
                        } 
                        foreach(TeamMedical medico in equipo.Medicals){
                            Console.WriteLine(
                                "Nombre:............... {0}\n"+
                                "Numero Id:............ {1}\n"+
                                "Edad:................. {2}\n"+
                                "Especialidad medica:.. {3}\n"+
                                "----------***-------------",
                                medico.NameTeamMedical,medico.IdTeamMedical,medico.AgeTeamMedical,medico.RolTeamMedical
                            );
                        }
                    }

                    break;
                case 5:
                    active = false;
                    break;
            }
            }      
        }
        public IEnumerable<Teams> GetTeamByName(string name){
            return LstTeams.Where(equipo => equipo.NameTeam == name );
    }
        public void saveDataFile(){
            string json = JsonConvert.SerializeObject(lstTeams,Formatting.Indented);
            File.WriteAllText("fifawc.json",json);
        }
}
}