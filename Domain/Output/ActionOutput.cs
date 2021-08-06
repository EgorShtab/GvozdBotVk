using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Output
{
    public class ActionOutput : IOutput
    {
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }
        public static ActionOutput Success => new ActionOutput(true);
        public static ActionOutput Failure(string errorMessage) => new ActionOutput(false, errorMessage);

        public ActionOutput(bool succeeded, string errorMessage = null)
        {
            Succeeded = true;
            ErrorMessage = errorMessage;
        }
    }
}
