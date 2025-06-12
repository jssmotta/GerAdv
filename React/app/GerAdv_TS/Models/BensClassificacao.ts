import { IBensClassificacao } from '../BensClassificacao/Interfaces/interface.BensClassificacao';
export interface BensClassificacao
{
    id: number;
	nome : string;
	bold : boolean;

}


export function BensClassificacaoEmpty(): IBensClassificacao {
// 20250604
    
    return {
        id: 0,
		nome: '',
		bold: false,
    };
}

export function BensClassificacaoTestEmpty(): IBensClassificacao {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
		bold: true,
    };
}


