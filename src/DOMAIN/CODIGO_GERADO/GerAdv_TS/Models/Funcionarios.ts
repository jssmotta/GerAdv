import { Auditor } from "./Auditor";

import { IFuncionarios } from "../Funcionarios/Interfaces/interface.Funcionarios";
export interface Funcionarios
{
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

export function FuncionariosEmpty(): IFuncionarios {
// 20250125
    return {
        id: 0,
		cargo: 0,
		funcao: 0,
		cidade: 0,
		emailpro: '',
		nome: '',
		sexo: false,
		registro: '',
		cpf: '',
		rg: '',
		tipo: false,
		observacao: '',
		endereco: '',
		bairro: '',
		cep: '',
		contato: '',
		fax: '',
		fone: '',
		email: '',
		periodo_ini: '',
		periodo_fim: '',
		ctpsnumero: '',
		ctpsserie: '',
		pis: '',
		salario: 0,
		ctpsdtemissao: '',
		dtnasc: '',
		data: '',
		liberaagenda: false,
		pasta: '',
		class: '',
		etiqueta: false,
		ani: false,
		bold: false,
		auditor: null
    };
}
