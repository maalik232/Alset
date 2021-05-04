using Alset_Attendence_System.ViewModal;
using AlsetMobileAttendence.Modal;
using AlsetMobileAttendence.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace AlsetMobileAttendence.ViewModal
{
    public class DashBoardViewModal : BaseViewModal
    {

        ModuleService moduleService;
        List<Modules> Modules = new List<Modules>();
        private ObservableCollection<TimeSlot> subjectTimeSlot;
        public ObservableCollection<TimeSlot> SubjectTimeSlot
        {
            get => subjectTimeSlot;
            set
            {
                subjectTimeSlot = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SubjectTimeSlot)));
            }
        }


        private ObservableCollection<Modules> subjectModules;
        public ObservableCollection<Modules> SubjectModules
        {
            get => subjectModules;
            set
            {
                subjectModules = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SubjectModules)));
            }
        }

        public DashBoardViewModal()
        {
            moduleService = new ModuleService();
            Loader = true;
            loadClasses();
            loadModules();
            Loader = false;

        }
        List<TimeSlot> timeSlots = new List<TimeSlot>();

        public async void loadClasses()
        {
            var time =  await moduleService.GetClasses();

            foreach(var slot in time)
            {
                string date = slot.date.Substring(0, 10);
                string startTime = slot.start_time.Substring(10, 9);
                string endTime = slot.end_time.Substring(10, 9);
                slot.date = "Date :" + date;
                slot.start_time = "Start time :" + startTime;
                slot.end_time = "End time :" + endTime;
                timeSlots.Add(slot);
            }

            SubjectTimeSlot = new ObservableCollection<TimeSlot>(timeSlots);
        }

        public async void loadModules()
        {
            Modules = await moduleService.GetModules();
            SubjectModules = new ObservableCollection<Modules>(Modules);
        }

        public async void FilterClasses(string moduleID)
        {
            Loader = true;
            var time = await moduleService.GetClasses();
            var Module = time.Where(x => x.module_id == moduleID).ToList();
            foreach (var slot in Module)
            {
                string date = slot.date.Substring(0, 9);
                string startTime = slot.start_time.Substring(10, 9);
                string endTime = slot.end_time.Substring(10, 9);


                slot.date = "Date :" + date;
                slot.start_time = "Start time :" + startTime;
                slot.end_time = "End time :" + endTime;
                timeSlots.Add(slot);
            }
            SubjectTimeSlot = new ObservableCollection<TimeSlot>(Module);
            Loader = false;

        }

    }
}
