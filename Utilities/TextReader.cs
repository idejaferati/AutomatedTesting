using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceQA.Utilities
{
    internal class TextReader
    {
        string filePath = "../../../Utilities/config.txt";


        public Config GetData ()
        {
            var config = new Config();

            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string line;

                while((line = streamReader.ReadLine()) != null)
                {
                    var configName = line.Split("=")[0];
                    var configValue = line.Split("=")[1];
                    switch (configName)
                    {
                        case "firstname":
                            config.firstName = configValue; break;
                        case "lastName":
                            config.lastName = configValue; break;
                        case "gender":
                            config.gender = configValue; break;
                        case "birthDate":
                            config.birthDate = configValue; break;
                        case "userEmail":
                            config.userEmail = configValue; break;
                        case "userPassword":
                            config.userPassword = configValue; break;
                        case "municipality":
                            config.municipality = configValue; break;
                    }
                
                }
            }

            return config;       
        }
    }

    public class Config
    {
        public  string firstName = "Ideja";

        public  string lastName = "Ferati";

        public  string gender = "Female";

        public  string birthDate = "03122003";

        public  string userEmail = "ideja@gmail.com";

        public  string userPassword = "P@ssw0rd";

        public  string municipality = "Prishtinë";
    }

    
}