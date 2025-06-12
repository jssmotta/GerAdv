import { IProTipoBaixa } from '../ProTipoBaixa/Interfaces/interface.ProTipoBaixa';
export interface ProTipoBaixa
{
    id: number;
	nome : string;
	bold : boolean;

}


export function ProTipoBaixaEmpty(): IProTipoBaixa {
// 20250604
    
    return {
        id: 0,
		nome: '',
		bold: false,
    };
}

export function ProTipoBaixaTestEmpty(): IProTipoBaixa {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
		bold: true,
    };
}


