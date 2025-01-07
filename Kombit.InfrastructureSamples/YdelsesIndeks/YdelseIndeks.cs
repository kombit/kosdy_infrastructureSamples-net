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
    public class YdelseIndeks
    {
        private SecurityToken token;
        private YdelseIndeksPortType port;

        public importerResponse importer(string uuidIdentifikatorBevilling, string uuidIdentifikatorOekonomiskEffektuering)
        {
            importerRequest request = new importerRequest()
            {
                ImporterYdelseIndeksInput = new object[] { new ImportInputType() {
                        BevillingIndeks = new BevillingIndeksType() {
                            UdenNotifikation = Boolean.Parse(ConfigVariables.), // Follow up
                            UdenNotifikationSpecified = true,
                            UUIDIdentifikator = ConfigVariables.bevillingUUIDIdentifikator,

                            Registrering = new[] { new RegistreringType2() {
                                AttributListe = new AttributListeType() {
                                    Egenskaber = new[] { new EgenskaberType() {
                                            Virkning = new VirkningType {
                                                FraTidspunkt = new TidspunktType() { // Follow up
                                                    Item = DateTime.Now,
                                                },
                                                TilTidspunkt = new TidspunktType() { // Follow up
                                                    Item = true
                                                },
                                                AktoerRef = new UnikIdType() {
                                                    Item = ConfigVariables.bevillingsegenskaberAktoerRef,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                AktoerTypeKode = ConfigVariables.bevillingsegenskaberAktoerTypeKode, // Mandatory
                                                AktoerTypeKodeSpecified = true,
                                            //  NoteTekst = , // Optional
                                            },
                                            BrugervendtNoegle = ConfigVariables.bevillingsegenskaberBrugervendtnoegle, // Mandatory
                                            Bevillingstartdato = , // Filled by the Indeks
                                            Bevillingslutdato = , // Filled by the Indeks
                                        //  Begrundelse = , // Optional
                                            Foelsomhed = ConfigVariables.bevillingsegenskaberFoelsomhed, // Mandatory
                                            FoelsomhedSpecified = true
                                    }
                                    },
                                    BevilgetYdelse = new[] { new BevilgetYdelseType() {
                                            Virkning = new VirkningType {
                                                FraTidspunkt = new TidspunktType() { // Follow up
                                                    Item = DateTime.Now,
                                                },
                                                TilTidspunkt = new TidspunktType() {
                                                    Item = true
                                                },
                                                AktoerRef = new UnikIdType() {
                                                    Item = ConfigVariables.bevilgetYdelseAktoerRef,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                AktoerTypeKode = ConfigVariables.bevilgetYdelseAktoerTypeKode,
                                                AktoerTypeKodeSpecified = true,
                                            //  NoteTekst = // Optional
                                            },
                                            Id = ConfigVariables.bevigetYdelseID,
                                            Navn = ConfigVariables.bevigetYdelseNavn,
                                            BevilgetYdelseStartdato = DateTime.Now, // Follow up
                                            BevilgetYdelseStartdatoSpecified = true, // Follow up
                                            BevilgetYdelseSlutdatoSpecified = false, // Follow up
                                        //  Begrundelse = , // Optional
                                        //  Tilbagebetalingspligtig = Boolean.Parse(), // Optional
                                        //  TilbagebetalingspligtigSpecified = true, // Optional
                                        //  Meddelelse = ConfigVariables., // Optional
                                            ItSystem = new [] { new ItSystemRelationType() {
                                                SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                            //  SystemURI = ,
                                                Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Type = new UnikIdType() {
                                                    Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Indeks = , // Not to be filled
                                                ReferenceID = new UnikIdType() {
                                                    Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                /* // Follow up
                                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                   Any = new [] {
                                                       (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                   },
                                                   SenestAendretTidspunkt = DateTime.Now,
                                                   SenestAendretTidspunktSpecified = true
                                                }
                                                */
                                            }
                                            },
                                            Ydelse = new YdelseRelationType() {
                                                Ydelsesnavn = ConfigVariables.ydelseYdelsesnavn,
                                                Klassifikation = new BevillingsklasseRelationType() {
                                                    BrugervendtNoegle = ConfigVariables.bevillingPrimaerKlasseBrugervendtNoegle,
                                                    Klassetitel = ConfigVariables.bevillingPrimaerKlasseKlassetitel,
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.bevillingPrimaerKlasseRolleUuid,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables.bevillingKlasseTypeUuid, 
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Indeks = ConfigVariables.bevillingPrimaerKlasseIndeks,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables.bevillingPrimaerKlasseReferenceId,
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    /* // Follow up
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                       Any = new [] {
                                                           (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                       },
                                                       SenestAendretTidspunkt = DateTime.Now,
                                                       SenestAendretTidspunktSpecified = true
                                                    }
                                                    */
                                                },
                                                 Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.YdelseRolleUuid, // Mandatory
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Type = new UnikIdType() {
                                                    Item = ConfigVariables.YdelseTypeUuid, // Mandatory
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Indeks = ConfigVariables.ydelseIndeks, // Mandatory
                                                ReferenceID = new UnikIdType() {
                                                    Item = ConfigVariables.ydelseReferenceId, // Mandatory
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                /*
                                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                   Any = new [] {
                                                       (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                   },
                                                   SenestAendretTidspunkt = DateTime.Now,
                                                   SenestAendretTidspunktSpecified = true
                                                }
                                                */
                                            },
                                            Items = new [] { new OekonomiskEffektueringsplanType() {
                                                Id = ConfigVariables.effektueringsplanID,
                                                EffektueringsplanStartdato = DateTime.Now, // Follow up
                                                EffektueringsplanSlutdatoSpecified = false, // Follow up
                                                Beregningsfrekvens = ConfigVariables.effektueringsplanBeregningsfrekvens,
                                                ForudBagud = ConfigVariables.effektueringsplanForudBagud,
                                                Dispositionsdag = ConfigVariables.effektueringsplanDispositionsdag,
                                                Ydelsesbeloeb = ConfigVariables.effektueringsplanYdelsesbeloeb,
                                            //  ManueltGodkendes = Boolean.Parse(),
                                                ForudBagudSpecified = true, // Follow up
                                            //  ManueltGodkendesSpecified = true
                                            }
                                            }

                                    }

                                    }
                                },
                                /* // Follow up
                                TilstandListe = new TilstandListeType() {
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                */
                                },
                                RelationListe = new RelationListeType() {
                                    Bevillingssag = new[] {
                                        new BevillingIndeksSagRelationType() {
                                            BrugervendtNoegle = ConfigVariables.bevillingssagBrugervendtNoegle, // Mandatory
                                            FuldtNavn = ConfigVariables.bevillingssagFuldNavn, // Mandatory / Case TItle
                                            Virkning = new VirkningType { // Follow up
                                                FraTidspunkt = new TidspunktType() {
                                                    Item = DateTime.Now,
                                                },
                                                TilTidspunkt = new TidspunktType() {
                                                    Item = true
                                                },
                                                AktoerRef = new UnikIdType() {
                                                    Item = ConfigVariables.bevillingAktoerRef, // Mandatory
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                AktoerTypeKode = ConfigVariables.bevillingssagAktoerTypeKode, // Mandatory
                                                AktoerTypeKodeSpecified = true,
                                            //  NoteTekst = ConfigVariables.
                                            },
                                            Rolle = new UnikIdType() {
                                                Item = ConfigVariables.bevillingssagRolleUuid, // Madatory 
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Type = new UnikIdType() {
                                                Item = ConfigVariables.bevillingssagTypeUuid, // Mandatory
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                        //  Indeks = , // Not to be filled
                                            ReferenceID = new UnikIdType() {
                                                Item = ConfigVariables.bevillingssagReferenceID, // Mandatory  
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            /*
                                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                Any = new [] {
                                                    (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                },
                                                SenestAendretTidspunkt = DateTime.Now,
                                                SenestAendretTidspunktSpecified = true
                                            }
                                            */
                                        }
                                    },
                                    Bevillingspart = new[] { new BevillingIndeksPartRelationType() {
                                        BrugervendtNoegle = ConfigVariables.bevillingspartBrugervendtNoegle,
                                        FuldtNavn = ConfigVariables.ydelsesmodtagerFuldtNavn,
                                        Virkning = new VirkningType { // Follow up
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.bevillingAktoerRef,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = ConfigVariables.bevillingspartAktoerTypeKode,
                                            AktoerTypeKodeSpecified = true,
                                        //  NoteTekst = // Optional
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.bevillingYdelsesmodtagerRolleUuid, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.bevillingYdelsesmodtagerTypeUuid, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.ydelsesmodtagerIndeks, // Mandatory
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.ydelsesmodtagerReferenceId, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        /*
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                        */
                                    }
                                    },
                                    // Bevillings Ejer / Benefit Owner
                                    BevillingsaktoerEjer = new[] { new BevillingIndeksAktoerRelationType() {
                                        FuldtNavn = ConfigVariables.bevillingEjerFuldtNavn,
                                        CVRnr = ConfigVariables.bevillingEjerCvrNr,
                                        Virkning = new VirkningType { // Follow up
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.bevillingAktoerRef,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = ConfigVariables.bevillingEjerAktoerTypeKode, // Follow up
                                            AktoerTypeKodeSpecified = true,
                                            NoteTekst = ConfigVariables.
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.bevillingEjerRolleUuid, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.bevillingEjerTypeUuid, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.bevillingEjerReferenceId, // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        /*
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                        */
                                    }
                                    },
                                    // Bevillings Ansvarlig / Benefit Responsible
                                    BevillingsaktoerAnsvarlig = new[] { new BevillingIndeksAktoerRelationType() {
                                        FuldtNavn = ConfigVariables.bevillingAnsvarligFuldtNavn,
                                        CVRnr = ConfigVariables.bevillingAnsvarligCvrNr,
                                        Virkning = new VirkningType { // Follow up
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.bevillingAktoerRef,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = ConfigVariables.bevillingAnsvarligAktoerTypeKode,
                                            AktoerTypeKodeSpecified = true,
                                            NoteTekst = ConfigVariables.
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.bevillingAnsvarligRolleUuid, // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.bevillingAnsvarligTypeUuid, // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.bevillingAnsvarligIndeks,
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.bevillingAnsvarligReferenceId, // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        /*
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                        */
                                    }
                                    },
                                    /*
                                    Sikkerhedsprofil = new[] { new SikkerhedsprofilRelationType() {
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                            AktoerTypeKodeSpecified = true,
                                            NoteTekst = ConfigVariables.
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables., // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables., // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.,
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables., // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    }*/
                                    
                                },
                                
                            //  NoteTekst = ConfigVariables.,
                                Tidspunkt = DateTime.Now, // Follow up
                                TidspunktSpecified = true,
                                BrugerRef = new UnikIdType() {
                                    Item = ConfigVariables.bevillingAktoerRef,
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LivscyklusKode = ConfigVariables.bevillingLivscykluskode,
                                LivscyklusKodeSpecified = true, // Follow up
                                StsTidspunkt = DateTime.Now,
                                StsTidspunktSpecified = true,
                            }
                            },

                        }


                }, new ImportInputType1() {
                    OekonomiskEffektueringIndeks = new OekonomiskEffektueringIndeksType() {
                        UUIDIdentifikator = ConfigVariables.effektueringUUIDIdentifikator,
                        Registrering = new [] {
                            new RegistreringType3()
                            {
                                AttributListe = new AttributListeType1() {
                                    Egenskaber = new[] { new EgenskaberType1()  {
                                        Virkning = new VirkningType { // Follow up
                                            FraTidspunkt = new TidspunktType() {
                                                Item = ConfigVariables.EffektueringEgenskaberVirkningFra, // DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() { // Follow up
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.EffektueringEgenskaberAktoerRef,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = ConfigVariables.EffektueringEgenskaberAktoerTypeKodeType,
                                            AktoerTypeKodeSpecified = true,
                                        //  NoteTekst = // Optional
                                        },
                                        BrugervendtNoegle = ConfigVariables.EffektueringEgenskaberBrugervendtNoegle,
                                        Startdato = ConfigVariables.EffektueringEgenskaberStartdato, // DateTime.Now
                                        StartdatoSpecified = true,
                                        SlutdatoSpecified = false,
                                        SamletBruttobeloeb = ConfigVariables.EffektueringEgenskaberSamletBruttobeloeb,
                                        Dispositionsdato = ConfigVariables.EffektueringEgenskaberDispositionsdato,
                                        DispositionsdatoSpecified = true,
                                        BeloebEfterSkatATP = ConfigVariables.EffektueringEgenskaberBeloebEfterSkatATP,
                                        BeloebSendtTilUdbetaling = ConfigVariables.EffektueringEgenskaberBeloebSendtTilUdbetaling,
                                    //  BeloebUdbetalt = ,
                                        Udbetalingsafdeling = ConfigVariables.EffektueringEgenskaberUdbetalingsafdeling,
                                    //  SendtTilUdbetalingTekst = ,
                                    //  UdbetaltTekst = 
                                    }
                                    },
                                    /*
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                    */
                                },
                                /*
                                TilstandListe = new TilstandListeType1() {
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        }
                                    }
                                },
                                */
                                RelationListe = new RelationListeType1() {
                                    OekonomiskYdelseEffektueringRelation = new[] {
                                        new OekonomiskYdelseEffektueringRelationType() {
                                            Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = ConfigVariables.YdelseseffektueringVirkningFra, // DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.YdelseseffektueringAktoerRef,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = ClientProperties.YdelseseffektueringAktoerTypeKode,
                                            AktoerTypeKodeSpecified = true,
                                        //  NoteTekst = ConfigVariables. // Optional
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.YdelseseffektueringRolleUuid, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.YdelseseffektueringTypeUuid, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.YdelseseffektueringIndeks,
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables., // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        /*
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        },
                                        */
                                        YdelsesperiodeStartdato = ConfigVariables.YdelseseffektueringYdelsesperiodeStartdato, // DateTime.Now,
                                        YdelsesperiodeStartdatoSpecified = true,
                                        YdelsesperiodeSlutdatoSpecified = false,
                                        Ydelsesbeloeb = ConfigVariables.YdelseseffektueringYdelsesbeloeb,
                                        Klassifikationsbeskrivelse = ConfigVariables.YdelseseffektueringKlassifikationsbeskrivelse,
                                        BevilgetYdelseRef = new BevilgetYdelseRefType() {
                                            UUIDIdentifikator = ConfigVariables.YdelseseffektueringBevilgetYdelseRefUUIDIdentifikator,
                                            BevilgetYdelseId = ConfigVariables.YdelseseffektueringBevilgetYdelseRefBevilgetYdelseId
                                        }
                                        }
                                    },
                                    // Ejer / Aktoer
                                    Aktoer = new[] { new OekonomiskEffektueringIndeksAktoerRelationType() {
                                        FuldtNavn = ConfigVariables.EffektueringEjerFuldtNavn,
                                        CVRnr = ConfigVariables.EffektueringEjerCVRNr,
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = ConfigVariables.EffektueringEjerVirkningFra // DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.EffektueringEjerAktoerRef,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = ConfigVariables.EffektueringEjerAktoerTypeKode,
                                            AktoerTypeKodeSpecified = true,
                                        //  NoteTekst = // Optional
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.effektueringEjerRolleUuid,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.effektueringEjerTypeUuid,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.EffektueringEjerReferenceID,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        /*
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                        */
                                    }
                                    },
                                    ItSystem = new[] { new ItSystemRelationType1() {
                                        SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                    //  SystemURI = ,
                                        Rolle = new UnikIdType() {
                                                Item = ConfigVariables.MASTER_UUID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                    //  Indeks = , // Never to be used
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        /*
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                        */
                                    }
                                    },
                                    OekonomiskEffektueringPart = new[] { new OekonomiskEffektueringIndeksPartRelationType() {
                                    //  BrugervendtNoegle = , // Optional
                                        FuldtNavn = ConfigVariables.EffektueringsmodtagerFuldtNavn,
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = ConfigVariables.EffektueringsmodtagerVirkningfra, // DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.EffektueringsmodtagerAktoerRef,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = ConfigVariables.EffektueringsmodtagerAktoerTypeKode,
                                            AktoerTypeKodeSpecified = true,
                                        //  NoteTekst = ConfigVariables.
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.effektueringModtagerRolleUuid,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.effektueringModtagerTypeUuid,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                    //  Indeks = , //
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.EffektueringsmodtagerReferenceId,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        /*
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                        */
                                    }
                                    },
                                    /*
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                    */
                                },
                            //  NoteTekst = ConfigVariables.,
                                Tidspunkt = DateTime.Now, // Mandatory / Dateformat YYYY-MM-DDThh:mm:ss:ssssTZD / Filled by the 'Fagsystem'
                                TidspunktSpecified = true,
                                BrugerRef = new UnikIdType() {
                                    Item = ConfigVariables.YdelseAktoerRef,
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LivscyklusKode = ConfigVariables.YdelseLivscyklusKode, // LivscyklusKodeType.Importeret,
                                LivscyklusKodeSpecified = true,
                                StsTidspunkt = DateTime.Now, // Filled by the Indeks
                                StsTidspunktSpecified = true // Filled by the Indeks
                            }
                        }
                    }
                }
            },
                RequestHeader = RequestHeader
            };

            return Port.importer(request);
        }

        public opdaterResponse opdater(string uuidIdentifikatorBevilling, string uuidIdentifikatorOekonomiskEffektuering)
        {
            opdaterRequest request = new opdaterRequest()
            {
                OpdaterYdelseIndeksInput = new RetInputType[] {
                    new OpdaterBevillingIndeksInputType()
                    {
                        AttributListe = new AttributListeType()
                        {
                            Egenskaber = new[] { new EgenskaberType() {
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                    AktoerTypeKodeSpecified = true,
                                    NoteTekst = ConfigVariables.
                                },
                                BrugervendtNoegle = ConfigVariables.,
                                Bevillingstartdato = ConfigVariables.,
                                Bevillingslutdato = ConfigVariables.,
                                Begrundelse = ConfigVariables.,
                                Foelsomhed = FoelsomhedType.IKKE_FORTROLIGE_DATA,
                                FoelsomhedSpecified = true
                            }
                            },
                            BevilgetYdelse = new[] { new BevilgetYdelseType() {
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                    AktoerTypeKodeSpecified = true,
                                    NoteTekst = ConfigVariables.
                                },
                                Id = ConfigVariables.,
                                Navn = ConfigVariables.,
                                BevilgetYdelseStartdato = DateTime.Now,
                                BevilgetYdelseStartdatoSpecified = true,
                                BevilgetYdelseSlutdatoSpecified = false,
                                Begrundelse = ConfigVariables.,
                                Tilbagebetalingspligtig = Boolean.Parse(ConfigVariables.),
                                TilbagebetalingspligtigSpecified = true,
                                Meddelelse = ConfigVariables.,
                                ItSystem = new [] { new ItSystemRelationType() {
                                    SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                    SystemURI = ConfigVariables.,
                                    Rolle = new UnikIdType() {
                                            Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Type = new UnikIdType() {
                                        Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Indeks = ConfigVariables.,
                                    ReferenceID = new UnikIdType() {
                                        Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                }
                                },
                                Ydelse = new YdelseRelationType() {
                                    Ydelsesnavn = ConfigVariables.,
                                    Klassifikation = new BevillingsklasseRelationType() {
                                        BrugervendtNoegle = ConfigVariables.,
                                        Klassetitel = ConfigVariables.,
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables., // Constant for Master
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables., // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.,
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables., // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables., // Constant for Master
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Type = new UnikIdType() {
                                        Item = ConfigVariables., // Constant for IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Indeks = ConfigVariables.,
                                    ReferenceID = new UnikIdType() {
                                        Item = ConfigVariables., // The UUID of your IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                },
                                Items = new [] { new OekonomiskEffektueringsplanType() {
                                    Id = ConfigVariables.,
                                    EffektueringsplanStartdato = DateTime.Now,
                                    EffektueringsplanSlutdatoSpecified = false,
                                    Beregningsfrekvens = ConfigVariables.,
                                    ForudBagud = OekonomiskEffektueringsplanTypeForudBagud.Forud,
                                    Dispositionsdag = ConfigVariables.,
                                    Ydelsesbeloeb = ConfigVariables.,
                                    ManueltGodkendes = Boolean.Parse(ConfigVariables.),
                                    ForudBagudSpecified = true,
                                    ManueltGodkendesSpecified = true
                                }
                                }
                            }
                            }
                        },
                        TilstandListe = new TilstandListeType() {
                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                Any = new [] {
                                    (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                },
                                SenestAendretTidspunkt = DateTime.Now,
                                SenestAendretTidspunktSpecified = true
                            }
                        },
                        RelationListe = new RelationListeType() {
                            Bevillingssag = new[] {
                                new BevillingIndeksSagRelationType() {
                                    BrugervendtNoegle = ConfigVariables.,
                                    FuldtNavn = ConfigVariables.,
                                    Virkning = new VirkningType {
                                        FraTidspunkt = new TidspunktType() {
                                            Item = DateTime.Now,
                                        },
                                        TilTidspunkt = new TidspunktType() {
                                            Item = true
                                        },
                                        AktoerRef = new UnikIdType() {
                                            Item = ConfigVariables.AKTOER_REF,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                        AktoerTypeKodeSpecified = true,
                                        NoteTekst = ConfigVariables.
                                    },
                                    Rolle = new UnikIdType() {
                                        Item = ConfigVariables., // Constant for Master
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Type = new UnikIdType() {
                                        Item = ConfigVariables., // Constant for IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Indeks = ConfigVariables.,
                                    ReferenceID = new UnikIdType() {
                                        Item = ConfigVariables., // The UUID of your IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                }
                            },
                            Bevillingspart = new[] { new BevillingIndeksPartRelationType() {
                                BrugervendtNoegle = ConfigVariables.,
                                FuldtNavn = ConfigVariables.,
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                    AktoerTypeKodeSpecified = true,
                                    NoteTekst = ConfigVariables.
                                },
                                Rolle = new UnikIdType() {
                                    Item = ConfigVariables., // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables., // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = ConfigVariables.,
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables., // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                            }
                            },
                            Bevillingsaktoer = new[] { new BevillingIndeksAktoerRelationType() {
                                BrugervendtNoegle = ConfigVariables.,
                                FuldtNavn = ConfigVariables.,
                                CVRnr = ConfigVariables.,
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                    AktoerTypeKodeSpecified = true,
                                    NoteTekst = ConfigVariables.
                                },
                                Rolle = new UnikIdType() {
                                    Item = ConfigVariables., // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables., // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = ConfigVariables.,
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables., // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                            }
                            },
                            Sikkerhedsprofil = new[] { new SikkerhedsprofilRelationType() {
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                    AktoerTypeKodeSpecified = true,
                                    NoteTekst = ConfigVariables.
                                },
                                Rolle = new UnikIdType() {
                                    Item = ConfigVariables., // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables., // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = ConfigVariables.,
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables., // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                            }
                            }
                        },
                        NoteTekst = ConfigVariables.,
                        Tidspunkt = DateTime.Now,
                        UdenNotifikation = Boolean.Parse(ConfigVariables.),
                        UdenNotifikationSpecified = true,
                        UUIDIdentifikator = uuidIdentifikatorBevilling
                    },
                    new OpdaterOekonomiskEffektueringIndeksInputType() {
                        AttributListe = new AttributListeType1() {
                            Egenskaber = new[] { new EgenskaberType1()  {
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                    AktoerTypeKodeSpecified = true,
                                    NoteTekst = ConfigVariables.
                                },
                                BrugervendtNoegle = ConfigVariables.,
                                Startdato = DateTime.Now,
                                StartdatoSpecified = true,
                                SlutdatoSpecified = false,
                                SamletBruttobeloeb = ConfigVariables.,
                                Dispositionsdato = DateTime.Now,
                                DispositionsdatoSpecified = true,
                                BeloebEfterSkatATP = ConfigVariables.,
                                BeloebSendtTilUdbetaling = ConfigVariables.,
                                BeloebUdbetalt = ConfigVariables.,
                                Udbetalingsafdeling = ConfigVariables.,
                                SendtTilUdbetalingTekst = ConfigVariables.,
                                UdbetaltTekst = ConfigVariables.
                            }
                            },
                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                Any = new [] {
                                    (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                },
                                SenestAendretTidspunkt = DateTime.Now,
                                SenestAendretTidspunktSpecified = true
                            }
                        },
                        TilstandListe = new TilstandListeType1() {
                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                Any = new [] {
                                    (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                }
                            }
                        },
                        RelationListe = new RelationListeType1() {
                            OekonomiskYdelseEffektueringRelation = new[] {
                                new OekonomiskYdelseEffektueringRelationType() {
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                    AktoerTypeKodeSpecified = true,
                                    NoteTekst = ConfigVariables.
                                },
                                Rolle = new UnikIdType() {
                                    Item = ConfigVariables., // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables., // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = ConfigVariables.,
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables., // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                },
                                YdelsesperiodeStartdato = DateTime.Now,
                                YdelsesperiodeStartdatoSpecified = true,
                                YdelsesperiodeSlutdatoSpecified = false,
                                Ydelsesbeloeb = ConfigVariables.,
                                Klassifikationsbeskrivelse = ConfigVariables.,
                                BevilgetYdelseRef = new BevilgetYdelseRefType() {
                                    UUIDIdentifikator = ConfigVariables.,
                                    BevilgetYdelseId = ConfigVariables.
                                }
                                }
                            },
                            Aktoer = new[] { new OekonomiskEffektueringIndeksAktoerRelationType() {
                                BrugervendtNoegle = ConfigVariables.,
                                FuldtNavn = ConfigVariables.,
                                CVRnr = ConfigVariables.,
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                    AktoerTypeKodeSpecified = true,
                                    NoteTekst = ConfigVariables.
                                },
                                Rolle = new UnikIdType() {
                                    Item = ConfigVariables.,
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables.,
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = ConfigVariables.,
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables.,
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                            }
                            },
                            ItSystem = new[] { new ItSystemRelationType1() {
                                SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                SystemURI = ConfigVariables.,
                                Rolle = new UnikIdType() {
                                        Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = ConfigVariables.,
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                            }
                            },
                            OekonomiskEffektueringPart = new[] { new OekonomiskEffektueringIndeksPartRelationType() {
                                BrugervendtNoegle = ConfigVariables.,
                                FuldtNavn = ConfigVariables.,
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                    AktoerTypeKodeSpecified = true,
                                    NoteTekst = ConfigVariables.
                                },
                                Rolle = new UnikIdType() {
                                    Item = ConfigVariables.,
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables.,
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = ConfigVariables.,
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables.,
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                            }
                            },
                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                Any = new [] {
                                    (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                },
                                SenestAendretTidspunkt = DateTime.Now,
                                SenestAendretTidspunktSpecified = true
                            }
                        },
                        NoteTekst = ConfigVariables.,
                        Tidspunkt = DateTime.Now,
                        UUIDIdentifikator = ConfigVariables.
                    }
                },
                RequestHeader = RequestHeader
            };

            return Port.opdater(request);
        }

        public fremsoegResponse fremsoegSimple(string uuidBevilling, string uuidOekonomiskEffektuering)
        {
            fremsoegRequest request = new fremsoegRequest()
            {
                FremsoegYdelseIndeksInput = new FremsoegYdelseIndeksInputType()
                {
                    BevillingUuid = new[] { uuidBevilling },
                    OekonomiskEffektueringUuid = new[] { uuidOekonomiskEffektuering }
                },
                RequestHeader = RequestHeader
            };

            return Port.fremsoeg(request);
        }

        public fremsoegResponse fremsoeg(string uuidBevilling, string uuidOekonomiskEffektuering)
        {
            fremsoegRequest request = new fremsoegRequest() {
                FremsoegYdelseIndeksInput = new FremsoegYdelseIndeksInputType() {
                    BevillingUuid = new[] { uuidBevilling },
                    OekonomiskEffektueringUuid = new[] { uuidOekonomiskEffektuering },
                    SoegUdtryk = new SoegUdtrykType() {
                        Items = new Object[] {
                            new SoegInputType() {
                                FoersteResultatReference = ConfigVariables.,
                                SoegRegistrering = new SoegRegistreringType() {
                                    BrugerRef = new UnikIdType() {
                                        Item = ConfigVariables.,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    LivscyklusKode = LivscyklusKodeType.Importeret,
                                    LivscyklusKodeSpecified = true,
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                },
                                MaksimalAntalKvantitet = ConfigVariables.,
                                SoegVirkning = new SoegVirkningType() {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                    AktoerTypeKodeSpecified = true,
                                    NoteTekst = ConfigVariables.,
                                }
                            },
                            new SoegInputType1() {
                                FoersteResultatReference = ConfigVariables.,
                                AttributListe = new AttributListeType()
                                {
                                    Egenskaber = new[] { new EgenskaberType() {
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                            AktoerTypeKodeSpecified = true,
                                            NoteTekst = ConfigVariables.
                                        },
                                        BrugervendtNoegle = ConfigVariables.,
                                        Bevillingstartdato = ConfigVariables.,
                                        Bevillingslutdato = ConfigVariables.,
                                        Begrundelse = ConfigVariables.,
                                        Foelsomhed = FoelsomhedType.IKKE_FORTROLIGE_DATA,
                                        FoelsomhedSpecified = true
                                    }
                                    },
                                    BevilgetYdelse = new[] { new BevilgetYdelseType() {
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                            AktoerTypeKodeSpecified = true,
                                            NoteTekst = ConfigVariables.
                                        },
                                        Id = ConfigVariables.,
                                        Navn = ConfigVariables.,
                                        BevilgetYdelseStartdato = DateTime.Now,
                                        BevilgetYdelseStartdatoSpecified = true,
                                        BevilgetYdelseSlutdatoSpecified = false,
                                        Begrundelse = ConfigVariables.,
                                        Tilbagebetalingspligtig = Boolean.Parse(ConfigVariables.),
                                        TilbagebetalingspligtigSpecified = true,
                                        Meddelelse = ConfigVariables.,
                                        ItSystem = new [] { new ItSystemRelationType() {
                                            SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                            SystemURI = ConfigVariables.,
                                            Rolle = new UnikIdType() {
                                                    Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Type = new UnikIdType() {
                                                Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Indeks = ConfigVariables.,
                                            ReferenceID = new UnikIdType() {
                                                Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                Any = new [] {
                                                    (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                },
                                                SenestAendretTidspunkt = DateTime.Now,
                                                SenestAendretTidspunktSpecified = true
                                            }
                                        }
                                        },
                                        Ydelse = new YdelseRelationType() {
                                            Ydelsesnavn = ConfigVariables.,
                                            Klassifikation = new BevillingsklasseRelationType() {
                                                BrugervendtNoegle = ConfigVariables.,
                                                Klassetitel = ConfigVariables.,
                                                Rolle = new UnikIdType() {
                                                    Item = ConfigVariables., // Constant for Master
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Type = new UnikIdType() {
                                                    Item = ConfigVariables., // Constant for IT-system
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Indeks = ConfigVariables.,
                                                ReferenceID = new UnikIdType() {
                                                    Item = ConfigVariables., // The UUID of your IT-system
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                    Any = new [] {
                                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                    },
                                                    SenestAendretTidspunkt = DateTime.Now,
                                                    SenestAendretTidspunktSpecified = true
                                                }
                                            },
                                                Rolle = new UnikIdType() {
                                                    Item = ConfigVariables., // Constant for Master
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Type = new UnikIdType() {
                                                Item = ConfigVariables., // Constant for IT-system
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Indeks = ConfigVariables.,
                                            ReferenceID = new UnikIdType() {
                                                Item = ConfigVariables., // The UUID of your IT-system
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                Any = new [] {
                                                    (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                },
                                                SenestAendretTidspunkt = DateTime.Now,
                                                SenestAendretTidspunktSpecified = true
                                            }
                                        },
                                        Items = new [] { new OekonomiskEffektueringsplanType() {
                                            Id = ConfigVariables.,
                                            EffektueringsplanStartdato = DateTime.Now,
                                            EffektueringsplanSlutdatoSpecified = false,
                                            Beregningsfrekvens = ConfigVariables.,
                                            ForudBagud = OekonomiskEffektueringsplanTypeForudBagud.Forud,
                                            Dispositionsdag = ConfigVariables.,
                                            Ydelsesbeloeb = ConfigVariables.,
                                            ManueltGodkendes = Boolean.Parse(ConfigVariables.),
                                            ForudBagudSpecified = true,
                                            ManueltGodkendesSpecified = true
                                        }
                                        }
                                    }
                                    }
                                },
                                TilstandListe = new TilstandListeType() {
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                },
                                RelationListe = new RelationListeType() {
                                    Bevillingssag = new[] {
                                        new BevillingIndeksSagRelationType() {
                                            BrugervendtNoegle = ConfigVariables.,
                                            FuldtNavn = ConfigVariables.,
                                            Virkning = new VirkningType {
                                                FraTidspunkt = new TidspunktType() {
                                                    Item = DateTime.Now,
                                                },
                                                TilTidspunkt = new TidspunktType() {
                                                    Item = true
                                                },
                                                AktoerRef = new UnikIdType() {
                                                    Item = ConfigVariables.AKTOER_REF,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                                AktoerTypeKodeSpecified = true,
                                                NoteTekst = ConfigVariables.
                                            },
                                            Rolle = new UnikIdType() {
                                                Item = ConfigVariables., // Constant for Master
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Type = new UnikIdType() {
                                                Item = ConfigVariables., // Constant for IT-system
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Indeks = ConfigVariables.,
                                            ReferenceID = new UnikIdType() {
                                                Item = ConfigVariables., // The UUID of your IT-system
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                Any = new [] {
                                                    (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                },
                                                SenestAendretTidspunkt = DateTime.Now,
                                                SenestAendretTidspunktSpecified = true
                                            }
                                        }
                                    },
                                    Bevillingspart = new[] { new BevillingIndeksPartRelationType() {
                                        BrugervendtNoegle = ConfigVariables.,
                                        FuldtNavn = ConfigVariables.,
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                            AktoerTypeKodeSpecified = true,
                                            NoteTekst = ConfigVariables.
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables., // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables., // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.,
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables., // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    },
                                    Bevillingsaktoer = new[] { new BevillingIndeksAktoerRelationType() {
                                        BrugervendtNoegle = ConfigVariables.,
                                        FuldtNavn = ConfigVariables.,
                                        CVRnr = ConfigVariables.,
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                            AktoerTypeKodeSpecified = true,
                                            NoteTekst = ConfigVariables.
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables., // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables., // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.,
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables., // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    },
                                    Sikkerhedsprofil = new[] { new SikkerhedsprofilRelationType() {
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                            AktoerTypeKodeSpecified = true,
                                            NoteTekst = ConfigVariables.
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables., // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables., // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.,
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables., // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    }
                                },
                                SoegRegistrering = new SoegRegistreringType() {
                                    BrugerRef = new UnikIdType() {
                                        Item = ConfigVariables.,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    LivscyklusKode = LivscyklusKodeType.Importeret,
                                    LivscyklusKodeSpecified = true,
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                },
                                MaksimalAntalKvantitet = ConfigVariables.,
                                SoegVirkning = new SoegVirkningType() {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                    AktoerTypeKodeSpecified = true,
                                    NoteTekst = ConfigVariables.,
                                },
                                SoegStsFraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                },
                                SoegStsTilTidspunkt = new TidspunktType() {
                                    Item = true
                                }
                            },
                            new SoegInputType2() {
                                FoersteResultatReference = ConfigVariables.,
                                AttributListe = new AttributListeType1() {
                                    Egenskaber = new[] { new EgenskaberType1()  {
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                            AktoerTypeKodeSpecified = true,
                                            NoteTekst = ConfigVariables.
                                        },
                                        BrugervendtNoegle = ConfigVariables.,
                                        Startdato = DateTime.Now,
                                        StartdatoSpecified = true,
                                        SlutdatoSpecified = false,
                                        SamletBruttobeloeb = ConfigVariables.,
                                        Dispositionsdato = DateTime.Now,
                                        DispositionsdatoSpecified = true,
                                        BeloebEfterSkatATP = ConfigVariables.,
                                        BeloebSendtTilUdbetaling = ConfigVariables.,
                                        BeloebUdbetalt = ConfigVariables.,
                                        Udbetalingsafdeling = ConfigVariables.,
                                        SendtTilUdbetalingTekst = ConfigVariables.,
                                        UdbetaltTekst = ConfigVariables.
                                    }
                                    },
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                },
                                TilstandListe = new TilstandListeType1() {
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        }
                                    }
                                },
                                RelationListe = new RelationListeType1() {
                                    OekonomiskYdelseEffektueringRelation = new[] {
                                        new OekonomiskYdelseEffektueringRelationType() {
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                            AktoerTypeKodeSpecified = true,
                                            NoteTekst = ConfigVariables.
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables., // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables., // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.,
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables., // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        },
                                        YdelsesperiodeStartdato = DateTime.Now,
                                        YdelsesperiodeStartdatoSpecified = true,
                                        YdelsesperiodeSlutdatoSpecified = false,
                                        Ydelsesbeloeb = ConfigVariables.,
                                        Klassifikationsbeskrivelse = ConfigVariables.,
                                        BevilgetYdelseRef = new BevilgetYdelseRefType() {
                                            UUIDIdentifikator = ConfigVariables.,
                                            BevilgetYdelseId = ConfigVariables.
                                        }
                                        }
                                    },
                                    Aktoer = new[] { new OekonomiskEffektueringIndeksAktoerRelationType() {
                                        BrugervendtNoegle = ConfigVariables.,
                                        FuldtNavn = ConfigVariables.,
                                        CVRnr = ConfigVariables.,
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                            AktoerTypeKodeSpecified = true,
                                            NoteTekst = ConfigVariables.
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.,
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    },
                                    ItSystem = new[] { new ItSystemRelationType1() {
                                        SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                        SystemURI = ConfigVariables.,
                                        Rolle = new UnikIdType() {
                                                Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.,
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    },
                                    OekonomiskEffektueringPart = new[] { new OekonomiskEffektueringIndeksPartRelationType() {
                                        BrugervendtNoegle = ConfigVariables.,
                                        FuldtNavn = ConfigVariables.,
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Now,
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = true
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                            AktoerTypeKodeSpecified = true,
                                            NoteTekst = ConfigVariables.
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.,
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    },
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                },
                                MaksimalAntalKvantitet = "999",
                                SoegRegistrering = new SoegRegistreringType() {
                                    BrugerRef = new UnikIdType() {
                                        Item = ConfigVariables.,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    LivscyklusKode = LivscyklusKodeType.Importeret,
                                    LivscyklusKodeSpecified = true,
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                },
                                SoegVirkning = new SoegVirkningType() {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                    AktoerTypeKodeSpecified = true,
                                    NoteTekst = ConfigVariables.,
                                },
                                SoegStsFraTidspunkt = new TidspunktType() {
                                    Item = DateTime.Now,
                                },
                                SoegStsTilTidspunkt = new TidspunktType() {
                                    Item = true
                                },

                            },
                            new SoegInputType() {
                                FoersteResultatReference = ConfigVariables.,
                                SoegRegistrering = new SoegRegistreringType() {
                                    BrugerRef = new UnikIdType() {
                                        Item = ConfigVariables.,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    LivscyklusKode = LivscyklusKodeType.Importeret,
                                    LivscyklusKodeSpecified = true,
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                },
                                MaksimalAntalKvantitet = ConfigVariables.,
                                SoegVirkning = new SoegVirkningType() {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                    AktoerTypeKodeSpecified = true,
                                    NoteTekst = ConfigVariables.,
                                }
                            },
                        },
                        operation = AndOrType.AND,
                        operationSpecified = true,
                        ItemsElementName = new[] {
                            ItemsChoiceType.SoegUdtryk,
                            ItemsChoiceType.SoegBevillingIndeks,
                            ItemsChoiceType.SoegOekonomiskEffektueringIndeks,
                            ItemsChoiceType.NOT
                        },
                    }
                },
                RequestHeader = RequestHeader
            };

            return Port.fremsoeg(request);
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
            token = TokenFetcher.IssueToken(ConfigVariables.YdelseService6EntityId);
            YdelseIndeksPortTypeClient client = new YdelseIndeksPortTypeClient();

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
