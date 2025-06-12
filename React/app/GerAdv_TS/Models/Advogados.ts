import { IAdvogados } from '../Advogados/Interfaces/interface.Advogados';
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
	nomecargos?: string;
	nomeescritorios?: string;
	nomecidade?: string;

}


export function AdvogadosEmpty(): IAdvogados {
// 20250604
    
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
    };
}

export function AdvogadosTestEmpty(): IAdvogados {
// 20250604
    
    return {
        id: 1,
		cargo: 1,
		escritorio: 1,
		cidade: 1,
		emailpro: 'X',
		cpf: 'X',
		nome: 'X',
		rg: 'X',
		casa: true,
		nomemae: 'X',
		estagiario: true,
		oab: 'X',
		nomecompleto: 'X',
		endereco: 'X',
		cep: 'X',
		sexo: true,
		bairro: 'X',
		ctpsserie: 'X',
		ctps: 'X',
		fone: 'X',
		fax: 'X',
		comissao: 1,
		dtinicio: 'X',
		dtfim: 'X',
		dtnasc: 'X',
		salario: 1,
		secretaria: 'X',
		textoprocuracao: 'X',
		email: 'X',
		especializacao: 'X',
		pasta: 'X',
		observacao: 'X',
		contabancaria: 'X',
		parctop: true,
		class: 'X',
		top: true,
		etiqueta: true,
		ani: true,
		bold: true,
    };
}


