using Kombit.InfrastructureSamples.YdelseIndeksService;
using Kombit.InfrastructureSamples.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens;

namespace Kombit.InfrastructureSamples.YdelsesIndeks
{
    internal class YdelseIndeks
    {
        private SecurityToken token;
        private YdelseIndeksPortType port;

        public importerResponse importer(string uuidIdentifikatorBevilling, string uuidIdentifikatorOekonomiskEffektuering)
        {
            importerRequest request = new importerRequest()
            {
                ImporterYdelseIndeksInput = new[] { new ImportInputType () {
                        BevillingIndeks = new BevillingIndeksType {
                            UdenNotifikation = Boolean.Parse("ÆØÅ"),
                            UUIDIdentifikator = uuidIdentifikatorBevilling,
                            Registrering = new[] { new RegistreringType2 {
                                AttributListe = new AttributListeType {
                                    Egenskaber = new[] { new EgenskaberType {
                                            Virkning = new VirkningType {
                                                FraTidspunkt = new TidspunktType {
                                                    Item = DateTime.Now,
                                                },
                                                TilTidspunkt = new TidspunktType {
                                                    Item = true
                                                },
                                                AktoerRef = new UnikIdType {
                                                    Item = ConfigVariables.AKTOER_REF,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                                AktoerTypeKodeSpecified = true,
                                                NoteTekst = "ÆØÅ"
                                            },
                                            BrugervendtNoegle = "ÆØÅ",
                                            Bevillingstartdato = "ÆØÅ",
                                            Bevillingslutdato = "ÆØÅ",
                                            Begrundelse = "ÆØÅ",
                                            Foelsomhed = FoelsomhedType.IKKE_FORTROLIGE_DATA,
                                            FoelsomhedSpecified = true


                                    }
                                    }
                                }
                            }
                            }
                        }

                }
            }
            };
                


            return null;
        }


        #region Port and token helper methods



        /// <summary>
        /// The Port property used to send requests. Creates a new port only if it doesn't already exist, or the token has expired
        /// </summary>
        private YdelseIndeksPortType Port
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
        private YdelseIndeksPortType CreatePort()
        {
            //TODO Changeg ConfigVariables.SagDokServiceEntityId to ConfigVariables.YdelseServiceEntityId
            token = TokenFetcher.IssueToken(ConfigVariables.SagDokServiceEntityId);
            YdelseIndeksPortTypeClient client = new YdelseIndeksPortTypeClient();

            EndpointIdentity identity = EndpointIdentity.CreateDnsIdentity(ConfigVariables.ServiceCertificateAlias);
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
