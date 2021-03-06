﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using BirthdayCelebrations.Core;
using MilitaryElite.IO.Contracts;

namespace BirthdayCelebrations
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {

            string command;
            List<IBirthable> birthdays = new List<IBirthable>();
            Citizen citizen = null;
            Pet pet = null;
            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cmdArgs[0] == "Citizen")
                {
                    string citizenName = cmdArgs[1];
                    int citizenAge = int.Parse(cmdArgs[2]);
                    string citizenId = cmdArgs[3];
                    DateTime citizenBirthday = DateTime.ParseExact(cmdArgs[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    citizen = new Citizen(citizenName, citizenAge, citizenId, citizenBirthday);
                    birthdays.Add(citizen);
                }
                else if (cmdArgs[0] == "Robot")
                {
                    string robotModel = cmdArgs[1];
                    string robotId = cmdArgs[2];
                    Robot robot = new Robot(robotModel, robotId);
                }
                else if (cmdArgs[0] == "Pet")
                {
                    string petName = cmdArgs[1];
                    DateTime petBirthday = DateTime.ParseExact(cmdArgs[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    pet = new Pet(petName, petBirthday);
                    birthdays.Add(pet);
                }
            }

            string specificYear = this.reader.ReadLine();
            if (birthdays.Any(x => x.GetBirthDay().EndsWith(specificYear ?? string.Empty)))
            {
                foreach (var id in birthdays.FindAll(x => x.GetBirthDay().EndsWith(specificYear)))
                {
                    this.writer.WriteLine(id.GetBirthDay());
                }
            }
            else
            {
                this.writer.WriteLine("");
            }

        }
    }
}