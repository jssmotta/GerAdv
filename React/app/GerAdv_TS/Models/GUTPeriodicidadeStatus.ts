import { IGUTPeriodicidadeStatus } from '../GUTPeriodicidadeStatus/Interfaces/interface.GUTPeriodicidadeStatus';
export interface GUTPeriodicidadeStatus
{
    id: number;
	gutatividade : number;
	datarealizado : string;
	nomegutatividades?: string;

}


export function GUTPeriodicidadeStatusEmpty(): IGUTPeriodicidadeStatus {
// 20250604
    
    return {
        id: 0,
		gutatividade: 0,
		datarealizado: '',
    };
}

export function GUTPeriodicidadeStatusTestEmpty(): IGUTPeriodicidadeStatus {
// 20250604
    
    return {
        id: 1,
		gutatividade: 1,
		datarealizado: 'X',
    };
}


