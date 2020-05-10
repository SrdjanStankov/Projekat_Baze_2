using System;
using System.Collections.Generic;
using System.ServiceModel;
using Common.Models;

namespace Common
{
    [ServiceContract]
    public interface IBrodOperations
    {
        [OperationContract]
        bool AddBrod(Brod brod, Guid idBrodogradiliste);
        [OperationContract]
        bool AddBrodogradiliste(Brodogradiliste brodogradiliste);
        [OperationContract]
        bool AddBrodskaLinija(BrodskaLinija brodskaLinija);
        [OperationContract]
        bool AddKapetan(Kapetan kapetan, Guid idBrodskaLinija, Guid idBrod);
        [OperationContract]
        bool AddKormilar(Kormilar kormilar);
        [OperationContract]
        Brod GetBrod(Guid id);
        [OperationContract]
        bool AddKruzer(Kruzer kruzer, Guid idBrodogradiliste);
        [OperationContract]
        Brodogradiliste GetBrodogradiliste(Guid guid);
        [OperationContract]
        bool AddMornar(Mornar mornar);
        [OperationContract]
        bool AddPosada(Posada posada, string jmbgKormilar, string jmbgKapetan, Guid idBrod);
        [OperationContract]
        BrodskaLinija GetBrodskaLinija(Guid id);
        [OperationContract]
        void RemoveBrod(Guid id);
        [OperationContract]
        bool AddTanker(Tanker tanker, Guid idBrodogradiliste);
        [OperationContract]
        void EditBrod(Brod brod);
        [OperationContract]
        void RemoveBrodskaLinija(Guid id);
        [OperationContract]
        Mornar GetMornar(string jmbg);
        [OperationContract]
        void RemoveMornar(string jmbg);
        [OperationContract]
        void EditBrodskaLinija(BrodskaLinija brodskaLinija);
        [OperationContract]
        bool AddTeretniBrod(TeretniBrod teretniBrod, Guid idBrodogradilista);
        [OperationContract]
        void RemoveKormilar(string jmbg);
        [OperationContract]
        void EditBrodogradiliste(Brodogradiliste brodogradiliste);
        [OperationContract]
        void RemoveBrodogradiliste(Guid idBrodogradililste);
        [OperationContract]
        IEnumerable<BrodskaLinija> GetBrodskeLinije();
        [OperationContract]
        IEnumerable<Brodogradiliste> GetBrodogradilsta();
        [OperationContract]
        IEnumerable<Kormilar> GetKormilari();
        [OperationContract]
        void EditKormilar(Kormilar kormilar);
        [OperationContract]
        void EditMornar(Mornar mornar);
        [OperationContract]
        IEnumerable<Kapetan> GetKapetani();
        [OperationContract]
        IEnumerable<Brod> GetBrodovi();
        [OperationContract]
        Kormilar GetKormilar(string jmbg);
        [OperationContract]
        IEnumerable<Mornar> GetMornari();
    }
}
