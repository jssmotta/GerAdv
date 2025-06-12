import { IEMPClassRiscos } from '../EMPClassRiscos/Interfaces/interface.EMPClassRiscos';
export interface EMPClassRiscos
{
    id: number;
	nome : string;
	bold : boolean;

}


export function EMPClassRiscosEmpty(): IEMPClassRiscos {
// 20250604
    
    return {
        id: 0,
		nome: '',
		bold: false,
    };
}

export function EMPClassRiscosTestEmpty(): IEMPClassRiscos {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
		bold: true,
    };
}


