import { Auditor } from "../../Models/Auditor";

export interface IPrepostos {
  id: number;
	funcao : number;
	setor : number;
	cidade : number;
	nome : string;
	dtnasc : string;
	qualificacao : string;
	sexo : boolean;
	idade : number;
	cpf : string;
	rg : string;
	periodo_ini : string;
	periodo_fim : string;
	registro : string;
	ctpsnumero : string;
	ctpsserie : string;
	ctpsdtemissao : string;
	pis : string;
	salario : number;
	liberaagenda : boolean;
	observacao : string;
	endereco : string;
	bairro : string;
	cep : string;
	fone : string;
	fax : string;
	email : string;
	pai : string;
	mae : string;
	class : string;
	etiqueta : boolean;
	ani : boolean;
	bold : boolean;
	guid : string;
	auditor?: Auditor | null;
}
