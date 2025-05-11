import { Auditor } from "./Auditor";

import { IColaboradores } from "../Colaboradores/Interfaces/interface.Colaboradores";
export interface Colaboradores
{
    id: number;
	cargo : number;
	cliente : number;
	cidade : number;
	sexo : boolean;
	nome : string;
	cpf : string;
	rg : string;
	dtnasc : string;
	idade : number;
	endereco : string;
	bairro : string;
	cep : string;
	fone : string;
	observacao : string;
	email : string;
	cnh : string;
	class : string;
	etiqueta : boolean;
	ani : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function ColaboradoresEmpty(): IColaboradores {
// 20250125
    return {
        id: 0,
		cargo: 0,
		cliente: 0,
		cidade: 0,
		sexo: false,
		nome: '',
		cpf: '',
		rg: '',
		dtnasc: '',
		idade: 0,
		endereco: '',
		bairro: '',
		cep: '',
		fone: '',
		observacao: '',
		email: '',
		cnh: '',
		class: '',
		etiqueta: false,
		ani: false,
		bold: false,
		auditor: null
    };
}
