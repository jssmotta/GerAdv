import { IProcessosObsReport } from '../ProcessosObsReport/Interfaces/interface.ProcessosObsReport';
export interface ProcessosObsReport
{
    id: number;
	processo : number;
	historico : number;
	data : string;
	observacao : string;
	nropastaprocessos?: string;

}


export function ProcessosObsReportEmpty(): IProcessosObsReport {
// 20250604
    
    return {
        id: 0,
		processo: 0,
		historico: 0,
		data: '',
		observacao: '',
    };
}

export function ProcessosObsReportTestEmpty(): IProcessosObsReport {
// 20250604
    
    return {
        id: 1,
		processo: 1,
		historico: 1,
		data: 'X',
		observacao: 'X',
    };
}


