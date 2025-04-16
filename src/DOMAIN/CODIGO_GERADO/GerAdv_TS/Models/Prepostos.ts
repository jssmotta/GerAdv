import { Auditor } from "./Auditor";

import { IPrepostos } from "../Prepostos/Interfaces/interface.Prepostos";
export interface Prepostos
{
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
	auditor?: Auditor | null;
}

export function PrepostosEmpty(): IPrepostos {
// 20250125
    return {
        id: 0,
		funcao: 0,
		setor: 0,
		cidade: 0,
		nome: '',
		dtnasc: '',
		qualificacao: '',
		sexo: false,
		idade: 0,
		cpf: '',
		rg: '',
		periodo_ini: '',
		periodo_fim: '',
		registro: '',
		ctpsnumero: '',
		ctpsserie: '',
		ctpsdtemissao: '',
		pis: '',
		salario: 0,
		liberaagenda: false,
		observacao: '',
		endereco: '',
		bairro: '',
		cep: '',
		fone: '',
		fax: '',
		email: '',
		pai: '',
		mae: '',
		class: '',
		etiqueta: false,
		ani: false,
		bold: false,
		auditor: null
    };
}
