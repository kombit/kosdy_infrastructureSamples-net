@echo off
setlocal EnableExtensions EnableDelayedExpansion

echo Installing certificates for Secure Token Service

certutil -addstore -user -f Root "Secure Token Service\TRUST2408 OCES Primary CA.cer"
certutil -addstore -user -f Root "Secure Token Service\TRUST2408 OCES CA III.cer"
certutil -addstore -user -f My "Secure Token Service\test-ekstern-adgangsstyring (funktionscertifikat).cer"

echo Installing certificates for Serviceplatformen

certutil -addstore -user -f Root "Serviceplatformen\TRUST2408 Systemtest VII Primary CA.cer"
certutil -addstore -user -f Root "Serviceplatformen\TRUST2408 Systemtest XXII CA.cer" 
certutil -addstore -user -f My "Serviceplatformen\kombit-sp-signing-test (funktionscertifikat).cer"

echo Installing certificates for Organisation
certutil -addstore -user -f My "Organisation\organisation_t_funktionscertifikat_.cer"

echo Installing certificates for Klassifikation
certutil -addstore -user -f My "Klassifikation\klassifikation_t_funktionscertifikat_.cer"

:exit
