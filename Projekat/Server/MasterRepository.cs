using Server.Repositories;

namespace Server
{
    public class MasterRepository
    {
        private readonly Projekat_Entities context;

        public BrodogradilisteRepository BrodogradilisteRepository { get; }
        public BrodRepository BrodRepository { get; }
        public BrodskaLinijaRepository BrodskaLinijaRepository { get; }
        public KapetanRepository KapetanRepository { get; }
        public KormilarRepository KormilarRepository { get; }
        public KruzerRepository KruzerRepository { get; }
        public MornarRepository MornarRepository { get; }
        public PosadaRepository PosadaRepository { get; }
        public TankerRepository TankerRepository { get; }
        public TeretniBrodRepository TeretniBrodRepository { get; }

        public MasterRepository(Projekat_Entities ctx)
        {
            context = ctx;
            BrodogradilisteRepository = new BrodogradilisteRepository(context);
            BrodRepository = new BrodRepository(context);
            BrodskaLinijaRepository = new BrodskaLinijaRepository(context);
            KapetanRepository = new KapetanRepository(context);
            KormilarRepository = new KormilarRepository(context);
            KruzerRepository = new KruzerRepository(context);
            MornarRepository = new MornarRepository(context);
            PosadaRepository = new PosadaRepository(context);
            TankerRepository = new TankerRepository(context);
            TeretniBrodRepository = new TeretniBrodRepository(context);
        }

        ~MasterRepository()
        {
            context.Dispose();
        }
    }
}
