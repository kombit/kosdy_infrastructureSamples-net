svcutil.exe ^
 wsdl\token\*.wsdl ^
 *.xsd ^
 sp\*.wsdl ^
 sp\*.xsd ^
 SF1470_EP_SD1\xsd\1.2.STS-4\*.xsd ^
 SF1470_EP_SD1\xsd\common\*.xsd ^
 /noLogo /n:"*,Kombit.InfrastructureSamples.SagDokumentIndeksService"  /d:..\..\Kombit.InfrastructureSamples\SagDokumentIndeks\ /o:SagDokumentIndeksService.cs

xsd.exe ^
SF1470_EP_SD1\xsd\1.2.STS-4\GenerelleDefinitioner.xsd ^
SF1470_EP_SD1\xsd\1.2.STS-4\SagIndeks.xsd ^
SF1470_EP_SD1\xsd\1.2.STS-4\DokumentIndeks.xsd ^
SF1470_EP_SD1\xsd\common\SagDokObjekt.xsd ^
/e:SagIndeksEgenskaber /e:SagspartLokalUdvidelse /e:SagsaktoerLokalUdvidelse /e:SagsklasseLokalUdvidelse /e:SagsgenstandeLokalUdvidelse /e:DokumentaktoerLokalUdvidelse /e:DokumentaktoerLokalUdvidelse /e:DokumentklasseLokalUdvidelse /e:DokumentpartLokalUdvidelse ^
/c /order /nologo /n:"Kombit.InfrastructureSamples.SagDokumentIndeksService" /o:..\..\Kombit.InfrastructureSamples\SagDokumentIndeks\

powershell -Command "$content = Get-Content -Path '..\..\Kombit.InfrastructureSamples\SagDokumentIndeks\SagDokObjekt.cs'; $newcontent = $content -replace 'VirkningType','VirkningTypeX'; $newcontent = $newcontent -replace 'FoelsomhedType','FoelsomhedTypeX'; $newcontent = $newcontent -replace 'ItemChoiceType','ItemChoiceTypeX'; $newcontent = $newcontent -replace 'UnikIdType','UnikIdTypeX'; $newcontent = $newcontent -replace 'AktoerTypeKodeType','AktoerTypeKodeTypeX'; $newcontent = $newcontent -replace 'TidspunktType','TidspunktTypeX'; $newcontent = $newcontent -replace 'EgenskaberType','EgenskaberTypeSag'; $newContent | Set-Content -Path '..\..\Kombit.InfrastructureSamples\SagDokumentIndeks\SagDokObjekt.cs'"

ren ..\..\Kombit.InfrastructureSamples\SagDokumentIndeks\SagDokObjekt.cs SagDokumentIndeksService.LokalUdvidelse.cs