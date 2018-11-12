using SimpleNotes.Core.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotes.Core.Repository.Interface
{
    public interface ITagRepository
    {
        void TagC(string[] Tag, int id);
    }
}
