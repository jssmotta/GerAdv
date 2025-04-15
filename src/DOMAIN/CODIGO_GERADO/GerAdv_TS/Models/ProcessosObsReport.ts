import { Auditor } from "./Auditor";

import { IProcessosObsReport } from "../ProcessosObsReport/Interfaces/interface.ProcessosObsReport";
export interface ProcessosObsReport
{
    id: number;
	processo : number;
	historico : number;
	data : string;
	observacao : string;
	auditor?: Auditor | null;
}

export function ProcessosObsReportEmpty(): IProcessosObsReport {
// 20250125
    return {
        id: 0,
		processo: 0,
		historico: 0,
		data: '',
		observacao: '',
		auditor: null
    };
}
