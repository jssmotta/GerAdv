import { IStatusAndamento } from '../StatusAndamento/Interfaces/interface.StatusAndamento';
export interface StatusAndamento
{
    id: number;
	nome : string;
	icone : number;
	bold : boolean;

}


export function StatusAndamentoEmpty(): IStatusAndamento {
// 20250604
    
    return {
        id: 0,
		nome: '',
		icone: 0,
		bold: false,
    };
}

export function StatusAndamentoTestEmpty(): IStatusAndamento {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
		icone: 1,
		bold: true,
    };
}


