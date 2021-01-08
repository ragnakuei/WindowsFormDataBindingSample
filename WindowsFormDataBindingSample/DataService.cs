using System.Linq;

namespace WindowsFormDataBindingSample
{
    public class DataService
    {
        public DataDto[] GetDtos()
        {
            return Enumerable.Range(1, 26)
                             .Select(i => new DataDto
                                          {
                                              Id   = i,
                                              Name = ((char)(64 + i)).ToString(),
                                              Age  = 18 + i
                                          })
                             .ToArray();
        }
    }
}
