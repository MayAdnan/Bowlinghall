namespace Bowlinghall
{
    public  class PlayerFactory
    {
        public static Player CreatePlayer(string name)
        {
            return new Player(name);
        }
    }
}
