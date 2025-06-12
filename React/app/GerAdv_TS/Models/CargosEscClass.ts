import { ICargosEscClass } from '../CargosEscClass/Interfaces/interface.CargosEscClass';
export interface CargosEscClass
{
    id: number;
	nome : string;

}


export function CargosEscClassEmpty(): ICargosEscClass {
// 20250604
    
    return {
        id: 0,
		nome: '',
    };
}

export function CargosEscClassTestEmpty(): ICargosEscClass {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
    };
}


