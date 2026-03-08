installcerr.ps1 → usa uma vez só, na máquina nova. Instala o mkcert + openssl via Chocolatey e já gera o PFX.
generate-pfx.ps1 → usa pra regenerar o PFX quando precisar.

Se der erro de SSL;
Rodar com ADMIN no POWESHELL:
mkcert -install
mkcert -CAROOT