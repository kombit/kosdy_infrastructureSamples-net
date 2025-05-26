using Kombit.InfrastructureSamples.SagDokumentIndeksService;
using importerResponse = Kombit.InfrastructureSamples.SagDokumentIndeksService.importerResponse;
using Kombit.InfrastructureSamples.KlasseService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Kombit.InfrastructureSamples.UnitTests
{
    ///<summary>
    /// Class for testing the samples 
    ///</summary>

    [TestClass]
    public class ProgramTests
    {
        /// <summary>
        /// Removes any existing case before testing to ensure test of Importer does not fail 
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            var sagdokumentIndeks = new SagDokumentIndeks.SagDokumentIndeks();
            //sagdokumentIndeks.Fjern(ConfigVariables.UUID);
        }            

        /// <summary>
        /// Test method for SagdokumentIndeks
        /// The test ensures that scenarios 1-4 returns Statuskode 20 which equals OK. 
        /// </summary>
        [TestMethod]
        public void ImportFremsoegFjern_ShouldPassWithCode20()
        {
            //Arrange
            var sagdokumentIndeks = new SagDokumentIndeks.SagDokumentIndeks();
            //Act 
            importerResponse importerResponse = sagdokumentIndeks.Importer(ConfigVariables.UUID);
            fremsoegResponse fremsoegResponse = sagdokumentIndeks.Fremsoeg(ConfigVariables.UUID);
            fjernResponse fjernResponse = sagdokumentIndeks.Fjern(ConfigVariables.UUID);
            //Assert
            Assert.AreEqual(importerResponse.ImporterSagDokumentIndeksOutput.Items[0].StatusKode, "20");
            Assert.AreEqual(fremsoegResponse.FremsoegSagDokumentIndeksOutput.StandardRetur.StatusKode, "20");
            Assert.AreEqual(fjernResponse.FjernSagDokumentIndeksOutput.Items[0].StatusKode, "20");

        }

        /// <summary>
        /// Test method for Organisation
        /// The test ensures that scenarios 5 returns does not returns null values when searching for the Organisation. 
        /// </summary>
        [TestMethod]
        public void GetOrganisationByCVR_ShouldPassWithoutReturningNull()
        {
            //Arrange
            var organisation = new Organisation.Organisation();
            //Act
            (string virksomhedUuid, string organisationUuid, string organisationNavn) = organisation.GetOrganisationByCvr(ConfigVariables.MYNDIGHEDS_CVR);
            //Assert
            Assert.IsNotNull(virksomhedUuid);
            Assert.IsNotNull(organisationUuid);
            Assert.IsNotNull(organisationNavn);
        }

        /// <summary>
        /// Test method for Klassifikation
        /// The test ensures that scenarios 6 returns Statuskode 20 which equals OK. 
        /// </summary>
        [TestMethod]
        public void SoegKlasse_ShouldPassWithCode20()
        {
            //Arrange
            var klassifikation = new Klassifikation.Klasse();
            //Act
            SoegOutputType soegOutputKLE_KLASSE = klassifikation.SoegKlasse(ConfigVariables.KLE_KLASSE);
            SoegOutputType soegOutput_KLE_HANDLINGSFACET = klassifikation.SoegKlasse(ConfigVariables.KLE_HANDLINGSFACET);
            //Assert
            Assert.AreEqual(soegOutputKLE_KLASSE.StandardRetur.StatusKode, "20");
            Assert.AreEqual(soegOutput_KLE_HANDLINGSFACET.StandardRetur.StatusKode, "20");
        }

        /// <summary>
        /// Test method for YdelsesIndeks
        /// The test ensures that scenarios 1-4 returns Statuskode 20 which equals OK. 
        /// </summary>
        [TestMethod]
        public void ImporterYdelse_ShouldPassWithCode20()
        {
            //Cleanup
            var bevillingIndeks = new BevillingIndeks.BevillingIndeks();
            var oekonomiskEffektueringIndeks = new OekonomiskEffektueringIndeks.OekonomiskEffektueringIndeks();
            //Act
            BevillingIndeksService.fjernResponse fjernResponse = bevillingIndeks.fjern();
            OekonomiskEffektueringIndeksService.fjernResponse fjernResponseOekonomiskEffektuering = oekonomiskEffektueringIndeks.fjern();

            //Arrange
            var ydelseIndeks = new YdelsesIndeks.YdelseIndeks();
            //Act 
            YdelseIndeksService.importerResponse importerResponse = ydelseIndeks.importer();
            //Assert
            Assert.AreEqual(importerResponse.ImporterYdelseIndeksOutput.Items.Length, 2);
            foreach(YdelseIndeksService.StandardReturType standardReturType in importerResponse.ImporterYdelseIndeksOutput.Items)
            {
                Assert.AreEqual(standardReturType.StatusKode, "20");
                Assert.AreEqual(standardReturType.FejlbeskedTekst, "OK");
                Assert.AreEqual(standardReturType.DetaljeretFejlbesked, null);
            }

            YdelseIndeksService.opdaterResponse opdaterResponse = ydelseIndeks.opdater();
            //Assert
            Assert.AreEqual(opdaterResponse.OpdaterYdelseIndeksOutput.Items.Length, 2);
            foreach (YdelseIndeksService.StandardReturType standardReturType in opdaterResponse.OpdaterYdelseIndeksOutput.Items)
            {
                Assert.AreEqual(standardReturType.StatusKode, "20");
                Assert.AreEqual(standardReturType.FejlbeskedTekst, "OK");
                Assert.AreEqual(standardReturType.DetaljeretFejlbesked, null);
            }

            YdelseIndeksService.fremsoegResponse fremsoegResponse = ydelseIndeks.fremsoeg();

            Assert.AreEqual(fremsoegResponse.FremsoegYdelseIndeksOutput.StandardRetur.StatusKode, "20");
            Assert.AreEqual(fremsoegResponse.FremsoegYdelseIndeksOutput.StandardRetur.FejlbeskedTekst, "OK");
            Assert.AreEqual(fremsoegResponse.FremsoegYdelseIndeksOutput.StandardRetur.DetaljeretFejlbesked, null);

            Assert.AreEqual(fremsoegResponse.FremsoegYdelseIndeksOutput.Antal[0].Element, Kombit.InfrastructureSamples.YdelseIndeksService.AntalTypeElement.bevillinger);
            Assert.AreEqual(fremsoegResponse.FremsoegYdelseIndeksOutput.Antal[0].Antal, "1");
            Assert.AreEqual(fremsoegResponse.FremsoegYdelseIndeksOutput.Antal[1].Element, Kombit.InfrastructureSamples.YdelseIndeksService.AntalTypeElement.effektueringer);
            Assert.AreEqual(fremsoegResponse.FremsoegYdelseIndeksOutput.Antal[1].Antal, "1");

            fremsoegResponse = ydelseIndeks.fremsoegNOT();

            Assert.AreEqual(fremsoegResponse.FremsoegYdelseIndeksOutput.StandardRetur.StatusKode, "20");
            Assert.AreEqual(fremsoegResponse.FremsoegYdelseIndeksOutput.StandardRetur.FejlbeskedTekst, "OK");
            Assert.AreEqual(fremsoegResponse.FremsoegYdelseIndeksOutput.StandardRetur.DetaljeretFejlbesked, null);

            Assert.AreEqual(fremsoegResponse.FremsoegYdelseIndeksOutput.Antal[0].Element, Kombit.InfrastructureSamples.YdelseIndeksService.AntalTypeElement.bevillinger);
            Assert.AreEqual(fremsoegResponse.FremsoegYdelseIndeksOutput.Antal[0].Antal, "0");
            Assert.AreEqual(fremsoegResponse.FremsoegYdelseIndeksOutput.Antal[1].Element, Kombit.InfrastructureSamples.YdelseIndeksService.AntalTypeElement.effektueringer);
            Assert.AreEqual(fremsoegResponse.FremsoegYdelseIndeksOutput.Antal[1].Antal, "1");

            //Act
            fjernResponse = bevillingIndeks.fjern();
            //Assert
            Assert.AreEqual(fjernResponse.FjernOutput.StandardRetur.StatusKode, "20");
            Assert.AreEqual(fjernResponse.FjernOutput.StandardRetur.FejlbeskedTekst, "OK");
            Assert.AreEqual(fjernResponse.FjernOutput.StandardRetur.DetaljeretFejlbesked, null);

            //Act
            fjernResponseOekonomiskEffektuering = oekonomiskEffektueringIndeks.fjern();
            //Assert
            Assert.AreEqual(fjernResponseOekonomiskEffektuering.FjernOutput.StandardRetur.StatusKode, "20");
            Assert.AreEqual(fjernResponseOekonomiskEffektuering.FjernOutput.StandardRetur.FejlbeskedTekst, "OK");
            Assert.AreEqual(fjernResponseOekonomiskEffektuering.FjernOutput.StandardRetur.DetaljeretFejlbesked, null);

        }
    }

    
}
