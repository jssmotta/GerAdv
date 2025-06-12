import { INENotas } from '../NENotas/Interfaces/interface.NENotas';
export interface NENotas
{
    id: number;
	apenso : number;
	precatoria : number;
	instancia : number;
	processo : number;
	movpro : boolean;
	nome : string;
	notaexpedida : boolean;
	revisada : boolean;
	palavrachave : number;
	data : string;
	notapublicada : string;
	nroprocessoinstancia?: string;
	nropastaprocessos?: string;

}


export function NENotasEmpty(): INENotas {
// 20250604
    
    return {
        id: 0,
		apenso: 0,
		precatoria: 0,
		instancia: 0,
		processo: 0,
		movpro: false,
		nome: '',
		notaexpedida: false,
		revisada: false,
		palavrachave: 0,
		data: '',
		notapublicada: '',
    };
}

export function NENotasTestEmpty(): INENotas {
// 20250604
    
    return {
        id: 1,
		apenso: 1,
		precatoria: 1,
		instancia: 1,
		processo: 1,
		movpro: true,
		nome: 'X',
		notaexpedida: true,
		revisada: true,
		palavrachave: 1,
		data: 'X',
		notapublicada: 'X',
    };
}


