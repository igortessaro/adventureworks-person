using System.Collections.Generic;
using System.Linq;

namespace AdventureWorks.Person.Domain.Notification
{
    public sealed class Notification<TData> where TData : class
    {
        public Notification()
        {
            this.ValidationMessages = new List<string>();
        }

        public Notification(TData data)
            : this()
        {
            this.Data = data;
        }

        public TData Data { get; set; }

        public List<string> ValidationMessages { get; set; }

        public bool IsValid => !ValidationMessages.Any();

        public void AddValidation(string message)
        {
            this.ValidationMessages.Add(message);
        }

        public void SetData(TData data)
        {
            this.Data = data;
        }
    }
}
