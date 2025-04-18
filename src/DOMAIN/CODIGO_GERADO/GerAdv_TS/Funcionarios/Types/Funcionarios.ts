﻿import { Auditor } from "../../Models/Auditor";

export interface IFuncionarios {
  id: number;
	cargo : number;
	funcao : number;
	cidade : number;
	emailpro : string;
	nome : string;
	sexo : boolean;
	registro : string;
	cpf : string;
	rg : string;
	tipo : boolean;
	observacao : string;
	endereco : string;
	bairro : string;
	cep : string;
	contato : string;
	fax : string;
	fone : string;
	email : string;
	periodo_ini : string;
	periodo_fim : string;
	ctpsnumero : string;
	ctpsserie : string;
	pis : string;
	salario : number;
	ctpsdtemissao : string;
	dtnasc : string;
	data : string;
	liberaagenda : boolean;
	pasta : string;
	class : string;
	etiqueta : boolean;
	ani : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}
