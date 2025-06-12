import { IEnquadramentoEmpresa } from '../EnquadramentoEmpresa/Interfaces/interface.EnquadramentoEmpresa';
export interface EnquadramentoEmpresa
{
    id: number;
	nome : string;

}


export function EnquadramentoEmpresaEmpty(): IEnquadramentoEmpresa {
// 20250604
    
    return {
        id: 0,
		nome: '',
    };
}

export function EnquadramentoEmpresaTestEmpty(): IEnquadramentoEmpresa {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
    };
}


