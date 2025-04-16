import { Auditor } from "./Auditor";

import { IAdvogados } from "../Advogados/Interfaces/interface.Advogados";
export interface Advogados
{
    id: number;
	cargo : number;
	escritorio : number;
	cidade : number;
	emailpro : string;
	cpf : string;
	nome : string;
	rg : string;
	casa : boolean;
	nomemae : string;
	estagiario : boolean;
	oab : string;
	nomecompleto : string;
	endereco : string;
	cep : string;
	sexo : boolean;
	bairro : string;
	ctpsserie : string;
	ctps : string;
	fone : string;
	fax : string;
	comissao : number;
	dtinicio : string;
	dtfim : string;
	dtnasc : string;
	salario : number;
	secretaria : string;
	textoprocuracao : string;
	email : string;
	especializacao : string;
	pasta : string;
	observacao : string;
	contabancaria : string;
	parctop : boolean;
	class : string;
	top : boolean;
	etiqueta : boolean;
	ani : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function AdvogadosEmpty(): IAdvogados {
// 20250125
    return {
        id: 0,
		cargo: 0,
		escritorio: 0,
		cidade: 0,
		emailpro: '',
		cpf: '',
		nome: '',
		rg: '',
		casa: false,
		nomemae: '',
		estagiario: false,
		oab: '',
		nomecompleto: '',
		endereco: '',
		cep: '',
		sexo: false,
		bairro: '',
		ctpsserie: '',
		ctps: '',
		fone: '',
		fax: '',
		comissao: 0,
		dtinicio: '',
		dtfim: '',
		dtnasc: '',
		salario: 0,
		secretaria: '',
		textoprocuracao: '',
		email: '',
		especializacao: '',
		pasta: '',
		observacao: '',
		contabancaria: '',
		parctop: false,
		class: '',
		top: false,
		etiqueta: false,
		ani: false,
		bold: false,
		auditor: null
    };
}
