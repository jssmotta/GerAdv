import { IOperadores } from '../Operadores/Interfaces/interface.Operadores';
export interface Operadores
{
    id: number;
	cliente : number;
	enviado : boolean;
	casa : boolean;
	casaid : number;
	casacodigo : number;
	isnovo : boolean;
	grupo : number;
	nome : string;
	email : string;
	senha : string;
	ativado : boolean;
	atualizarsenha : boolean;
	senha256 : string;
	suportesenha256 : string;
	suportemaxage : string;
	nomeclientes?: string;

}


export function OperadoresEmpty(): IOperadores {
// 20250604
    
    return {
        id: 0,
		cliente: 0,
		enviado: false,
		casa: false,
		casaid: 0,
		casacodigo: 0,
		isnovo: false,
		grupo: 0,
		nome: '',
		email: '',
		senha: '',
		ativado: false,
		atualizarsenha: false,
		senha256: '',
		suportesenha256: '',
		suportemaxage: '',
    };
}

export function OperadoresTestEmpty(): IOperadores {
// 20250604
    
    return {
        id: 1,
		cliente: 1,
		enviado: true,
		casa: true,
		casaid: 1,
		casacodigo: 1,
		isnovo: true,
		grupo: 1,
		nome: 'X',
		email: 'X',
		senha: 'X',
		ativado: true,
		atualizarsenha: true,
		senha256: 'X',
		suportesenha256: 'X',
		suportemaxage: 'X',
    };
}


