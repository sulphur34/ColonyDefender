namespace Utils.Interfaces
{
    public interface ISavable
    {
        public string Token { get; }

        public void Save();

        public void Load();
    }
}