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

        public Employee Host
        {
            get => _host;
            set => _host = value;
        } 
        public string GetStatus()
        {
            string safetyFolderDA;
            if (_safetyFolderHandedOut)
                safetyFolderDA = "Ja";
            else
                safetyFolderDA = "Nej";

            return $"Navn: {_name}\nAnkomst tid: {_arrivalTime}\nSikkerhedsfolder udleveret: {safetyFolderDA}";
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
