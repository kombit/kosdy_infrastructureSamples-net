using Kombit.InfrastructureSamples.VirksomhedService;
using Kombit.InfrastructureSamples.Token;
using System;
using System.IdentityModel.Tokens;
using System.Net.Security;
using System.ServiceModel;

namespace Kombit.InfrastructureSamples.Virksomhed
{
    /// <summary>
    /// Class for handling requests to VirksomhedService
    /// </summary>
    public class Virksomhed {

        private SecurityToken token;
        private VirksomhedPortType port;

        /// <summary>
        /// Searches for a Virksomhed object based on CVR number and returns UUID
        /// </summary>
        /// <param name="authorityCvr">CVR number to search for</param>
        /// <returns>UUID for the Virksomhed object</returns>
        public string GetVirksomhedUuid(string authorityCvr)
        { 
            var soegOutput = Soeg(authorityCvr);

            var virksomhedUuidList = soegOutput.IdListe;

            if (virksomhedUuidList == null || virksomhedUuidList.Length == 0)
                return "";  
        
            return virksomhedUuidList[0];
        }

        /// <summary>
        /// Searches for a Virksomhed object based on CVR number and returns SoegOutput.
        /// Uses the SOEG operation in VirksomhedService
        /// </summary>
        /// <param name="authorityCvr">CVR number to search for</param>
        /// <returns>Search output for Virksomhed object</returns>
        internal SoegOutputType Soeg(string authorityCvr){
            soegRequest request = new soegRequest(
                RequestHeader,
                new SoegInputType1()
                {
                    AttributListe = new EgenskabType[]
                    {
                        new EgenskabType
                        {
                            CVRNummerTekst = authorityCvr
                        }
                    },
                    TilstandListe = new TilstandListeType(),
                    RelationListe = new RelationListeType()
                }                  
            );

            soegResponse soegResponse = Port.soeg(request);
            return soegResponse.SoegOutput; 
        }

        #region Port and token helper classes

        /// <summary>
        /// The Port property used to send requests. Creates a new port only if it doesn't already exist, or if the token has expired
        /// </summary>
        private VirksomhedPortType Port {
            get {
                if (port == null || TokenFetcher.IsTokenExpired(token)) {
                    port = CreatePort();
                }

                return port;
            }
            set {
                port = value;
            }
        }

        /// <summary>
        /// Creates the port by getting a token, setting the endpoint and loading the certificates.
        /// </summary>
        /// <returns></returns>
        private VirksomhedPortType CreatePort() {
            token = TokenFetcher.IssueToken(ConfigVariables.OrgService6EntityId);
            VirksomhedPortTypeClient client = new VirksomhedPortTypeClient();

            EndpointIdentity identity = EndpointIdentity.CreateDnsIdentity(ConfigVariables.ServiceCertificateAlias_ORG);
            EndpointAddress endpointAddress = new EndpointAddress(client.Endpoint.ListenUri, identity);
            client.Endpoint.Address = endpointAddress;
            var certificate = CertificateLoader.LoadCertificate(
                ConfigVariables.ClientCertificateStoreName,
                ConfigVariables.ClientCertificateStoreLocation,
                ConfigVariables.ClientCertificateThumbprint
            );
            client.ClientCredentials.ClientCertificate.Certificate = certificate;

            // This sets the MINIMUM level. Since the request header should not be signed, we set it to none.
            client.Endpoint.Contract.ProtectionLevel = ProtectionLevel.None;

            return client.ChannelFactory.CreateChannelWithIssuedToken(token);
        }

        /// <summary>
        /// Creates the request header which is simply a random UUID
        /// </summary>
        private RequestHeaderType RequestHeader {
            get {
                return new RequestHeaderType() {
                    TransactionUUID = Guid.NewGuid().ToString()
                };
            }
        }

        #endregion 
    }
}
