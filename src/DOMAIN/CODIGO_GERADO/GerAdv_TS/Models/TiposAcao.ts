import { ITiposAcao } from '../TiposAcao/Interfaces/interface.TiposAcao';
export interface TiposAcao
{
    id: number;
	nome : string;
	inativo : boolean;
	bold : boolean;

}


export function TiposAcaoEmpty(): ITiposAcao {
// 20250604
    
    return {
        id: 0,
		nome: '',
		inativo: false,
		bold: false,
    };
}

export function TiposAcaoTestEmpty(): ITiposAcao {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
		inativo: true,
		bold: true,
    };
}


