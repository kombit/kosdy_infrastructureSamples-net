using Kombit.InfrastructureSamples.OekonomiskEffektueringIndeksService;
using Kombit.InfrastructureSamples.Token;
using System;
using System.IdentityModel.Tokens;
using System.Net.Security;
using System.ServiceModel;

namespace Kombit.InfrastructureSamples.OekonomiskEffektueringIndeks
{
    public class OekonomiskEffektueringIndeks
    {
        private SecurityToken token;
        private OekonomiskEffektueringPortType port;


        public fjernResponse fjern()
        {
            fjernRequest fjernRequest = new fjernRequest()
            {
                FjernInput = new UuidNoteInputType()
                {
                    UUIDIdentifikator = ConfigVariables.EFFEKTUERING_UUID_IDENTIFIKATOR
                },
                RequestHeader = RequestHeader
            };

            return Port.fjern(fjernRequest);

        }


        #region Port and token helper methods

        /// <summary>
        /// The Port property used to send requests. Creates a new port only if it doesn't already exist, or the token has expired
        /// </summary>
        private OekonomiskEffektueringPortType Port
        {
            get
            {
                if (port == null || TokenFetcher.IsTokenExpired(token))
                {
                    port = CreatePort();
                }

                return port;
            }
            set
            {
                port = value;
            }
        }
        /// <summary>
        /// Creates the port by getting a token, setting the endpoint and loading the certificates.
        /// </summary>
        /// <returns></returns>
        private OekonomiskEffektueringPortType CreatePort()
        {
            token = TokenFetcher.IssueToken(ConfigVariables.YdelseService6EntityId);
            OekonomiskEffektueringPortTypeClient client = new OekonomiskEffektueringPortTypeClient();

            EndpointIdentity identity = EndpointIdentity.CreateDnsIdentity(ConfigVariables.ServiceCertificateAlias_YDI);
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
        private RequestHeaderType RequestHeader
        {
            get
            {
                return new RequestHeaderType()
                {
                    TransactionUUID = Guid.NewGuid().ToString()
                };
            }
        }

        #endregion
    }
}
