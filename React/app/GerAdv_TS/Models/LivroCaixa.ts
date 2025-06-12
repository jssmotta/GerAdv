import { ILivroCaixa } from '../LivroCaixa/Interfaces/interface.LivroCaixa';
export interface LivroCaixa
{
    id: number;
	processo : number;
	iddes : number;
	pessoal : number;
	ajuste : boolean;
	idhon : number;
	idhonparc : number;
	idhonsuc : boolean;
	data : string;
	valor : number;
	tipo : boolean;
	historico : string;
	grupo : number;
	nropastaprocessos?: string;

}


export function LivroCaixaEmpty(): ILivroCaixa {
// 20250604
    
    return {
        id: 0,
		processo: 0,
		iddes: 0,
		pessoal: 0,
		ajuste: false,
		idhon: 0,
		idhonparc: 0,
		idhonsuc: false,
		data: '',
		valor: 0,
		tipo: false,
		historico: '',
		grupo: 0,
    };
}

export function LivroCaixaTestEmpty(): ILivroCaixa {
// 20250604
    
    return {
        id: 1,
		processo: 1,
		iddes: 1,
		pessoal: 1,
		ajuste: true,
		idhon: 1,
		idhonparc: 1,
		idhonsuc: true,
		data: 'X',
		valor: 1,
		tipo: true,
		historico: 'X',
		grupo: 1,
    };
}


