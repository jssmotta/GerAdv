import { IProCDA } from '../ProCDA/Interfaces/interface.ProCDA';
export interface ProCDA
{
    id: number;
	processo : number;
	nome : string;
	nrointerno : string;
	bold : boolean;
	nropastaprocessos?: string;

}


export function ProCDAEmpty(): IProCDA {
// 20250604
    
    return {
        id: 0,
		processo: 0,
		nome: '',
		nrointerno: '',
		bold: false,
    };
}

export function ProCDATestEmpty(): IProCDA {
// 20250604
    
    return {
        id: 1,
		processo: 1,
		nome: 'X',
		nrointerno: 'X',
		bold: true,
    };
}


