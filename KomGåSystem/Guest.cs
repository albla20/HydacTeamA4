using System;
using System.Collections.Generic;
using System.Text;

namespace KomGåSystem
{
    public class Guest
    {
        private string _company;
        private bool _safetyFolderHandedOut;
        private string _name;
        private DateTime _arrivalTime;
        private DateTime _departureTime;
        private Employee _host;

        public Guest(string name, string company, Employee host, bool safetyFolderHandedOut)
        {
            _name = name;
            _company = company;
            _arrivalTime = DateTime.Now;
            _host = host;
            _safetyFolderHandedOut = safetyFolderHandedOut;
            IsPresent = true;

        }

        //backing field i baggrunden!!
        public bool IsPresent { get; set; }

        public DateTime DepartureTime
        {
            get => _departureTime;
            set => _departureTime = value;
        }

        public DateTime ArrivelTime
        {
            get => _arrivalTime;
            set => _arrivalTime = value;
        }

        public string Company => _company;

        public bool SafetyHolderHandedOut => _safetyFolderHandedOut;

        public Employee Host
        {
            get => _host;
            set => _host = value;
        }

        public string Name => _name;

        public string GetStatus()
        {
            string safetyFolderDA;
            if (_safetyFolderHandedOut)
                safetyFolderDA = "Ja";
            else
                safetyFolderDA = "Nej";

            return $"Navn: {_name,-14}Ankomst tid: {_arrivalTime,-20}Sikkerhedsfolder udleveret: {safetyFolderDA,-20}";
        }
        public void MarkSafetyFolderHandedOut()
        {
            _safetyFolderHandedOut = true;
        }

        public override string ToString()
        {
            return $"{_name}";
        }

    }
}
