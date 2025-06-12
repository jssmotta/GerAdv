import { IStatusInstancia } from '../StatusInstancia/Interfaces/interface.StatusInstancia';
export interface StatusInstancia
{
    id: number;
	nome : string;
	bold : boolean;

}


export function StatusInstanciaEmpty(): IStatusInstancia {
// 20250604
    
    return {
        id: 0,
		nome: '',
		bold: false,
    };
}

export function StatusInstanciaTestEmpty(): IStatusInstancia {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
		bold: true,
    };
}


