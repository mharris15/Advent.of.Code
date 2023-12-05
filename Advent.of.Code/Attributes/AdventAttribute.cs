using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class AdventAttribute : Attribute
    {
        public AdventAttribute(string title, Difficulty difficulty)
        {
            Title = title;
            Difficulty = difficulty;
        }

        public string Title { get; }
        public Difficulty Difficulty { get; }
    }
}
