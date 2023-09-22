svcutil.exe ^
 wsdl\SagDokumentIndeksService_6.wsdl ^
 wsdl\xsd\6.0.STS-0\*.xsd ^
 wsdl\xsd\common\*.xsd ^
 wsdl\xsd\policies\*.wsdl ^
 /noLogo /n:"*,Kombit.InfrastructureSamples.SagDokumentIndeksService"  /d:..\..\Kombit.InfrastructureSamples\SagDokumentIndeks\ /o:SagDokumentIndeksService.cs

xsd.exe ^
 wsdl\xsd\6.0.STS-0\GenerelleDefinitioner.xsd ^
 wsdl\xsd\6.0.STS-0\SagIndeks.xsd ^
 wsdl\xsd\6.0.STS-0\DokumentIndeks.xsd ^
 wsdl\xsd\common\SagDokObjekt.xsd ^
/e:SagIndeksEgenskaber /e:SagspartLokalUdvidelse /e:SagsaktoerLokalUdvidelse /e:SagsklasseLokalUdvidelse /e:SagsgenstandeLokalUdvidelse /e:DokumentaktoerLokalUdvidelse /e:DokumentaktoerLokalUdvidelse /e:DokumentklasseLokalUdvidelse /e:DokumentpartLokalUdvidelse ^
/c /order /nologo /n:"Kombit.InfrastructureSamples.SagDokumentIndeksService" /o:..\..\Kombit.InfrastructureSamples\SagDokumentIndeks\

powershell -Command "$content = Get-Content -Path '..\..\Kombit.InfrastructureSamples\SagDokumentIndeks\SagDokObjekt.cs'; $newcontent = $content -replace 'VirkningType','VirkningTypeX'; $newcontent = $newcontent -replace 'FoelsomhedType','FoelsomhedTypeX'; $newcontent = $newcontent -replace 'ItemChoiceType','ItemChoiceTypeX'; $newcontent = $newcontent -replace 'UnikIdType','UnikIdTypeX'; $newcontent = $newcontent -replace 'AktoerTypeKodeType','AktoerTypeKodeTypeX'; $newcontent = $newcontent -replace 'TidspunktType','TidspunktTypeX'; $newcontent = $newcontent -replace 'EgenskaberType','EgenskaberTypeSag'; $newContent | Set-Content -Path '..\..\Kombit.InfrastructureSamples\SagDokumentIndeks\SagDokObjekt.cs'"

ren ..\..\Kombit.InfrastructureSamples\SagDokumentIndeks\SagDokObjekt.cs SagDokumentIndeksService.LokalUdvidelse.cs