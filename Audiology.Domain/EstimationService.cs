using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Audiology.Domain
{
    public class EstimationService : IEstimationService
    {
        public EstimationService()
        {

        }

        public Task PrintToPaper(float value)
        {
            throw new NotImplementedException();
        }

        public  MemoryStream PrintToTextFile(float value)
        {
            var mr = new MemoryStream();
            TextWriter tw = new StreamWriter(mr);
            tw.Write(value);
            return mr;
        }
    }
}
