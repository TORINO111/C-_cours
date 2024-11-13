using Cours.Models;

namespace Cours.Repository
{
    public class DetteRepositoryListImpl : IDetteRepository
    {
        private readonly List<Dette> dettes = new List<Dette>();
        public void Delete(int id)
        {
            Dette detteToRemove = dettes.Find(d => d.Id == id)!;
            if (detteToRemove != null)
                dettes.Remove(detteToRemove);
        }

        public void Insert(Dette entity)
        {
            dettes.Add(entity);
        }

        public List<Dette> SelectAll()
        {
            return dettes;
        }

        public Dette? SelectById(int id)
        {
            return dettes.Find(dette => dette.Id == id);
        }

        public void Update(Dette entity)
        {
            int position = dettes.FindIndex(cl => cl.Id == entity.Id);
            if (position != -1)
                dettes[position] = entity;
        }
    }
}