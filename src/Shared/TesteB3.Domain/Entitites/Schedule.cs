using TesteB3.Domain.Shared.Entitites;

namespace TesteB3.Domain.Entitites
{
    public class Schedule : Entity
    {
        public Schedule(string description, DateTime date)
        {
            Description = description;
            Done = false;
            Date = date;
        }

        public string Description { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }

        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
        }

        public void ChangeDate(DateTime newDate)
        {
            Date = newDate;
        }

        public void SetDone(bool done)
        {
            Done = done;
        }


    }
}
