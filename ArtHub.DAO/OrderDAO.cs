using ArtHub.BusinessObject;

namespace ArtHub.DAO
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private readonly ArtHub2024DbContext dbContext = null;
        public OrderDAO()
        {
            if (dbContext == null)
            {
                dbContext = new ArtHub2024DbContext();
            }
        }

        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }
    }
}
