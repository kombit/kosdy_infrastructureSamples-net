using Kombit.InfrastructureSamples.SagDokumentIndeksService;
using importerResponse = Kombit.InfrastructureSamples.SagDokumentIndeksService.importerResponse;
using Kombit.InfrastructureSamples.KlasseService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            sagdokumentIndeks.Fjern(ConfigVariables.UUID);
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
            Assert.AreEqual(importerResponse.ImporterResponse1.ImporterSagDokumentIndeksOutput.Items[0].StatusKode, "20");
            Assert.AreEqual(fremsoegResponse.FremsoegResponse1.FremsoegSagDokumentIndeksOutput.StandardRetur.StatusKode, "20");
            Assert.AreEqual(fjernResponse.FjernResponse1.FjernSagDokumentIndeksOutput.Items[0].StatusKode, "20");

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
    }
}
