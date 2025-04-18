﻿import { Auditor } from "./Auditor";

import { IAlarmSMS } from "../AlarmSMS/Interfaces/interface.AlarmSMS";
export interface AlarmSMS
{
    id: number;
	operador : number;
	agenda : number;
	recado : number;
	descricao : string;
	hora : number;
	minuto : number;
	d1 : boolean;
	d2 : boolean;
	d3 : boolean;
	d4 : boolean;
	d5 : boolean;
	d6 : boolean;
	d7 : boolean;
	email : string;
	desativar : boolean;
	today : string;
	excetodiasfelizes : boolean;
	desktop : boolean;
	alertardatahora : string;
	emocao : number;
	auditor?: Auditor | null;
}

export function AlarmSMSEmpty(): IAlarmSMS {
// 20250125
    return {
        id: 0,
		operador: 0,
		agenda: 0,
		recado: 0,
		descricao: '',
		hora: 0,
		minuto: 0,
		d1: false,
		d2: false,
		d3: false,
		d4: false,
		d5: false,
		d6: false,
		d7: false,
		email: '',
		desativar: false,
		today: '',
		excetodiasfelizes: false,
		desktop: false,
		alertardatahora: '',
		emocao: 0,
		auditor: null
    };
}
