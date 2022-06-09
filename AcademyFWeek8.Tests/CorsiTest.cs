using AcademyFWeek8.Core.BusinessLayer;
using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.RepositoryMOCK;
using Xunit;

namespace AcademyFWeek8.Tests
{
    [Collection("Sequential")]
    public class CorsiTest
    {
        //IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsiMock(), new RepositoryStudentiMock());
        //[Fact]
        //public void DovrebbeAggiungereUnCorso()
        //{
        //    //ARRANGE

        //    Corso nuovoCorso = new Corso()
        //    {
        //        CorsoCodice = "C-03",
        //        Nome = "C# livello 3",
        //        Descrizione = "Corso base liv 3 C#"
        //    };
        //    int numeroCorsiPre = bl.GetAllCorsi().Count;
        //    //ACT
        //    Esito e = bl.AggiungiCorso(nuovoCorso);

        //    //ASSERT
        //    Assert.True(e.IsOk == true);
        //    Assert.Equal(bl.GetAllCorsi().Count, numeroCorsiPre + 1);
        //}
        //[Fact]
        //public void NONDovrebbeAggiungereUnCorso()
        //{
        //    //ARRANGE

        //    Corso nuovoCorso = new Corso()
        //    {
        //        CorsoCodice = "C-03",
        //        Nome = "C# livello 3",
        //        Descrizione = "Corso base liv 3 C#"
        //    };
        //    int numeroCorsiPre = bl.GetAllCorsi().Count;
        //    //ACT
        //    Esito e = bl.AggiungiCorso(nuovoCorso);

        //    //ASSERT
        //    Assert.True(e.IsOk == false);
        //    Assert.Equal(bl.GetAllCorsi().Count, numeroCorsiPre);
        //}
    }
}