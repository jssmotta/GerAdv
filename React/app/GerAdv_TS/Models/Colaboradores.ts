import { IColaboradores } from '../Colaboradores/Interfaces/interface.Colaboradores';
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
	nomecargos?: string;
	nomeclientes?: string;
	nomecidade?: string;

}


export function ColaboradoresEmpty(): IColaboradores {
// 20250604
    
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
    };
}

export function ColaboradoresTestEmpty(): IColaboradores {
// 20250604
    
    return {
        id: 1,
		cargo: 1,
		cliente: 1,
		cidade: 1,
		sexo: true,
		nome: 'X',
		cpf: 'X',
		rg: 'X',
		dtnasc: 'X',
		idade: 1,
		endereco: 'X',
		bairro: 'X',
		cep: 'X',
		fone: 'X',
		observacao: 'X',
		email: 'X',
		cnh: 'X',
		class: 'X',
		etiqueta: true,
		ani: true,
		bold: true,
    };
}


