import { ITipoContatoCRM } from '../TipoContatoCRM/Interfaces/interface.TipoContatoCRM';
export interface TipoContatoCRM
{
    id: number;
	nome : string;
	bold : boolean;

}


export function TipoContatoCRMEmpty(): ITipoContatoCRM {
// 20250604
    
    return {
        id: 0,
		nome: '',
		bold: false,
    };
}

export function TipoContatoCRMTestEmpty(): ITipoContatoCRM {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
		bold: true,
    };
}


