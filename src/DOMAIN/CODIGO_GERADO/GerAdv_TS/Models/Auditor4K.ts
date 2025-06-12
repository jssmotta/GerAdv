import { IAuditor4K } from '../Auditor4K/Interfaces/interface.Auditor4K';
export interface Auditor4K
{
    id: number;
	nome : string;

}


export function Auditor4KEmpty(): IAuditor4K {
// 20250604
    
    return {
        id: 0,
		nome: '',
    };
}

export function Auditor4KTestEmpty(): IAuditor4K {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
    };
}


