using GPL.DBModels;

namespace GPL.Queries
{
    public class Persondata
    {
        PersonDataContext _context = new PersonDataContext();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public List<PersonInfo> GetInfos()
        {
            return _context.PersonInfos.ToList();
        }
    }
}
