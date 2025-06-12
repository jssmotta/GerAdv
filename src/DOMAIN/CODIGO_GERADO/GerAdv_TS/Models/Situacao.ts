import { ISituacao } from '../Situacao/Interfaces/interface.Situacao';
export interface Situacao
{
    id: number;
	parte_int : string;
	parte_opo : string;
	top : boolean;
	bold : boolean;

}


export function SituacaoEmpty(): ISituacao {
// 20250604
    
    return {
        id: 0,
		parte_int: '',
		parte_opo: '',
		top: false,
		bold: false,
    };
}

export function SituacaoTestEmpty(): ISituacao {
// 20250604
    
    return {
        id: 1,
		parte_int: 'X',
		parte_opo: 'X',
		top: true,
		bold: true,
    };
}


