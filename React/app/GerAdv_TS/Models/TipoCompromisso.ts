import { ITipoCompromisso } from '../TipoCompromisso/Interfaces/interface.TipoCompromisso';
export interface TipoCompromisso
{
    id: number;
	icone : number;
	descricao : string;
	financeiro : boolean;
	bold : boolean;

}


export function TipoCompromissoEmpty(): ITipoCompromisso {
// 20250604
    
    return {
        id: 0,
		icone: 0,
		descricao: '',
		financeiro: false,
		bold: false,
    };
}

export function TipoCompromissoTestEmpty(): ITipoCompromisso {
// 20250604
    
    return {
        id: 1,
		icone: 1,
		descricao: 'X',
		financeiro: true,
		bold: true,
    };
}


